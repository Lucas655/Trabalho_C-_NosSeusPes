using BibliotecaGerenciamentoSapatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InterfaceGrafica
{
    /// <summary>
    /// Lógica interna para JanelaFormularioPessoa.xaml
    /// </summary>
    public partial class JanelaFormularioPessoa : Window, INotifyPropertyChanged

    {

        /*
        Listas dos itens declarados;
            */
        public IList<PessoaFisica> PessoasFisicas { get; set; }
        private ModelSapato ctx = new ModelSapato();


        /*
         Declaração da classe PessoaFisica;
             */
        private PessoaFisica _PessoaFisica = new PessoaFisica();
        public PessoaFisica pessoaselecionada
        {
            get
            {
                return _PessoaFisica;
            }
            set
            {
                _PessoaFisica = value;
                this.NotifyPropertyEvent("pessoaselecionada");

            }
        }
        /*
            Construtor inicializa as interfaces e traz o que tem na base de dados;
         */
        public JanelaFormularioPessoa()
        {
            InitializeComponent();
            this.PessoasFisicas = ctx.PessoasFisicas.ToList();
            this.DataContext = this;
        }


        /*
            Evento responsável por informar ao programa sempre que algum objeto é atualizado;
             */
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyEvent(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        /*OkButton verifica se o pessoaselecionada está sendo criado, ou, está sendo editado*/
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

            if (this.pessoaselecionada.Id <= 0)
            {
                ctx.PessoasFisicas.Add(pessoaselecionada);
                String PessoaAdicionada = pessoaselecionada.Nome.ToString();
                MessageBox.Show("Cliente: " + PessoaAdicionada + " Adicionado com Sucesso!");
                ctx.SaveChanges();
                this.Close();
            }
            else
            {
               // PessoaFisica PessoaSalva = ctx.Pessoas.Find(pessoaselecionada.Id);
              //  PessoaSalva.Nome= pessoaselecionada.Nome;
                //PessoaSalva.Cpf = pessoaselecionada.Cpf;
                //PessoaSalva.DataNascimento = pessoaselecionada.DataNascimento;
                MessageBox.Show("Cadastro Alterado!");
                ctx.SaveChanges();
            }           
        }
        /*
        Cancel button, fecha a janela aberta;
            */
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /*
       Remoção de itens do dataGrid
           */
        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PessoaFisica p in e.RemovedItems)
            {
               // ctx.PessoasFisicas.Remove(p);
            }
        }
    }
}
