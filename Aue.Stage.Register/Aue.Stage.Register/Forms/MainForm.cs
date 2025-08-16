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
