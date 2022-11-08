using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class Carteira
    {
        public Carteira(int id, int animalIdAnimal)
        {
            this.Id = id;
            this.AnimalIdAnimal = animalIdAnimal;
        }
        public int Id { get; set; }
        public int AnimalIdAnimal { get; set; }

        /* [ForeignKey("PetName")]
        public virtual Animal Animal { get; set; } */
    }
}