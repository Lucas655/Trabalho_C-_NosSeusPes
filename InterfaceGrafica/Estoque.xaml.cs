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
    /// Lógica interna para Estoque.xaml
    /// </summary>
    public partial class Estoque : Window, INotifyPropertyChanged
    {

        ModelSapato ctx = new ModelSapato();        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyEvent(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

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

        private String _Busca;
        public String Busca
        {
            get
            {
                return _Busca;
            }
            set
            {
                _Busca = value;
                this.NotifyPropertyEvent("Busca");
            }
        }

        private IList<Sapato> _Sapatos;
        public IList<Sapato> Sapatos
        {
            get
            {
                return _Sapatos;
            }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyEvent("Sapatos");
            }
        }

        public Estoque()
        {
            InitializeComponent();            
            this.DataContext = this;
            this.Sapatos = ctx.Sapatos.ToList();
            
        }

        private void Botaopesquisa_Click(object sender, RoutedEventArgs e)
        {
            ModelSapato ctx = new ModelSapato();
            this.Sapatos = ctx.Sapatos.Where(Sapato => Sapato.NomeSapato.Contains(Busca)).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
