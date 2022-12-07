using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinaca.Models
{
    public class DesaparecidoSemRegistro
    {

        public DesaparecidoSemRegistro(int id, string nome, string especie, string raca, string lugar, string telefone, string foto, string dono)
        {
            this.Id = id;
            this.Nome = nome;
            this.Especie = especie;
            this.Raca = raca;
            this.Lugar = lugar;
            this.Telefone = telefone;
            this.Foto = foto;
            this.Dono = dono;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtDesaparecimento { get; set; }
        public string Lugar { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
        public string Dono { get; set; }


    }
}