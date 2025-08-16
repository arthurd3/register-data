using Aue.Stage.Register.DataAccess;
using Aue.Stage.Register.Gateway;
using Aue.Stage.Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aue.Stage.Register.Service
{
    class CreateContact
    {
        private ContactRepositoryGateway repoGateway;

        public CreateContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public bool createContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                MessageBox.Show("Porfavor Preencha o Campos de Nome.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(contact.Sex))
            {
                MessageBox.Show("Porfavor Selecione Algum Sexo.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(contact.City))
            {
                MessageBox.Show("Porfavor Preencha o Campo de Cidade.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if(repoGateway.Create(contact))
                return true;
           
            MessageBox.Show("Nao foi possível criar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
           
        }
    }
}
