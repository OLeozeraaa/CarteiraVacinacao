
namespace carteiravacina.Models
{
    public class Situacao
    {
        public Situacao(){}
        public Situacao(int idSituacao, string descricaoSituacao)
        {
            this.IdSituacao = idSituacao;
            this.DescricaoSituacao = descricaoSituacao;

        }
        public int IdSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
    }
}