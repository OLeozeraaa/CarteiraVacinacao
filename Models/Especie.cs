
namespace carteiravacina.Models
{
    public class Especie
    {
        public Especie(int idEspecie, string especieAnimal, string grupoAnimal)
        {
            this.IdEspecie = idEspecie;
            this.EspecieAnimal = especieAnimal;
            this.GrupoAnimal = grupoAnimal;

        }
        public int IdEspecie { get; set; }
        public string EspecieAnimal { get; set; }
        public string GrupoAnimal { get; set; }
    }
}