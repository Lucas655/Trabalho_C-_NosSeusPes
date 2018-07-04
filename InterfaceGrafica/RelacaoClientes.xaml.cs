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
    /// Lógica interna para RelacaoClientes.xaml
    /// </summary>
    public partial class RelacaoClientes : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyEvent(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        ModelSapato ctx = new ModelSapato();

        private PessoaFisica _Pessoaf = new PessoaFisica();
        public PessoaFisica PfSelecionada
        {
            get
            {
                return _Pessoaf;

            }
            set
            {
                _Pessoaf = value;
                this.NotifyPropertyEvent("PfSelecionada");
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

        public RelacaoClientes()
        {
            InitializeComponent();
            this.DataContext = this;
            this.PessoasFisicas = ctx.PessoasFisicas.ToList();
        }
               
    }
}
