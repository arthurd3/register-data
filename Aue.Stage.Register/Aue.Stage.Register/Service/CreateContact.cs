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
            return repoGateway.create(contact);
        }
    }
}
