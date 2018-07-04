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
    /// Lógica interna para JanelaFormularioEmpresa.xaml
    /// </summary>
    public partial class JanelaFormularioEmpresa : Window, INotifyPropertyChanged
    {

        /*
        Listas dos itens declarados;
            */
        public IList<PessoaJuridica> PessoasJuridicas { get; set; }
        private ModelSapato ctx = new ModelSapato();

        /*Declaração da classe PessoaJuridica*/
        private PessoaJuridica _PessoaJuridica = new PessoaJuridica();
        public PessoaJuridica pessoaselecionada
        {
            get
            {
                return _PessoaJuridica;
            }
            set
            {
                _PessoaJuridica = value;
                this.NotifyPropertyEvent("pessoaselecionada");

            }
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
        /*
            Construtor inicializa as interfaces e traz o que tem na base de dados;
         */
        public JanelaFormularioEmpresa()
        {
            InitializeComponent();
            this.PessoasJuridicas = ctx.PessoasJuridicas.ToList();
            this.DataContext = this;
          
            
        }
        
        /*OkButton verifica se o pessoaselecionada está sendo criado, ou, está sendo editado*/
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (pessoaselecionada.Id <= 0)
            {
                
                ctx.PessoasJuridicas.Add(pessoaselecionada);
                String PFSelecionada = pessoaselecionada.Nome.ToString();
                MessageBox.Show("Sapato: " + PFSelecionada + " Adicionado com Sucesso!");
                ctx.SaveChanges();
                this.Close();
            }
            else
            {
                PessoaJuridica PessoalSalva = ctx.PessoasJuridicas.Find(pessoaselecionada.Id);
                PessoalSalva.Id = pessoaselecionada.Id;
                PessoalSalva.RazaoSocial = pessoaselecionada.RazaoSocial;
                PessoalSalva.Cnpj = pessoaselecionada.Cnpj;
                PessoalSalva.NomeRua = pessoaselecionada.NomeRua;
                PessoalSalva.NumeroResidencial = pessoaselecionada.NumeroResidencial;
                PessoalSalva.NomeBairro = pessoaselecionada.NomeBairro;
                PessoalSalva.NomeCidade = pessoaselecionada.NomeCidade;
                PessoalSalva.NomeEstado = pessoaselecionada.NomeEstado;
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
            foreach (PessoaJuridica p in e.RemovedItems)
            {
                ctx.PessoasJuridicas.Remove(p);
            }
        }
    }
}
