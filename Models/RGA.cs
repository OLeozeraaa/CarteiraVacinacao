using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinacao.Models
{
    public class RGA
    {
        public RGA(int idRGA, int idAnimal, /*string nome, int idEspecie, int idRaca, int idSexo, DateTime dtNascimento, string pelagem,*/ string assinatura, string pata, int chip, int rga, string foto, DateTime? dataAdicao)
        {
            this.IdRGA = idRGA;
            this.IdAnimal = idAnimal;
            this.Chip = chip;
            this.Rga = rga;
            this.Assinatura = assinatura;
            this.Pata = pata;
            this.Foto = foto;
            this.DataAdicao = dataAdicao;
           /*  this.Nome = nome;
            this.IdEspecie = idEspecie;
            this.IdRaca = idRaca;
            this.IdSexo = idSexo;
            this.DtNascimento = dtNascimento;
            this.Pelagem = pelagem; */
        }
        public int IdRGA { get; set; }
        public int IdAnimal { get; set; }
        public int Chip { get; set; }
        public int Rga { get; set; }
        public string Assinatura { get; set; }
        public string Pata { get; set; }
        public string Foto { get; set; }
        public DateTime? DataAdicao { get; set; }
        //public string Nome { get; set; }
        //public int IdEspecie { get; set;}
        //public int IdRaca { get; set; }
        //public int IdSexo { get; set; }
        //public DateTime DtNascimento { get; set; }
        //public string Pelagem { get; set; }
        //public byte[] Assinatura { get; set; }
        //public byte[] Pata { get; set; }
        //public byte[] Foto { get; set; }
    }
}