﻿using AirSystem.Database;
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
            if (!string.IsNullOrEmpty(cbxIdioma.Text))
            {
                if (cbxIdioma.Text != "Inglês")
                {
                    frmCadastroUsuario frmCadastro = new frmCadastroUsuario();
                    frmCadastro.Show();
                }
                else
                {
                    frmCadastroIngles frmCadastro = new frmCadastroIngles();
                    frmCadastro.Show();
                }
            }
            else
            {
                MessageBox.Show(this, "Escolha um Idioma / Choose a language", "Confirmação", MessageBoxButtons.OK);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxIdioma.Text))
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();

                AcessoRepository acessooRepository = new AcessoRepository();


                Usuarios user = usuarioRepository.BuscarUsuario(tbxUsuario.Text, tbxSenha.Text);

                if (user != null)
                {

                    if (user.Tx_Usuario == tbxUsuario.Text && user.Tx_Senha == tbxSenha.Text)
                    {
                        Acesso acessoNovo = new Acesso
                        {
                            IdUsuario = user.IdUsuario,
                            Dt_AcessoEntrada = DateTime.Now
                        };

                        if (user.IsAdmin)
                        {

                            if (cbxIdioma.Text != "Inglês")
                            {
                                frmTelaAdm frm = new frmTelaAdm(acessoNovo);
                                frm.Show();
                                this.WindowState = FormWindowState.Minimized;

                            }
                            else
                            {
                                frmTelaAdm frm = new frmTelaAdm(cbxIdioma.Text, acessoNovo);
                                frm.Show();
                            }
                        }
                        else
                        {
                            if (cbxIdioma.Text != "Inglês")
                            {
                                frmTelaUser frm = new frmTelaUser();
                                frm.Show();
                                this.WindowState = FormWindowState.Minimized;
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Senha Incorreta", "Confirmação", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Preencha os campo.", "Confirmação", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show(this, "Escolha um Idioma / Choose a language", "Confirmação", MessageBoxButtons.OK);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
