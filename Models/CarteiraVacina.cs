using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class CarteiraVacina
    {
        public CarteiraVacina(int idCarteira, DateTime dataVacina, string medicamento, string tipoVacina, DateTime proximaVacina, int animalIdAnimal)
        {
            this.IdCarteira = idCarteira;
            this.dataVacina = dataVacina;
            this.Medicamento = medicamento;
            this.TipoVacina = tipoVacina;
            this.ProximaVacina = proximaVacina;
            this.AnimalIdAnimal = animalIdAnimal;

        }
        public int IdCarteira { get; set; }
        public DateTime dataVacina { get; set; }
        public string Medicamento { get; set; }
        public string TipoVacina { get; set; }
        public DateTime ProximaVacina { get; set; }
        public int AnimalIdAnimal { get; set; }
    }
}