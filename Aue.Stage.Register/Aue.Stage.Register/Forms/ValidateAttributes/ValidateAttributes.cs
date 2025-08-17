using Aue.Stage.Register.Exceptions;
using Aue.Stage.Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aue.Stage.Register.Service
{
    class ValidateAttributes
    {
        public void validateAttributes(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ValidationException("Porfavor Preencha o Campos de Nome.");

            if (contact.Name.Any(char.IsDigit))
                throw new ValidationException("O campo 'Nome' não pode conter Numeros.");

            if (string.IsNullOrWhiteSpace(contact.Sex))
                throw new ValidationException("Porfavor Selecione Algum Sexo.");

            if (string.IsNullOrWhiteSpace(contact.City))
                throw new ValidationException("Porfavor Preencha o Campo de Cidade.");

            if (contact.City.Any(char.IsDigit))
                throw new ValidationException("O campo 'Nome' não pode conter Numeros.");

        }
    }
}
