namespace BibliotecaGerenciamentoSapatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BibliotecaGerenciamentoSapatos.ModelSapato>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BibliotecaGerenciamentoSapatos.ModelSapato context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Cor c = new Cor();
            c.NomeCor = "Preto";

            Cor c2 = new Cor();
            c2.NomeCor = "Branco";

            Cor c3 = new Cor();
            c3.NomeCor = "Marrom";

            context.Cores.Add(c);
            context.Cores.Add(c2);
            context.Cores.Add(c3);

            Tamanho t = new Tamanho();
            t.TamanhoSapato = "39";

            Tamanho t2 = new Tamanho();
            t2.TamanhoSapato = "40";

            Tamanho t3 = new Tamanho();
            t3.TamanhoSapato = "41";

            context.Tamanhos.Add(t);
            context.Tamanhos.Add(t2);
            context.Tamanhos.Add(t3);

            context.SaveChanges();
        }
    }
}
