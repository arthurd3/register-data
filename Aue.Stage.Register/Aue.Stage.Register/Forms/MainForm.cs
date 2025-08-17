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
        private ValidateAttributes validateAttributes;

        public MainForm()
        {
            createContact = new CreateContact();
            deleteContact = new DeleteContact();
            listAllFromContact = new ListAllFromContacts();
            validateAttributes = new ValidateAttributes();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadAllContacts();
            configureReportListView();
        }

        private void loadAllContacts()
        {
            try
            {
                listContactsBox.DataSource = null;
                listContactsBox.DataSource = listAllFromContact.listAllContact();
                listContactsBox.DisplayMember = "Name";
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void countContactByCityButton_Click(object sender, EventArgs e)
        {
            var todosContatos = listAllFromContact.listAllContact();

            reportListView.Items.Clear();
            reportListView.Groups.Clear();

            int totalHomens = todosContatos.Count(c => c.Sex == "M");
            int totalMulheres = todosContatos.Count(c => c.Sex == "F");

            addTotalContactsSummary(todosContatos, totalHomens, totalMulheres);

            var gruposPorCidade = todosContatos.GroupBy(contato => contato.City);

            addCityContactGroupsToReport(gruposPorCidade);
        }

        private void includeButton_Click(object sender, EventArgs e)
        {

            var contactToCreate = new Contact
            {
                Name = nameTextBox.Text,
                City = cityTextBox.Text,
                Sex = getCheckBoxSex(),
                CreatedAt = DateTime.Now
            };

            if (!validateAttributes.validateAttributes(contactToCreate))
                return;

            if (!createContact.createContact(contactToCreate))
            {
                MessageBox.Show("Erro ao adicionar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Contato adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            nameTextBox.Clear();
            cityTextBox.Clear();

            femaleCheckBox.Checked = false;
            maleCheckBox.Checked = false;

            loadAllContacts();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var contactToUpdate = selectContact();

            using (var updateForm = new ContactUpdateForm(contactToUpdate))
            {
                var result = updateForm.ShowDialog();

                loadAllContacts();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            if (deleteContact.deleteContact(selectContact().Id))
            {
                MessageBox.Show("Contato deletar com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAllContacts();
            }
            else
                MessageBox.Show("Erro ao deletar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private void addCityContactGroupsToReport(IEnumerable<IGrouping<string, Contact>> gruposPorCidade)
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
        private void addTotalContactsSummary(List<Contact> todosContatos, int totalHomens, int totalMulheres)
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
        private void configureReportListView()
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
