
namespace carteiravacina.Models
{
    public class Racas
    {
        public Racas(){}
        public Racas(int idRaca, int idEspecie, string descricaoRaca, string porteRaca, string crRaca)
        {
            this.IdRaca = idRaca;
            this.IdEspecie = idEspecie;
            this.DescricaoRaca = descricaoRaca;
            this.PorteRaca = porteRaca;
            this.crRaca = crRaca;

        }
        public int IdRaca { get; set; }
        public int IdEspecie { get; set; }
        public string DescricaoRaca { get; set; }
        public string PorteRaca { get; set; }
        public string crRaca { get; set; }
    }
}