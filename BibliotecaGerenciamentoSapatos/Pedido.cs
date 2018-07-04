using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
   public class Pedido
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Pessoa Pessoa { get; set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
      

    }
}
