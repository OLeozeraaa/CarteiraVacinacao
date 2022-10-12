
namespace carteiravacina.Models
{
    public class Perfil
    {
        public Perfil(){}
        public Perfil(int idCodigo, string descricao)
        {
            this.IdCodigo = idCodigo;
            this.descricao = descricao;
        }
        public int IdCodigo { get; set; }
        public string descricao { get; set; }
    }
}