using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinacao.Models
{
    public class RGA
    {
        public RGA(int idRGA, int idAnimal, string nome, int idEspecie, int idRaca, int idSexo, DateTime dtNascimento, string pelagem, string assinatura, string pata, int chip, int rga, string foto)
        {
            this.IdRGA = idRGA;
            this.IdAnimal = IdAnimal;
            this.Nome = nome;
            this.IdEspecie = idEspecie;
            this.IdRaca = idRaca;
            this.IdSexo = idSexo;
            this.DtNascimento = dtNascimento;
            this.Pelagem = pelagem;
            this.Assinatura = assinatura;
            this.Pata = pata;
            this.Chip = chip;
            this.Rga = rga;
            this.Foto = foto;
        }
        public int IdRGA { get; set; }
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public int IdEspecie { get; set;}
        public int IdRaca { get; set; }
        public int IdSexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Pelagem { get; set; }
        //public byte[] Assinatura { get; set; }
        public string Assinatura { get; set; }
        //public byte[] Pata { get; set; }
        public string Pata { get; set; }
        public int Chip { get; set; }
        public int Rga { get; set; }
        //public byte[] Foto { get; set; }
        public string Foto { get; set; }
    }
}