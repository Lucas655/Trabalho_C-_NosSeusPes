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
    /// Lógica interna para JanelaFormularioSapatos.xaml
    /// </summary>
    public partial class JanelaFormularioSapatos : Window, INotifyPropertyChanged
    {

        /*
         Listas dos itens declarados;
             */
        public IList<Sapato> Sapatos { get; set; }
        public IList<Cor> Cores { get; set; }
        public IList<Tamanho> Tamanhos { get; set; }
        private ModelSapato ctx = new ModelSapato();

        /*
         Declaração da classe sapato;
             */
        private Sapato _Sapato = new Sapato();
        public Sapato SapatoSelecionado
        {
            get
            {
                return _Sapato;
            }
            set
            {
                _Sapato = value;
                this.NotifyPropertyEvent("SapatoSelecionado");
            }
        }
        /*
            Construtor inicializa as interfaces e traz o que tem na base de dados;
         */
        public JanelaFormularioSapatos()
        {
            InitializeComponent();
            //Define que está fazendo alterações na própria classe;
            DataContext = this;

            this.Sapatos = ctx.Sapatos.ToList();
            this.Cores = ctx.Cores.ToList();
            this.Tamanhos = ctx.Tamanhos.ToList();

        }
        /*OkButton verifica se o sapatoSelecionado está sendo criado, ou, está sendo editado*/
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (SapatoSelecionado.Id <= 0)
            {
                ctx.Sapatos.Add(SapatoSelecionado);
                String SapatoAdicionado = SapatoSelecionado.NomeSapato.ToString();
                MessageBox.Show("Sapato: " + SapatoAdicionado + " Adicionado com Sucesso!");
                ctx.SaveChanges();
                this.Close();
            }
            else {              
                    Sapato SapatoSave = ctx.Sapatos.Find(SapatoSelecionado.Id);
                    SapatoSave.Id = SapatoSelecionado.Id;
                    SapatoSave.NomeSapato = SapatoSelecionado.NomeSapato;
                    SapatoSave.Material = SapatoSelecionado.Material;
                    SapatoSave.TipoAmarracao = SapatoSelecionado.TipoAmarracao;
                    SapatoSave.ValorSapato = SapatoSelecionado.ValorSapato;
                    MessageBox.Show("Item Alterado!");
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
         Remoção de itens do dataGrid
             */
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Sapato s in e.RemovedItems)
            {
                ctx.Sapatos.Remove(s);
            }           
        }
    }
}
