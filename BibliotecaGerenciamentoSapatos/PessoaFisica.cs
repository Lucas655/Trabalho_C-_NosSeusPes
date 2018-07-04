using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaGerenciamentoSapatos
{
    public class PessoaFisica : Pessoa
    {	          
        public String Cpf { get; set; }
        public DateTime DataNascimento { get; set; }       
    }
}
