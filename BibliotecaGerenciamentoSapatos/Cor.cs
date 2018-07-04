using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
    public class Cor
    {		
	      
        public int Id{ get; set; }        
        public String NomeCor { get; set; }
        public virtual ICollection<Sapato> Sapatos { get; set; } = new List<Sapato>();
    }
}
