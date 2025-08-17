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
        public UpdateContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }
        public bool updateContact(Contact contact)
        {
            return repoGateway.update(contact);
        }
    }
}
