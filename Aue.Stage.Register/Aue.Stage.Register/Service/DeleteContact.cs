using Aue.Stage.Register.DataAccess;
using Aue.Stage.Register.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aue.Stage.Register.Service
{
    class DeleteContact
    {
        private ContactRepositoryGateway repoGateway;
        public DeleteContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public bool deleteContact(int contactId)
        {
            return repoGateway.Delete(contactId);
        }
    }
}
