using AirSystem.Models;
using AirSystem.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem.Views
{
    public partial class frmCadastroUsuario : Form
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        string textoPadrao = "";

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            lblSenhaAviso.Visible = false;
            lblSenhaRegex.Visible = false;

        }

        private void Inputs_Enter(Object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            textoPadrao = tbx.Text;

            if (tbx.Text == tbx.Text)
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
                tbx.Font = Font;
            }
        }

        private void Inputs_Leave(Object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (tbx.Text == "")
            {
                tbx.Text = textoPadrao;
                tbx.ForeColor = Color.Gray;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();

            bool camposVazio = false;

            foreach (Control c in this.Controls)
            {
                TextBox tbx = c as TextBox;
                if (tbx != null && tbx.Text.Trim().Length == 0)
                {
                    camposVazio =  true;
                }
            }
            

            if (!camposVazio)
            {
                Usuario usuario = new Usuario
                {
                    Id = 0,
                    Nome = tbxNome.Text,
                    Sobrenome = tbxSobrenome.Text,
                    DataNascimento = Convert.ToDateTime(dtpNascimento.Text),
                    Endereco = $"{tbxEndereco.Text}, {tbxNendereco.Text}",
                    Username = tbxUsuario.Text,
                    Senha = tbxSenha.Text,
                    IsAdmin = Convert.ToBoolean(cbxAdm.Checked)
                };

                if (usuarioRepository.Cadastrar(usuario))
                {
                    MessageBox.Show("Cadastrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBox.Show("Preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tbxConfirmarSenha_TextChanged(object sender, EventArgs e)
        {
            _ = tbxSenha.Text == tbxConfirmarSenha.Text ? lblSenhaAviso.Visible = false : lblSenhaAviso.Visible = true;
        }

        private void tbxSenha_TextChanged(object sender, EventArgs e)
        {
            string pattern = "[A-Z]{1}[a-z]{1,}[0-9]{1,}";

            lblSenhaRegex.Visible = !Regex.IsMatch(tbxSenha.Text, pattern);

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
