using AirSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InvisibleLabel(Label labelName)
        {
            labelName.Parent = pcbBackground;
            labelName.BackColor = Color.Transparent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InvisibleLabel(lblLogo);
            InvisibleLabel(lblUsuario);
            InvisibleLabel(lblSenha);
            InvisibleLabel(lblIdioma);
            InvisibleLabel(lblTempo);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            lblTempo.Text = time;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario frmCadastro = new frmCadastroUsuario();
            frmCadastro.Show();

        }

        private void tbxUsuario_Enter(object sender, EventArgs e)
        {
            if (tbxUsuario.Text == "Digite seu usuario")
            {
                tbxUsuario.Text = "";
                tbxUsuario.ForeColor = Color.Black;
            }
        }

        private void tbxUsuario_Leave(object sender, EventArgs e)
        {
            if (tbxUsuario.Text == "")
            {
                tbxUsuario.Text = "Digite seu usuario";
                tbxUsuario.ForeColor = Color.Gray;
            }
        }

        private void tbxSenha_Enter(object sender, EventArgs e)
        {
            if (tbxSenha.Text == "Digite sua senha")
            {
                tbxSenha.Text = "";
                tbxSenha.ForeColor = Color.Black;
            }
        }

        private void tbxSenha_Leave(object sender, EventArgs e)
        {
            if (tbxSenha.Text == "")
            {
                tbxSenha.Text = "Digite sua senha";
                tbxSenha.ForeColor = Color.Gray;
            }
        }
    }
}
