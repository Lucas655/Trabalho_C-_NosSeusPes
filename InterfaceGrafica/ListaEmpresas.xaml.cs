﻿using BibliotecaGerenciamentoSapatos;
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
    /// Lógica interna para ListaEmpresas.xaml
    /// </summary>
    public partial class ListaEmpresas : Window, INotifyPropertyChanged
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

        private PessoaJuridica _PJuridica = new PessoaJuridica();
        public PessoaJuridica PessoasJuridicaSelecionada
        {
            get
            {
                return _PJuridica;
            }
            set
            {
                _PJuridica = value;
                this.NotifyPropertyEvent("PessoasJuridicaSelecionada");
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

        private IList<PessoaJuridica> _PessoasJuridicas;
        public IList<PessoaJuridica> PessoasJuridicas
        {
            get
            {
                return _PessoasJuridicas;
            }
            set
            {
                _PessoasJuridicas = value;
                this.NotifyPropertyEvent("PessoasJuridicas");
            }
        }
        
        public ListaEmpresas()
        {
            InitializeComponent();
            this.DataContext = this;
            this.PessoasJuridicas = ctx.PessoasJuridicas.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {
            ModelSapato ctx = new ModelSapato();
            this.PessoasJuridicas = ctx.PessoasJuridicas.Where(Empresa => Empresa.Nome.Contains(Busca)).ToList();
        }
    }
}
