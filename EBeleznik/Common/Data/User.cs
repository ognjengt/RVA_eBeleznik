using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Grupe { get; set; }
        public bool Admin { get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public User(string username, string password, string Ime, string Prezime, string grupe, bool admin)
        {
            this.Username = username;
            this.Password = password;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Grupe = grupe;
            this.Admin = admin;
        }
        public User() { }
    }
}
