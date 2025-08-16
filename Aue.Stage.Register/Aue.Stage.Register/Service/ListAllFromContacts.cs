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
    public class ListAllFromContacts
    {
        private ContactRepositoryGateway repoGateway;

        public ListAllFromContacts()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public List<Contact> listAllContact()
        {
            var allContatcs = repoGateway.getAll();

            if(allContatcs.DefaultIfEmpty().Count() > 0)
                return allContatcs.ToList();
         
            return new List<Contact>();

        }
    }
}
