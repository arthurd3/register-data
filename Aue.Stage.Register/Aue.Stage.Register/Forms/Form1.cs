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

namespace Aue.Stage.Register
{

    public partial class Form1 : Form
    {
        private CreateContact createContact;
        private ListAllFromContact listAllFromContact;
        public Form1()
        {
            InitializeComponent();
            createContact = new CreateContact();
            listAllFromContact = new ListAllFromContact();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void includeButton_Click(object sender, EventArgs e)
        {
            char sex = ' ';

            if (femaleCheckBox.Checked || maleCheckBox.Checked)
                sex = femaleCheckBox.Checked ? 'F' : 'M';

            var contactToCreate = new Contact
            {
                Name = nameTextBox.Text,
                City = cityTextBox.Text,
                Sex = sex
            };

            createContact.createContact(contactToCreate);

            nameTextBox.Clear();
            cityTextBox.Clear();

            LoadAllContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllContacts();
        }

        private void groupSexBox_Enter(object sender, EventArgs e)
        {
            
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

        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void LoadAllContacts()
        {
            listBox1.DataSource = null;

            listBox1.DataSource = listAllFromContact.ListAllContact();

            listBox1.DisplayMember = "Name";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
