using BibliotecaGerenciamentoSapatos;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfaceGrafica
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender == GProdutos )
            {
                JanelaFormularioSapatos JanelaProdutos = new JanelaFormularioSapatos();                
                JanelaProdutos.ShowDialog();
            }
            else if(sender == GPessoas)
            {
                JanelaFormularioPessoa JanelaPessoas = new JanelaFormularioPessoa();
                JanelaPessoas.ShowDialog();
            }
            else if(sender == GEmpresas)
            {
                JanelaFormularioEmpresa JanelaEmpresas = new JanelaFormularioEmpresa();
                JanelaEmpresas.ShowDialog();
            }
            else if (sender == GPedidos)
            {
                JanelaFormularioPedidos JanelaPedidos = new JanelaFormularioPedidos();
                JanelaPedidos.ShowDialog();
            }
            else if (sender == GEstoque)
            {
                Estoque Estoque = new Estoque();
                Estoque.ShowDialog();
            }           
            else if (sender == GRelatorioPf)
            {
                ModelSapato ctx = new ModelSapato();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "RelatorioPessoaFisica";
                dlg.DefaultExt = "xlsx";
                dlg.Filter = "Excel (.xlsx)|*.xlsx";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {                   
                    ClosedXMLClientes.CriarPlanilhaCliente(ctx.PessoasFisicas.ToList(), dlg.FileName);
                }
            }
            else if (sender == GRelatorioPj)
            {
                ModelSapato ctx = new ModelSapato();
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "RelatorioPessoaJuridica";
                dlg.DefaultExt = "xlsx";
                dlg.Filter = "Excel (.xlsx)|*.xlsx";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {                    
                    ClosedXMLEmpresa.CriarPlanilhaEmpresa(ctx.PessoasJuridicas.ToList(), dlg.FileName);
                }
            }

        }
               
    }
}
