using Aue.Stage.Register.Models;
using Aue.Stage.Register.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Aue.Stage.Register.Forms;

namespace Aue.Stage.Register
{

    public partial class MainForm : Form
    {
        private CreateContact createContact;
        private DeleteContact deleteContact;
        private ListAllFromContact listAllFromContact;

        public MainForm()
        {
            InitializeComponent();
            ConfigureReportListView();
            createContact = new CreateContact();
            deleteContact = new DeleteContact();
            listAllFromContact = new ListAllFromContact();
        }


        private void LoadAllContacts()
        {
            listBox1.DataSource = null;

            listBox1.DataSource = listAllFromContact.ListAllContact();

            listBox1.DisplayMember = "Name";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllContacts();
        }

        private void countContactByCityButton_Click(object sender, EventArgs e)
        {
            var todosContatos = listAllFromContact.ListAllContact();

            reportListView.Items.Clear();
            reportListView.Groups.Clear();

            if (todosContatos == null || !todosContatos.Any())
            {
                reportListView.Items.Add("Nenhum contato cadastrado para análise.");
                return;
            }


            int totalHomens = todosContatos.Count(c => c.Sex == "M");
            int totalMulheres = todosContatos.Count(c => c.Sex == "F");

            ListViewItem totalItem = new ListViewItem("Número de contatos no banco de dados");
            totalItem.SubItems.Add(todosContatos.Count.ToString());
            totalItem.SubItems.Add(totalHomens.ToString());
            totalItem.SubItems.Add(totalMulheres.ToString());
            totalItem.Font = new Font(reportListView.Font, FontStyle.Bold); 
            reportListView.Items.Add(totalItem);

            reportListView.Items.Add("");

            var gruposPorCidade = todosContatos.GroupBy(contato => contato.City);

            foreach (var grupoCidade in gruposPorCidade)
            {
                string nomeCidade = grupoCidade.Key.ToUpper();
                var contatosDaCidade = grupoCidade.ToList();

                ListViewGroup cityGroup = new ListViewGroup(nomeCidade, HorizontalAlignment.Left);
                reportListView.Groups.Add(cityGroup);

                var gruposPorMes = contatosDaCidade
                    .GroupBy(contato => contato.CreatedAt.Month)
                    .OrderBy(grupo => grupo.Key); 

                foreach (var grupoMes in gruposPorMes)
                {
                    int numeroMes = grupoMes.Key;
                    string nomeMes = new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.GetMonthName(numeroMes);
                    nomeMes = char.ToUpper(nomeMes[0]) + nomeMes.Substring(1); 

                    int homensNoMes = grupoMes.Count(c => c.Sex == "M");
                    int mulheresNoMes = grupoMes.Count(c => c.Sex == "F");

                    ListViewItem monthItem = new ListViewItem($"  . {nomeMes}"); 
                    monthItem.SubItems.Add(grupoMes.Count().ToString());
                    monthItem.SubItems.Add(homensNoMes.ToString());
                    monthItem.SubItems.Add(mulheresNoMes.ToString());
                    monthItem.Group = cityGroup; 
                    reportListView.Items.Add(monthItem);
                }

                ListViewItem cityTotalItem = new ListViewItem($"  . Total");
                cityTotalItem.SubItems.Add(contatosDaCidade.Count.ToString());
                cityTotalItem.SubItems.Add(contatosDaCidade.Count(c => c.Sex == "M").ToString());
                cityTotalItem.SubItems.Add(contatosDaCidade.Count(c => c.Sex == "F").ToString());
                cityTotalItem.Font = new Font(reportListView.Font, FontStyle.Bold);
                cityTotalItem.Group = cityGroup;
                reportListView.Items.Add(cityTotalItem);
            }
        }

        private void includeButton_Click(object sender, EventArgs e)
        {
            string sex = string.Empty;

            if (femaleCheckBox.Checked || maleCheckBox.Checked)
                sex = femaleCheckBox.Checked ? "F" : "M";

            var contactToCreate = new Contact
            {
                Name = nameTextBox.Text,
                City = cityTextBox.Text,
                Sex = sex,
                CreatedAt = DateTime.Now
            };

            createContact.createContact(contactToCreate);

            nameTextBox.Clear();
            cityTextBox.Clear();

            LoadAllContacts();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um contato na lista para alterar.",
                                "Nenhum Contato Selecionado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            Contact selectedContact = listBox1.SelectedItem as Contact;

            using (var updateForm = new ContactUpdateForm(selectedContact))
            {
                var result = updateForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadAllContacts();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Contact selectedContact = listBox1.SelectedItem as Contact;

            if (selectedContact == null)
            {
                MessageBox.Show("Por favor, selecione um contato na lista para excluir.",
                                "Nenhum Contato Selecionado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if( deleteContact.deleteContact(selectedContact.Id))
                MessageBox.Show("Contato excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao excluir o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadAllContacts();
        }

        private void femaleCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
                maleCheckBox.Checked = false;
        }

        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
                femaleCheckBox.Checked = false;
        }

        private void groupSexBox_Enter(object sender, EventArgs e) { }
        private void cityTextBox_TextChanged(object sender, EventArgs e) { }
        private void nameTextBox_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void reportListView_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void ConfigureReportListView()
        {
            if (reportListView == null) return;

            reportListView.Items.Clear();  
            reportListView.Columns.Clear(); 

            reportListView.View = View.Details;

            reportListView.LabelEdit = false;
            reportListView.FullRowSelect = true;

            reportListView.Columns.Add("Descrição", 250, HorizontalAlignment.Left);
            reportListView.Columns.Add("Total", 70, HorizontalAlignment.Center);
            reportListView.Columns.Add("Homens", 70, HorizontalAlignment.Center);
            reportListView.Columns.Add("Mulheres", 70, HorizontalAlignment.Center);
        }
     
    }
}
