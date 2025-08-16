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
        private ListAllFromContacts listAllFromContact;

        public MainForm()
        {
            InitializeComponent();
            createContact = new CreateContact();
            deleteContact = new DeleteContact();
            listAllFromContact = new ListAllFromContacts();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAllContacts();
            ConfigureReportListView();
        }

        private void LoadAllContacts()
        {
            listContactsBox.DataSource = null;
            listContactsBox.DataSource = listAllFromContact.ListAllContact();
            listContactsBox.DisplayMember = "Name";
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

            AddTotalContactsSummary(todosContatos, totalHomens, totalMulheres);

            var gruposPorCidade = todosContatos.GroupBy(contato => contato.City);

            AddCityContactGroupsToReport(gruposPorCidade);
        }

        private void includeButton_Click(object sender, EventArgs e)
        {
            createContact.createContact(
                new Contact
                {
                    Name = nameTextBox.Text,
                    City = cityTextBox.Text,
                    Sex = getCheckBoxSex(),
                    CreatedAt = DateTime.Now
                }
            );

            nameTextBox.Clear();
            cityTextBox.Clear();

            LoadAllContacts();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var updateForm = new ContactUpdateForm(selectContact()))
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
            if( deleteContact.deleteContact(selectContact().Id))
                MessageBox.Show("Contato deletar com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao deletar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadAllContacts();
        }

        private Contact selectContact()
        {
            if (listContactsBox.SelectedItem != null)
            {
                return listContactsBox.SelectedItem as Contact;
            }

            MessageBox.Show("Selecione um contato na lista para alterar.",
                                "Nenhum Contato Selecionado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            return null;
        }
        private string getCheckBoxSex()
        {
            string sex = string.Empty;

            if (femaleCheckBox.Checked || maleCheckBox.Checked)
                sex = femaleCheckBox.Checked ? "F" : "M";
            return sex;
        }
        private void AddCityContactGroupsToReport(IEnumerable<IGrouping<string, Contact>> gruposPorCidade)
        {
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

                
            }
        }
        private void AddTotalContactsSummary(List<Contact> todosContatos, int totalHomens, int totalMulheres)
        {
            ListViewItem totalItem = new ListViewItem("Numero de contatos no banco de dados");
            totalItem.SubItems.Add(todosContatos.Count.ToString());
            totalItem.SubItems.Add(totalHomens.ToString());
            totalItem.SubItems.Add(totalMulheres.ToString());
            totalItem.Font = new Font(reportListView.Font, FontStyle.Bold);
            reportListView.Items.Add(totalItem);

            reportListView.Items.Add("");
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
        private void ConfigureReportListView()
        {
            if (reportListView == null) return;

            reportListView.Items.Clear();
            reportListView.Columns.Clear();

            reportListView.View = View.Details;

            reportListView.LabelEdit = false;
            reportListView.FullRowSelect = true;

            reportListView.Columns.Add("Descricao", 250, HorizontalAlignment.Left);
            reportListView.Columns.Add("Total", 70, HorizontalAlignment.Center);
            reportListView.Columns.Add("Homens", 70, HorizontalAlignment.Center);
            reportListView.Columns.Add("Mulheres", 70, HorizontalAlignment.Center);
        }

        private void groupSexBox_Enter(object sender, EventArgs e) {}
        private void cityTextBox_TextChanged(object sender, EventArgs e) {}
        private void nameTextBox_TextChanged(object sender, EventArgs e) {}
        private void label2_Click(object sender, EventArgs e) {}
        private void reportListView_SelectedIndexChanged_1(object sender, EventArgs e) {}
    }
}
