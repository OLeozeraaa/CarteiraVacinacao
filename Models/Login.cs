
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models
{
    public class Login
    {
        public Login(string username, string passwordString, string tipoPerfil, int id)
        {
            this.username = username;
            this.PasswordString = passwordString;
            this.TipoPerfil = tipoPerfil;
            this.Id = id;

        }
        public string username { get; set; }
        public string PasswordString { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string TipoPerfil { get; set; }

        [NotMapped]
        public int Id { get; set; }
    }
}