using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaGerenciamentoSapatos
{
    public class Sapato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        
        public String NomeSapato { get; set; }
        public String TipoAmarracao { get; set; }        
        public String Material { get; set; }       
        public Double ValorSapato { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
        
        public Cor Cor { get; set; }
        public Tamanho Tamanho { get; set; }
    }
}
