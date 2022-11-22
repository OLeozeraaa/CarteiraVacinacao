using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinaca.Models
{
    public class Desaparecido
    {
        public Desaparecido(int id, string nome, int idEspecie, int idRaca, DateTime dtDesaparecimento, string lugar, string dono, string telefone, int idAnimal, string foto)
        {
            this.Id = id;
            this.Nome = nome;
            this.IdEspecie = idEspecie;
            this.IdRaca = idRaca;
            this.DtDesaparecimento = dtDesaparecimento;
            this.Lugar = lugar;
            this.Dono = dono;
            this.Telefone = telefone;
            this.IdAnimal = idAnimal;
            this.Foto = foto;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEspecie { get; set;}
        public int IdRaca { get; set; }
        public DateTime DtDesaparecimento { get; set; }
        public string Dono { get; set; }
        public string Lugar { get; set; }
        public string Telefone { get; set; }
        public int IdAnimal { get; set; }
        public string Foto { get; set; }
    }
}