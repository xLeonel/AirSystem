using AirSystem.Database;
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

        UsuarioRepository usuarioRepository = new UsuarioRepository();

        Usuarios user = new Usuarios();

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            lblSenhaAviso.Visible = false;
            lblSenhaRegex.Visible = false;

            InvisibleLabel(lblNome);
            InvisibleLabel(lblEndereco);
            InvisibleLabel(lblNascimento);
            InvisibleLabel(lblConfirmarSenha);
            InvisibleLabel(lblSenha);
            InvisibleLabel(lblSenhaAviso);
            InvisibleLabel(lblSenhaRegex);
            InvisibleLabel(lblUsuario);

            lblEqualsUser.Visible = false;
            lblEqualsUser.BackColor = Color.Transparent;



            cbxAdm.Parent = panel1;
            cbxAdm.BackColor = Color.Transparent;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            user = usuarioRepository.BuscarTodosUsername(tbxUsuario.Text);

            bool campoVazio = false;
            foreach (Control item in this.Controls)
            {
                MarkedWaterTextBox tbx = item as MarkedWaterTextBox;

                if (tbx != null && tbx.WaterMarkText == tbx.Text)
                {
                    campoVazio = true;
                }
            }

            if (!campoVazio)
            {
                if (user == null)
                {
                    if (tbxSenha.Text == tbxConfirmarSenha.Text)
                    {
                        Usuarios usuario = new Usuarios
                        {
                            Tx_Nome = tbxNome.Text,
                            Tx_Sobrenome = tbxSobrenome.Text,
                            Tx_Logradouro = tbxEndereco.Text,
                            Nr_Casa = tbxNendereco.Text,
                            Dt_Nascimento = Convert.ToDateTime(dtpNascimento.Text),
                            Tx_Usuario = tbxUsuario.Text,
                            Tx_Senha = tbxSenha.Text,
                            Tx_CaminhoFoto = "semfoto",
                            IsAdmin = Convert.ToBoolean(cbxAdm.Checked)
                        };

                        if (usuarioRepository.Cadastrar(usuario))
                        {
                            MessageBox.Show("Cadastrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("As senhas precisam ser idênticas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Usuário já Existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void InvisibleLabel(Label labelName)
        {
            labelName.Parent = panel1;
            labelName.BackColor = Color.Transparent;

        }

        private void Focus_enter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, Color.Yellow);
        }

        private void Focus_leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
        }

        private void frmCadastroUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tbxUsuario_TextChanged(object sender, EventArgs e)
        {
            //TOFIX IMPLEMENTAÇAO CAUSA LENTIDAO 

            //lblEqualsUser.Visible = true;

            //if (user != null)
            //{
            //    lblEqualsUser.Text = "Usuário Indisponível";
            //}
            //else
            //{
            //    lblEqualsUser.Text = "Usuário disponível";
            //}
        }
    }
}