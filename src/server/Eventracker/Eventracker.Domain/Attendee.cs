using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Eventracker.Domain
{
    public class Attendee
    {
        public Attendee(string name, string email)
        {
            Contract.Requires<ArgumentOutOfRangeException>(name.Length > 3, "O nome deve conter pelo menos 3 caracteres.");
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(email), "O E-mail é obrigatório.");
            Contract.Requires<InvalidCastException>(new Regex(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$").IsMatch(email));

            this.Name = name;
            this.Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
