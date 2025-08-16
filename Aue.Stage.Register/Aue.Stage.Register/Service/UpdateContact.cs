using Aue.Stage.Register.DataAccess;
using Aue.Stage.Register.Gateway;
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
        public UpdateContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public bool updateContact(Models.Contact contact)
        {
            if(repoGateway.Update(contact))
               return true;

            MessageBox.Show("Nao foi possível atualizar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;   
        }
    }
}
