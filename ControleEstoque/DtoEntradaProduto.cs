using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace ControleEstoque
{
    [Table("entradaproduto", Schema = "public")]
    public class DtoEntradaProduto
    {
        [Key]
        public int id { get; set; }
        public int idproduto { get; set; }
        public decimal qteproduto { get; set; }
        public decimal? vlrunitario { get; set; }
        public decimal? vlrtotal { get; set; }
        public DateTime? dtentrada { get; set; }
    }
}
