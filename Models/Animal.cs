using System;
using System.Text.Json.Serialization;

namespace carteiravacina.Models
{
    
    public class Animal
    {
        public Animal(int idAnimal, string nome, DateTime dtNascimento, string pelagem, int idRGA, float peso)
        {
            this.IdAnimal = idAnimal;
            this.Nome = nome;
            this.dtNascimento = dtNascimento;
            this.Pelagem = pelagem;
            this.IdRGA = idRGA;
            this.peso = peso;

        }
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public Especie Especie { get; set;}
        public Racas Racas { get; set; }
        
        public DateTime dtNascimento { get; set; }
        public string Pelagem { get; set; }
        public Situacao Situacao { get; set; }
        public int IdRGA { get; set; }
        public float peso { get; set; }

        [JsonIgnore]
        public Sexos Sexos { get; set; }
    }
}