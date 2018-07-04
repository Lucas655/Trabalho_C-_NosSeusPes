using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
   public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Double Valor { get; set; }

        public Sapato Sapato { get; set; }
        public Pedido Pedido { get; set; }
    }
}
