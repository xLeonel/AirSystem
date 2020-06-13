using AirSystem.Models;
using AirSystem.Repositories;
using AirSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        string textoPadrao = "";


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

        private void Inputs_Enter(object sender, EventArgs e)
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

        private void Inputs_Leave(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (tbx.Text == "")
            {
                tbx.Text = textoPadrao;
                tbx.ForeColor = Color.Gray;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.BuscarTodos();

            foreach (var item in usuarios)
            {
                if (item.Username == tbxUsuario.Text && item.Senha == tbxSenha.Text)
                {
                    if (item.IsAdmin)
                    {
                        //frmPainelAdmin.Show();
                        MessageBox.Show("Admin.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //frmPainelUser.Show();
                        MessageBox.Show("Usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }
    }
}
