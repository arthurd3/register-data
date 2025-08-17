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
        bool create(Contact contact);

        List<Contact> getAll();

        bool update(Contact contact);

        bool delete(int id);

    }
}
