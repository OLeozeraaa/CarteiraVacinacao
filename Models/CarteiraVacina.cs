using System;

namespace carteiravacina.Models

{
    public class CarteiraVacina
    {
        public CarteiraVacina(){}
        public CarteiraVacina(int idCarteira, DateTime dataVacina, string medicamento, string tipoVacina, DateTime proxVacina)
        {
            this.IdCarteira = idCarteira;
            this.dataVacina = dataVacina;
            this.Medicamento = medicamento;
            this.TipoVacina = tipoVacina;
            this.ProxVacina = proxVacina;

        }
        public int IdCarteira { get; set; }
        public DateTime dataVacina { get; set; }
        public string Medicamento { get; set; }
        public string TipoVacina { get; set; }
        public Animal Animal { get; set; }
        public DateTime ProxVacina { get; set; }
    }
}