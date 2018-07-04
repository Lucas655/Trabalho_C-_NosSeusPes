using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
    public class Facade
    {
        ModelSapato ctx = new ModelSapato();
        
        public IList<Sapato> ObterSapatos()
        {
           return ctx.Sapatos.ToList();
        }


        public IList<Cor> ObterCores()
        {          
            return ctx.Cores.ToList();
        }

        public IList<Tamanho> ObterTamanhos()
        {            
            return ctx.Tamanhos.ToList();
        }


        /*public IList<PessoaFisica> ObterClientes()
         {
             return ctx.PessoasFisicas.ToList();
         }

         public IList<PessoaJuridica> ObterClientesJ()
         {
             return ctx.PessoasJuridicas.ToList();
         }
         */
    }
}
