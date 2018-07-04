namespace BibliotecaGerenciamentoSapatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    //Efetua as Conexões com o banco de dados herdando a DBCONTEXT para gerenciar;
    public class ModelSapato : DbContext
    {
        public ModelSapato()
            : base("name=ModelSapato")
        {
        }
        public virtual DbSet<Sapato> Sapatos { get; set; }       
        public virtual DbSet<Cor> Cores { get; set; }        
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Tamanho> Tamanhos { get; set; }       
        public virtual DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public virtual DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public virtual DbSet<ItemPedido> ItensPedido { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}