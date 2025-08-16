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
        private ValidateAttributes validateAttributes;
        public CreateContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
            validateAttributes = new ValidateAttributes();
        }

        public void createContact(Contact contact)
        {
  
            if(validateAttributes.validateAttributes(contact))
            {
                if (repoGateway.Create(contact))
                {
                    MessageBox.Show("Contato criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                  
                MessageBox.Show("Nao foi possível criar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
