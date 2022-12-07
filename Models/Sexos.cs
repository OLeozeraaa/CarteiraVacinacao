
namespace carteiravacina.Models
{
    public class Sexos
    {
        public Sexos(int idSexo, string dsSexo)
        {
            this.idSexo = idSexo;
            this.dsSexo = dsSexo;

        }
        public int idSexo { get; set; }
        public string dsSexo { get; set; }
    }
}