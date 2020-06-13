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
    public partial class frmCadastroUsuario : Form
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void tbxNome_Enter(object sender, EventArgs e)
        {
            if (tbxNome.Text == "Digite seu nome")
            {
                tbxNome.Text = "";
                tbxNome.ForeColor = Color.Black;
            }
        }

        private void tbxNome_Leave(object sender, EventArgs e)
        {
            if (tbxNome.Text == "")
            {
                tbxNome.Text = "Digite seu nome";
                tbxNome.ForeColor = Color.Gray;
            }
        }

        private void tbxSobrenome_Enter(object sender, EventArgs e)
        {
            if (tbxSobrenome.Text == "Digite seu sobrenome")
            {
                tbxSobrenome.Text = "";
                tbxSobrenome.ForeColor = Color.Black;
            }
        }

        private void tbxSobrenome_Leave(object sender, EventArgs e)
        {
            if (tbxSobrenome.Text == "")
            {
                tbxSobrenome.Text = "Digite seu sobrenome";
                tbxSobrenome.ForeColor = Color.Gray;
            }
        }
    }
}
