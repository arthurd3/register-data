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
    class DeleteContact
    {
        private ContactRepositoryGateway repoGateway;
        public DeleteContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public void deleteContact(int contactId)
        {
            if(repoGateway.Delete(contactId))
                MessageBox.Show("Contato deletar com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao deletar o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
