
namespace carteiravacina.Models
{
    public class Sexos
    {
        public Sexos(){}
        public Sexos(int idSexo, string descricaoSexo)
        {
            this.IdSexo = idSexo;
            this.DescricaoSexo = descricaoSexo;

        }
        public int IdSexo { get; set; }
        public string DescricaoSexo { get; set; }
    }
}