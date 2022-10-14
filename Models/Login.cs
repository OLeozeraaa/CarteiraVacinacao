
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models
{
    public class Login
    {
        public Login(int id, string username, byte[] passwordHash, string passwordString, byte[] passwordSalt)
        {
             this.Id = id;
            this.username = username;
            this.PasswordHash = passwordHash;
            this.PasswordString = passwordString;
            this.PasswordSalt = passwordSalt;

        }
       
        public string username { get; set; }
        public string PasswordString { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [NotMapped]
         public int Id { get; set; }
    }
}