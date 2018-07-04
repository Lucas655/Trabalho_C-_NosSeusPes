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
    /// Lógica interna para ListaClientes.xaml
    /// </summary>
    public partial class ListaClientes : Window, INotifyPropertyChanged
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

        private PessoaFisica _Pfisica = new PessoaFisica();
        public PessoaFisica PessoasFisicaSelecionada
        {
            get
            {
                return _Pfisica;
            }
            set
            {
                _Pfisica = value;
                this.NotifyPropertyEvent("PessoasFisicaSelecionada");
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

        private IList<PessoaFisica> _PessoasFisicas;
        public IList<PessoaFisica> PessoasFisicas
        {
            get
            {
                return _PessoasFisicas;
            }
            set
            {
                _PessoasFisicas = value;
                this.NotifyPropertyEvent("PessoasFisicas");
            }
        }


        public ListaClientes()
        {
            InitializeComponent();
            this.DataContext = this;
            this.PessoasFisicas = ctx.PessoasFisicas.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {
            ModelSapato ctx = new ModelSapato();
            this.PessoasFisicas = ctx.PessoasFisicas.Where(Pessoa => Pessoa.Nome.Contains(Busca)).ToList();
        }
    }
}
