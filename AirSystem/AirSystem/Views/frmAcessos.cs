using AirSystem.Database;
using AirSystem.Repositories;
using AirSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem.Views
{
    public partial class frmAcessos : Form
    {
        AcessoRepository acessoRepository = new AcessoRepository();
        public frmAcessos()
        {
            InitializeComponent();
        }

        string idioma = "";
        bool  crescente = false;


        public frmAcessos(string idioma)
        {
            InitializeComponent();

            if (idioma == "Inglês")
            {
                this.idioma = idioma;

                //button1.Text = "List User";
                //button2.Text = "List Planes";
                //button3.Text = "Manage Company";
                //button4.Text = "Manage Reports";
                //button5.Text = "Manage Planes";
            }
        }

        private void atualizaLista()
        {
            dgvAcessos.DataSource = null;

            List<Acesso> acessos = acessoRepository.BuscarTodos();

            List<AcessoViewModel> acessosFiltrados = new List<AcessoViewModel>();

            foreach (var item in acessos)
            {
                AcessoViewModel acessFiltro = new AcessoViewModel
                {
                    IdAcesso = item.IdAcesso,
                    NomeUsuario = item.Usuarios.Tx_Usuario,
                    DataEntrada = item.Dt_AcessoEntrada,
                    DataSaida = item.Dt_AcessoSaida
                };
                acessosFiltrados.Add(acessFiltro);
            }

           
            dgvAcessos.DataSource = acessosFiltrados;

            Contador();
        }

        private void Contador()
        {
            if (idioma != "Inglês")
            {
                lblQuantidade.Text = $"{dgvAcessos.RowCount} itens de {acessoRepository.BuscarTodos().Count}";
            }
            else
            {
                lblQuantidade.Text = $"{dgvAcessos.RowCount} items of {acessoRepository.BuscarTodos().Count}";

            }
        }

        private void frmAcessos_Load(object sender, EventArgs e)
        {
            atualizaLista();
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            dgvAcessos.DataSource = null;

            List<Acesso> acessos = acessoRepository.BuscarTodos();

            List<AcessoViewModel> acessosFiltrados = new List<AcessoViewModel>();


            foreach (var item in acessos)
            {
                AcessoViewModel acessFiltro = new AcessoViewModel
                {
                    IdAcesso = item.IdAcesso,
                    NomeUsuario = item.Usuarios.Tx_Usuario,
                    DataEntrada = item.Dt_AcessoEntrada,
                    DataSaida = item.Dt_AcessoSaida
                };
                acessosFiltrados.Add(acessFiltro);
            }

            dgvAcessos.DataSource = acessosFiltrados.FindAll(x => x.NomeUsuario.ToUpper().Contains(tbxFiltro.Text.ToUpper()));


            Contador();
        }

        private void dgvAcessos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {

                dgvAcessos.DataSource = null;

                List<Acesso> acessos = acessoRepository.BuscarTodos();

                List<AcessoViewModel> acessosFiltrados = new List<AcessoViewModel>();

                foreach (var item in acessos)
                {
                    AcessoViewModel acessFiltro = new AcessoViewModel
                    {
                        IdAcesso = item.IdAcesso,
                        NomeUsuario = item.Usuarios.Tx_Usuario,
                        DataEntrada = item.Dt_AcessoEntrada,
                        DataSaida = item.Dt_AcessoSaida
                    };
                    acessosFiltrados.Add(acessFiltro);
                }
                if (crescente)
                {
                    dgvAcessos.DataSource = acessosFiltrados.OrderBy(x => x.DataSaida).ToList();
                    crescente = false;

                }
                else
                {
                    dgvAcessos.DataSource = acessosFiltrados.OrderByDescending(x => x.DataSaida).ToList();
                    crescente = true;
                }
               

                Contador();
            }
        }
    }
}
