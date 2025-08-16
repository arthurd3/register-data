using Aue.Stage.Register.DataAccess;
using Aue.Stage.Register.Gateway;
using Aue.Stage.Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aue.Stage.Register.Service
{
    public class ListAllFromContact
    {
        private ContactRepositoryGateway repoGateway;

        public ListAllFromContact()
        {
            repoGateway = new ContactRepositoryGatewayImpl();
        }

        public List<Contact> ListAllContact()
        {
            return repoGateway.GetAll();
        } 
    }
}
