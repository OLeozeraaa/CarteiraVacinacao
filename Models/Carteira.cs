using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class Carteira
    {
        public Carteira(int id, string petName)
        {
            this.Id = id;
            this.PetName = petName;
        }
        public int Id { get; set; }
        public string PetName { get; set; }

        /* [ForeignKey("PetName")]
        public virtual Animal Animal { get; set; } */
    }
}