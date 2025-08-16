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
    class UpdateContact
    {
        private ContactRepositoryGateway repoGateway;
        private ValidateAttributes validateAttributes;
        public UpdateContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
            validateAttributes = new ValidateAttributes();
        }

        public void updateContact(Contact contact)
        {
            if(validateAttributes.validateAttributes(contact))
            {
                if (repoGateway.Update(contact))
                {
                    MessageBox.Show("Contato alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                MessageBox.Show("Nao foi possível atualizar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
