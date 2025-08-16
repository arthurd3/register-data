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

namespace Aue.Stage.Register.Forms
{
    public partial class ContactUpdateForm : Form
    {
        private readonly Contact contactToUpdate;
        private readonly UpdateContact updateContactService;

        public ContactUpdateForm (Contact contactToUpdate)
        {
            InitializeComponent();
            LoadContactData();
            this.contactToUpdate = contactToUpdate;
            updateContactService = new UpdateContact();
        }
        private void LoadContactData()
        {
            nameTextBox.Text = contactToUpdate.Name;
            cityTextBox.Text = contactToUpdate.City;

            if (contactToUpdate.Sex == "M")
                maleCheckBox.Checked = true;
            else
                femaleCheckBox.Checked = true;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            contactToUpdate.Name = nameTextBox.Text;
            contactToUpdate.City = cityTextBox.Text;
            contactToUpdate.Sex = maleCheckBox.Checked ? "M" : "F";

            bool success = updateContactService.updateContact(contactToUpdate);

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possível atualizar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
                femaleCheckBox.Checked = false;
        }
        private void femaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
                maleCheckBox.Checked = false;
        }

        private void UpdateForm_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }   
        private void Sexo_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

    }
}
