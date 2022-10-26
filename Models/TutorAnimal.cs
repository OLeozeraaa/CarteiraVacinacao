using System;

namespace carteiravacina.Models
{
    public class TutorAnimal
    {
        public TutorAnimal(int idTutor, int idAnimal, DateTime dataInicio)
        {
            this.IdTutor = idTutor;
            this.IdAnimal = idAnimal;
            this.dataInicio = dataInicio;

        }
        public int IdTutor { get; set; }
        public int IdAnimal { get; set; }
        public DateTime dataInicio { get; set; }
    }
}