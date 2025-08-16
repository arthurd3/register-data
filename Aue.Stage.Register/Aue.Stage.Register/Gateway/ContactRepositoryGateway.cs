using Aue.Stage.Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aue.Stage.Register.Gateway
{
    interface ContactRepositoryGateway
    {
        bool Create(Contact contact);
        Contact GetById(int id);
        List<Contact> GetAll();
        bool Update(Contact contact);
        bool Delete(int id);
    }
}
