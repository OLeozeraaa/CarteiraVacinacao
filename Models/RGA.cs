using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteiraVacinacao.Models
{
    public class RGA
    {
        public RGA(int idRGA, int idAnimal, int chip, int rga, string assinatura, string pata, string foto)
        {
            this.IdRGA = idRGA;
            this.IdAnimal = idAnimal;
            this.Chip = chip;
            this.Rga = rga;
            this.Assinatura = assinatura;
            this.Pata = pata;
            this.Foto = foto;
        }
        public int IdRGA { get; set; }
        public int IdAnimal { get; set; }
        public int Chip { get; set; }
        public int Rga { get; set; }
        public string Assinatura { get; set; }
        public string Pata { get; set; }
        public string Foto { get; set; }
        public DateTime? DataAdicao { get; set; }
    }
}