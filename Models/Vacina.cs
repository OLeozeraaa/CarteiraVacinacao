using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models

{
    public class Vacina
    {
        public Vacina(int idVacina, DateTime dataVacina, string medicamento, int carteiraId, DateTime proximaVacina)
        {
            this.IdVacina = idVacina;
            this.DataVacina = dataVacina;
            this.ProximaVacina = proximaVacina;
            this.Medicamento = medicamento;
            this.CarteiraId = carteiraId;
        }
        public int IdVacina { get; set; }
        public DateTime DataVacina { get; set; }
        public DateTime ProximaVacina { get; set; }
        public string Medicamento { get; set; }
        public int CarteiraId { get; set; }
        [ForeignKey("CarteiraId")]
        public virtual Carteira Carteira { get; set; }
    }
}