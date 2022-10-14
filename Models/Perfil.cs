
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace carteiravacina.Models
{
    public class Perfil
    {
        public Perfil(int idCodigo, string descricao)
        {
            this.IdCodigo = idCodigo;
            this.descricao = descricao;
        }
        public int IdCodigo { get; set; }
        public string descricao { get; set; }

        [NotMapped]
        public List<Login> Logins { get; set; }
    }
}