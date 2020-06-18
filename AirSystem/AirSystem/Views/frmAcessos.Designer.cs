namespace AirSystem.Views
{
    partial class frmAcessos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAcessos = new System.Windows.Forms.DataGridView();
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAcessos
            // 
            this.dgvAcessos.AllowUserToAddRows = false;
            this.dgvAcessos.AllowUserToDeleteRows = false;
            this.dgvAcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcessos.Location = new System.Drawing.Point(72, 51);
            this.dgvAcessos.Name = "dgvAcessos";
            this.dgvAcessos.ReadOnly = true;
            this.dgvAcessos.Size = new System.Drawing.Size(662, 387);
            this.dgvAcessos.TabIndex = 0;
            this.dgvAcessos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcessos_CellContentClick);
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Location = new System.Drawing.Point(72, 25);
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(206, 20);
            this.tbxFiltro.TabIndex = 1;
            this.tbxFiltro.TextChanged += new System.EventHandler(this.tbxFiltro_TextChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(28, 28);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(707, 28);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(0, 13);
            this.lblQuantidade.TabIndex = 3;
            // 
            // frmAcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.tbxFiltro);
            this.Controls.Add(this.dgvAcessos);
            this.Name = "frmAcessos";
            this.Text = "frmAcessos";
            this.Load += new System.EventHandler(this.frmAcessos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAcessos;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblQuantidade;
    }
}