using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aue.Stage.Register.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public char Sex { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }

}
