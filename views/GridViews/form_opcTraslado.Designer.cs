﻿
namespace sistema_modular_cafe_majada.views
{
    partial class form_opcTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_opcTraslado));
            this.txb_buscarOpc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtg_opcTraslado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_opcTraslado)).BeginInit();
            this.SuspendLayout();
            // 
            // txb_buscarOpc
            // 
            this.txb_buscarOpc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txb_buscarOpc.BackColor = System.Drawing.Color.White;
            this.txb_buscarOpc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_buscarOpc.Font = new System.Drawing.Font("Oswald Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_buscarOpc.Location = new System.Drawing.Point(269, 37);
            this.txb_buscarOpc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txb_buscarOpc.Name = "txb_buscarOpc";
            this.txb_buscarOpc.Size = new System.Drawing.Size(286, 22);
            this.txb_buscarOpc.TabIndex = 1;
            this.txb_buscarOpc.Text = "Buscar...";
            this.txb_buscarOpc.TextChanged += new System.EventHandler(this.txb_buscarOpc_TextChanged);
            this.txb_buscarOpc.Enter += new System.EventHandler(this.txb_buscarOpc_Enter);
            this.txb_buscarOpc.Leave += new System.EventHandler(this.txb_buscarOpc_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.Barra_de_busqueda;
            this.pictureBox1.Location = new System.Drawing.Point(234, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 16;
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::sistema_modular_cafe_majada.Properties.Resources.x__1___1_;
            this.btn_close.Location = new System.Drawing.Point(778, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(22, 24);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 461);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 483);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 2);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(798, 24);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 459);
            this.panel4.TabIndex = 20;
            // 
            // dtg_opcTraslado
            // 
            this.dtg_opcTraslado.AllowUserToAddRows = false;
            this.dtg_opcTraslado.AllowUserToDeleteRows = false;
            this.dtg_opcTraslado.AllowUserToOrderColumns = true;
            this.dtg_opcTraslado.BackgroundColor = System.Drawing.Color.White;
            this.dtg_opcTraslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_opcTraslado.EnableHeadersVisualStyles = false;
            this.dtg_opcTraslado.GridColor = System.Drawing.Color.Black;
            this.dtg_opcTraslado.Location = new System.Drawing.Point(7, 83);
            this.dtg_opcTraslado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtg_opcTraslado.Name = "dtg_opcTraslado";
            this.dtg_opcTraslado.ReadOnly = true;
            this.dtg_opcTraslado.RowHeadersWidth = 51;
            this.dtg_opcTraslado.RowTemplate.Height = 24;
            this.dtg_opcTraslado.Size = new System.Drawing.Size(788, 392);
            this.dtg_opcTraslado.TabIndex = 0;
            this.dtg_opcTraslado.TabStop = false;
            this.dtg_opcTraslado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_opcTraslado_CellDoubleClick);
            // 
            // form_opcTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.dtg_opcTraslado);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txb_buscarOpc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(800, 485);
            this.MinimumSize = new System.Drawing.Size(800, 485);
            this.Name = "form_opcTraslado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_opcTraslado";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_opcTraslado_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_opcTraslado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_buscarOpc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtg_opcTraslado;
    }
}