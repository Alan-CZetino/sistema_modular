﻿
namespace sistema_modular_cafe_majada
{
    partial class form_main
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
            this.barra_controles = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_admin_panel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_container = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_reportes = new System.Windows.Forms.Button();
            this.btn_activos = new System.Windows.Forms.Button();
            this.btn_principal = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_min = new System.Windows.Forms.PictureBox();
            this.btn_max = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.barra_controles.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.SuspendLayout();
            // 
            // barra_controles
            // 
            this.barra_controles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.barra_controles.Controls.Add(this.btn_min);
            this.barra_controles.Controls.Add(this.btn_max);
            this.barra_controles.Controls.Add(this.btn_close);
            this.barra_controles.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra_controles.Location = new System.Drawing.Point(0, 0);
            this.barra_controles.Name = "barra_controles";
            this.barra_controles.Size = new System.Drawing.Size(1280, 24);
            this.barra_controles.TabIndex = 0;
            this.barra_controles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_controles_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btn_admin_panel);
            this.panel2.Controls.Add(this.btn_reportes);
            this.panel2.Controls.Add(this.btn_activos);
            this.panel2.Controls.Add(this.btn_principal);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 696);
            this.panel2.TabIndex = 1;
            // 
            // btn_admin_panel
            // 
            this.btn_admin_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_admin_panel.FlatAppearance.BorderSize = 0;
            this.btn_admin_panel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_admin_panel.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_admin_panel.ForeColor = System.Drawing.Color.White;
            this.btn_admin_panel.Image = global::sistema_modular_cafe_majada.Properties.Resources.admin_2_24px;
            this.btn_admin_panel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_admin_panel.Location = new System.Drawing.Point(0, 326);
            this.btn_admin_panel.Name = "btn_admin_panel";
            this.btn_admin_panel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_admin_panel.Size = new System.Drawing.Size(250, 45);
            this.btn_admin_panel.TabIndex = 4;
            this.btn_admin_panel.Text = "Administración";
            this.btn_admin_panel.UseVisualStyleBackColor = true;
            this.btn_admin_panel.Click += new System.EventHandler(this.btn_admin_panel_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 66);
            this.panel3.TabIndex = 1;
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.Color.White;
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.ForeColor = System.Drawing.Color.Black;
            this.panel_container.Location = new System.Drawing.Point(250, 24);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(1030, 696);
            this.panel_container.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::sistema_modular_cafe_majada.Properties.Resources.cerrar_sesion_24px;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 651);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(250, 45);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cerrar Sesión";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btn_reportes
            // 
            this.btn_reportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_reportes.FlatAppearance.BorderSize = 0;
            this.btn_reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reportes.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reportes.ForeColor = System.Drawing.Color.White;
            this.btn_reportes.Image = global::sistema_modular_cafe_majada.Properties.Resources.impresora;
            this.btn_reportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reportes.Location = new System.Drawing.Point(0, 281);
            this.btn_reportes.Name = "btn_reportes";
            this.btn_reportes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_reportes.Size = new System.Drawing.Size(250, 45);
            this.btn_reportes.TabIndex = 5;
            this.btn_reportes.Text = "Reportes";
            this.btn_reportes.UseVisualStyleBackColor = true;
            this.btn_reportes.Click += new System.EventHandler(this.btn_reportes_Click);
            // 
            // btn_activos
            // 
            this.btn_activos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_activos.FlatAppearance.BorderSize = 0;
            this.btn_activos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_activos.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_activos.ForeColor = System.Drawing.Color.White;
            this.btn_activos.Image = global::sistema_modular_cafe_majada.Properties.Resources.activos24px;
            this.btn_activos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_activos.Location = new System.Drawing.Point(0, 236);
            this.btn_activos.Name = "btn_activos";
            this.btn_activos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_activos.Size = new System.Drawing.Size(250, 45);
            this.btn_activos.TabIndex = 3;
            this.btn_activos.Text = "Existencias de Café";
            this.btn_activos.UseVisualStyleBackColor = true;
            this.btn_activos.Click += new System.EventHandler(this.btn_activos_Click);
            // 
            // btn_principal
            // 
            this.btn_principal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_principal.FlatAppearance.BorderSize = 0;
            this.btn_principal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_principal.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_principal.ForeColor = System.Drawing.Color.White;
            this.btn_principal.Image = global::sistema_modular_cafe_majada.Properties.Resources.tablero_24px;
            this.btn_principal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_principal.Location = new System.Drawing.Point(0, 191);
            this.btn_principal.Name = "btn_principal";
            this.btn_principal.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_principal.Size = new System.Drawing.Size(250, 45);
            this.btn_principal.TabIndex = 2;
            this.btn_principal.Text = "Panel Principal";
            this.btn_principal.UseVisualStyleBackColor = true;
            this.btn_principal.Click += new System.EventHandler(this.btn_principal_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.logo_oficial_majada;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_min
            // 
            this.btn_min.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_min.Image = global::sistema_modular_cafe_majada.Properties.Resources.eliminar__1_;
            this.btn_min.Location = new System.Drawing.Point(1190, 0);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(30, 24);
            this.btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_min.TabIndex = 2;
            this.btn_min.TabStop = false;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_max.Image = global::sistema_modular_cafe_majada.Properties.Resources.cuadrado__2_;
            this.btn_max.Location = new System.Drawing.Point(1220, 0);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(30, 24);
            this.btn_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_max.TabIndex = 1;
            this.btn_max.TabStop = false;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Image = global::sistema_modular_cafe_majada.Properties.Resources.x__1___1_;
            this.btn_close.Location = new System.Drawing.Point(1250, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 24);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_close.TabIndex = 0;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barra_controles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(3840, 2160);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_main_Load);
            this.barra_controles.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barra_controles;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_min;
        private System.Windows.Forms.PictureBox btn_max;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_principal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_admin_panel;
        private System.Windows.Forms.Button btn_reportes;
        private System.Windows.Forms.Button btn_activos;
        private System.Windows.Forms.Panel panel_container;
    }
}