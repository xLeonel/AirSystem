using AirSystem.Database;
using AirSystem.Models;
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
    public partial class frmListarUsuarios : Form
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        Usuarios userGrid = new Usuarios();

        string idioma = "";

        public frmListarUsuarios()
        {
            InitializeComponent();
        }

        public frmListarUsuarios(string idioma)
        {
            InitializeComponent();

            //traduçao form
            if (idioma == "Inglês")
            {
                this.idioma = idioma;

                lblNome.Text = "First Name";
                lblSobrenome.Text = "Last Name";
                lblEndereco.Text = "Adress";
                lblNascimento.Text = "Birthday";
                lblSenha.Text = "Password";
                lblUsuario.Text = "Username";
                label1.Text = "Name";

                cbxAdm.Text = "Administrator";
                btnAlterar.Text = "Change";
                btnRemover.Text = "Remove";
                btnSalvar.Text = "Save";
                btnDeletar.Text = "Delete";
                btnNovoUser.Text = "New User";
                btnVoltar.Text = "Back";
            }

        }

        private void frmListarUsuarios_Load(object sender, EventArgs e)
        {
            List<Usuarios> usuarios = usuarioRepository.BuscarTodos();

            atualizaLista();
        }

        private void atualizaLista()
        {
            dgvListaUsuario.DataSource = null;

            List<Usuarios> usuarios = usuarioRepository.BuscarTodos();

            List<UsuarioViewModel> userFiltro = new List<UsuarioViewModel>();

            foreach (var item in usuarios)
            {
                UsuarioViewModel usuarioFiltro = new UsuarioViewModel
                {
                    Id = item.IdUsuario,
                    Nome = item.Tx_Nome,
                    Sobrenome = item.Tx_Sobrenome,
                    IsAdm = item.IsAdmin
                };

                userFiltro.Add(usuarioFiltro);
            }

            dgvListaUsuario.DataSource = userFiltro;

            Contador();
        }

        private void Contador()
        {
            if (idioma != "Inglês")
            {
                lblQuantidade.Text = $"{dgvListaUsuario.RowCount} itens de {usuarioRepository.BuscarTodos().Count}"; 
            }
            else
            {
                lblQuantidade.Text = $"{dgvListaUsuario.RowCount} items of {usuarioRepository.BuscarTodos().Count}";

            }
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            dgvListaUsuario.DataSource = null;

            List<Usuarios> usuarios = usuarioRepository.BuscarTodos();

            List<UsuarioViewModel> userFiltro = new List<UsuarioViewModel>();

            foreach (var item in usuarios)
            {
                UsuarioViewModel usuarioFiltro = new UsuarioViewModel
                {
                    Id = item.IdUsuario,
                    Nome = item.Tx_Nome,
                    Sobrenome = item.Tx_Sobrenome,
                    IsAdm = item.IsAdmin
                };

                userFiltro.Add(usuarioFiltro);
            }

            dgvListaUsuario.DataSource = userFiltro.FindAll(x => x.Nome.ToUpper().Contains(tbxFiltro.Text.ToUpper()));


            Contador();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new frmTelaAdm().Show();

            this.Close();

        }

        private void btnNovoUser_Click(object sender, EventArgs e)
        {
            new frmCadastroUsuario().ShowDialog();

            atualizaLista();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Você tem certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                usuarioRepository.Deletar(userGrid.IdUsuario);
                atualizaLista();
            }

        } 

        private void dgvListaUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewRow linha = dgvListaUsuario.Rows[e.RowIndex];

                int id = Convert.ToInt32(linha.Cells[0].Value.ToString());
                
                Usuarios userSelect = usuarioRepository.BuscarId(id);

                tbxNome.Text = userSelect.Tx_Nome;
                tbxSobrenome.Text = userSelect.Tx_Sobrenome;
                tbxUsuario.Text = userSelect.Tx_Usuario;
                tbxSenha.Text = userSelect.Tx_Senha;
                dtpNascimento.Value = userSelect.Dt_Nascimento;
                tbxEndereco.Text = userSelect.Tx_Logradouro;
                tbxNendereco.Text = userSelect.Nr_Casa;
                cbxAdm.Checked = userSelect.IsAdmin;

                userGrid = userSelect;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Você tem certeza que deseja salvar?", "Confirmação", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                userGrid.Tx_Nome = tbxNome.Text;
                userGrid.Tx_Sobrenome = tbxSobrenome.Text;
                userGrid.Tx_Logradouro = tbxEndereco.Text;
                userGrid.Nr_Casa = tbxNendereco.Text;
                userGrid.Dt_Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                userGrid.Tx_Usuario = tbxUsuario.Text;
                userGrid.Tx_Senha = tbxSenha.Text;
                userGrid.IsAdmin = cbxAdm.Checked;
                userGrid.Tx_CaminhoFoto = "sem foto";

                usuarioRepository.Atualizar(userGrid);

                atualizaLista();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de imagens(*.jpg;*.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbUserFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            pcbUserFoto.Image = null;
        }
    }
}
