using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceBankAccount.ClassLib
{
    public abstract class Person : Entity
    {
        private string firstname;
        private string lastname;
        private string ssn;

        protected Person(string firstname, string lastname, string ssn)
        {
            Firstname = firstname;
            Lastname = lastname;
            Ssn = ssn;
        }

        protected Person(int id, string firstname, string lastname, string ssn)
            :base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Ssn = ssn;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                var validationResult = ValidateName(value);
                if (validationResult.isValid)
                {
                    firstname = value;
                }
                else
                {
                    throw new ArgumentException(validationResult.errMsg);
                }
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                var validationResult = ValidateName(value);
                if (validationResult.isValid)
                {
                    lastname = value;
                }
                else
                {
                    throw new ArgumentException(validationResult.errMsg);
                }
            }
        }
        public string Ssn
        {
            get
            {
                return ssn;
            }
            set
            {
                value.Replace(" ", "");
                value.Replace("-", "");
                var validationResult = ValidateName(value);
                if (validationResult.isValid)
                {
                    ssn = value;
                }
                else
                {
                    throw new ArgumentException(validationResult.errMsg);
                }
            }
        }

        public static (bool isValid, string errMsg) ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return (false, "Navnet kan ikke være tomt.");
            }
            else if (name.All(char.IsLetter) || name.All(char.IsPunctuation))
            {
                return (false, "Navnet kan kun indeholde bogstaver.");
            }
            else if (name.Length > 50)
            {
                return (false, "Navnet kan ikke bestå af mere end 50 tegn.");
            }
            else
            {
                return (true, string.Empty);
            }
        }
        public static (bool isValid, string errMsg) ValidateSsn(string ssn)
        {
            if (ssn.All(char.IsDigit))
            {
                return (false, "CPR kan kun indeholde tal.");
            }
            if (ssn.Length != 10)
            {
                return (false, "CPR skal bestå af 10 cifre.");
            }
            if (ssn[0] < 0 || ssn[0] > 3 || ssn[1] < 1 || ssn[2] < 0 || ssn[2] > 1 || ssn[3] < 1 || ssn[4] < 0 || ssn[5] < 0 || ssn[6] < 0 || ssn[7] < 0 || ssn[8] < 0 || ssn[9] < 0)
            {
                return (false, "Ugyldigt CPR");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}
