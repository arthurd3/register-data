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
        private readonly ValidateAttributes validateAttributes;

        public ContactUpdateForm (Contact contactToUpdate)
        {
            InitializeComponent();
            this.contactToUpdate = contactToUpdate;
            updateContactService = new UpdateContact();
            validateAttributes = new ValidateAttributes();
            LoadContactData();
            
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
            contactToUpdate.Sex = getCheckBoxSex();

            if(!validateAttributes.validateAttributes(contactToUpdate))
                return;

            if (!updateContactService.updateContact(contactToUpdate))
                MessageBox.Show("Nao foi possível atualizar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Contato atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();

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
        private string getCheckBoxSex()
        {
            string sex = string.Empty;

            if (femaleCheckBox.Checked || maleCheckBox.Checked)
                sex = femaleCheckBox.Checked ? "F" : "M";
            return sex;
        }
        private void UpdateForm_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }   
        private void Sexo_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

    }
}
