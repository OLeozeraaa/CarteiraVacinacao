
namespace carteiravacina.Models
{
    public class Racas
    {
        public Racas(int idRaca, int idEspecie, string dsRaca, string ptRaca, string crRaca)
        {
            this.idRaca = idRaca;
            this.idEspecie = idEspecie;
            this.dsRaca = dsRaca;
            this.ptRaca = ptRaca;
            this.crRaca = crRaca;

        }
        public int idRaca { get; set; }
        public int idEspecie { get; set; }
        public string dsRaca { get; set; }
        public string ptRaca { get; set; }
        public string crRaca { get; set; }
    }
}