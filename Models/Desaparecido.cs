using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinaca.Models
{
    public class Desaparecido
    {
        public Desaparecido(int id, DateTime? dtDesaparecimento, string lugar, string dono, string telefone, int idAnimal)
        {
            this.Id = id;
            this.DtDesaparecimento = dtDesaparecimento;
            this.Lugar = lugar;
            this.Dono = dono;
            this.Telefone = telefone;
            this.IdAnimal = idAnimal;
        }
        public int Id { get; set; }
        public DateTime? DtDesaparecimento { get; set; }
        public string Dono { get; set; }
        public string Lugar { get; set; }
        public string Telefone { get; set; }
        public int IdAnimal { get; set; }
    }
}