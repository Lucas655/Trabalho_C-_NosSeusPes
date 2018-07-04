using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaGerenciamentoSapatos
{
   public class PessoaJuridica : Pessoa
    {      

        public String RazaoSocial { get; set; }	
        public String Cnpj { get; set; }	
		public String NomeRua { get; set; }		
		public String NomeBairro { get; set; }	
		public String NumeroResidencial { get; set; }		
		public String NomeCidade { get; set; }	
		public String NomeEstado { get; set; }        
    }
}
