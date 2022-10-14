
namespace carteiravacina.Models
{
    public class Tutor
    {
        public Tutor(int idTutor, int cpfTutor, string nomeTutor, string enderecoTutor, int numeroTutor, string complementoTutor, string bairroTutor, string municipioTutor, string ufTutor, string email, int crm)
        {
            this.IdTutor = idTutor;
            this.cpfTutor = cpfTutor;
            this.NomeTutor = nomeTutor;
            this.EnderecoTutor = enderecoTutor;
            this.NumeroTutor = numeroTutor;
            this.ComplementoTutor = complementoTutor;
            this.BairroTutor = bairroTutor;
            this.MunicipioTutor = municipioTutor;
            this.ufTutor = ufTutor;
            this.Email = email;
            this.crm = crm;
        }
        public int IdTutor { get; set; }
        public int cpfTutor { get; set; }
        public string NomeTutor { get; set; }
        public string EnderecoTutor { get; set; }
        public int NumeroTutor { get; set; }
        public string ComplementoTutor { get; set; }
        public string BairroTutor { get; set; }
        public string MunicipioTutor { get; set; }
        public string ufTutor { get; set; }
        public string Email { get; set; }
        public int crm { get; set; }
        public Perfil Perfil { get; set; }
    }
}