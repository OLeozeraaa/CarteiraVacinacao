using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class Carteira
    {
        public Carteira(int id, int animalIdAnimal, DateTime? dataAdicao)
        {
            this.Id = id;
            this.AnimalIdAnimal = animalIdAnimal;
            this.DataAdicao = dataAdicao;
        }
        public int Id { get; set; }
        public int AnimalIdAnimal { get; set; }
        public DateTime? DataAdicao { get; set; }
    }
}