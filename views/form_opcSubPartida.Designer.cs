﻿
namespace sistema_modular_cafe_majada.views
{
    partial class form_opcSubPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_opcSubPartida));
            this.txb_buscarOpc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtg_opcSP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_opcSP)).BeginInit();
            this.SuspendLayout();
            // 
            // txb_buscarOpc
            // 
            this.txb_buscarOpc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txb_buscarOpc.BackColor = System.Drawing.Color.White;
            this.txb_buscarOpc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_buscarOpc.Font = new System.Drawing.Font("Oswald Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_buscarOpc.Location = new System.Drawing.Point(359, 46);
            this.txb_buscarOpc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txb_buscarOpc.Name = "txb_buscarOpc";
            this.txb_buscarOpc.Size = new System.Drawing.Size(381, 27);
            this.txb_buscarOpc.TabIndex = 15;
            this.txb_buscarOpc.Text = "Buscar...";
            this.txb_buscarOpc.Enter += new System.EventHandler(this.txb_buscarOpc_Enter);
            this.txb_buscarOpc.Leave += new System.EventHandler(this.txb_buscarOpc_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.Barra_de_busqueda;
            this.pictureBox1.Location = new System.Drawing.Point(312, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 30);
            this.panel1.TabIndex = 13;
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::sistema_modular_cafe_majada.Properties.Resources.x__1___1_;
            this.btn_close.Location = new System.Drawing.Point(1038, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(29, 30);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 567);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1064, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 567);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 595);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1061, 2);
            this.panel4.TabIndex = 17;
            // 
            // dtg_opcSP
            // 
            this.dtg_opcSP.AllowUserToAddRows = false;
            this.dtg_opcSP.AllowUserToDeleteRows = false;
            this.dtg_opcSP.AllowUserToOrderColumns = true;
            this.dtg_opcSP.BackgroundColor = System.Drawing.Color.White;
            this.dtg_opcSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_opcSP.EnableHeadersVisualStyles = false;
            this.dtg_opcSP.GridColor = System.Drawing.Color.White;
            this.dtg_opcSP.Location = new System.Drawing.Point(9, 102);
            this.dtg_opcSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtg_opcSP.Name = "dtg_opcSP";
            this.dtg_opcSP.ReadOnly = true;
            this.dtg_opcSP.RowHeadersWidth = 51;
            this.dtg_opcSP.RowTemplate.Height = 24;
            this.dtg_opcSP.Size = new System.Drawing.Size(1051, 487);
            this.dtg_opcSP.TabIndex = 18;
            this.dtg_opcSP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_opcSP_CellDoubleClick);
            // 
            // form_opcSubPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 597);
            this.Controls.Add(this.dtg_opcSP);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txb_buscarOpc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1067, 597);
            this.MinimumSize = new System.Drawing.Size(1067, 597);
            this.Name = "form_opcSubPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_opcSubPartida";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_opcSP_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_opcSP)).EndInit();
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
        private System.Windows.Forms.DataGridView dtg_opcSP;
    }
}