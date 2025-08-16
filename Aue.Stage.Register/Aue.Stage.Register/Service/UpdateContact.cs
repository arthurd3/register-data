using Aue.Stage.Register.DataAccess;
using Aue.Stage.Register.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return repoGateway.Update(contact);
        }
    }
}
