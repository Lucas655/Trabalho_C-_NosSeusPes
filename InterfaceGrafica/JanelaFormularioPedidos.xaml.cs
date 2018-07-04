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
    /// Lógica interna para JanelaFormularioPedidos.xaml
    /// </summary>
    public partial class JanelaFormularioPedidos : Window, INotifyPropertyChanged
    {
        public IList<Tamanho> Tamanhos { get; set; }
        public IList<Cor> Cores { get; set; }
        public IList<Pedido> Pedidos { get; set; }
        public IList<Sapato> Sapatos { get; set; }        
        public IList<PessoaFisica> PessoasFisicas { get; set; } 
        private ModelSapato ctx = new ModelSapato();

        private Pedido _Pedido = new Pedido();     
        public Pedido PedidoSelecionado
        {
            get
            {
                return _Pedido;
            }
            set
            {                
                _Pedido = value;
                this.NotifyPropertyEvent("PedidoSelecionado");
            }
        }

        private ItemPedido _ItemPedido = new ItemPedido();
        public ItemPedido ItemPedidoSelecionado
        {
            get
            {
                return _ItemPedido;
            }
            set
            {
                _ItemPedido = value;
                this.NotifyPropertyEvent("ItemPedidoSelecionado");
            }
        }
        
        public JanelaFormularioPedidos()
        {
            InitializeComponent();

            this.Cores = ctx.Cores.ToList();
            this.Tamanhos = ctx.Tamanhos.ToList();
            this.Pedidos = ctx.Pedidos.ToList();
            this.PessoasFisicas = ctx.PessoasFisicas.ToList();
            this.Sapatos = ctx.Sapatos.ToList();            
            this.DataContext = this;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyEvent(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PedidoSelecionado.ItensPedido.Add(ItemPedidoSelecionado);
            ctx.Pedidos.Add(PedidoSelecionado);
            ctx.SaveChanges();
        }

        private void Button_ClickC(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
