using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class Carteira
    {
        public Carteira(int id, string animal)
        {
            this.Id = id;
            this.animal = animal;

        }
        public int Id { get; set; }
        public string animal { get; set; }
    }
}