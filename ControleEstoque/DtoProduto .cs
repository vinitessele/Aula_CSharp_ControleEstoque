using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque
{
 [Table("produto", Schema="public")]
    public class DtoProduto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public decimal? valorCusto { get; set; }
        public decimal? valorVenda { get; set; }
        public decimal? quantidade { get; set; }
    }
}
