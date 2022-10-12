
namespace carteiravacina.Models
{
    public class Login
    {
        public Login(){}
        public Login(int id, string username, byte[] passwordHash, string passwordString, byte[] passwordSalt)
        {
             this.Id = id;
            this.username = username;
            this.PasswordHash = passwordHash;
            this.PasswordString = passwordString;
            this.PasswordSalt = passwordSalt;

        }
        public int Id { get; set; }
        public string username { get; set; }
        public string PasswordString { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}