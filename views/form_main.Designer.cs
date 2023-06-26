
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
            this.btn_min = new System.Windows.Forms.PictureBox();
            this.btn_max = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CloseSection = new System.Windows.Forms.Button();
            this.btn_admin_panel = new System.Windows.Forms.Button();
            this.btn_reportes = new System.Windows.Forms.Button();
            this.btn_activos = new System.Windows.Forms.Button();
            this.btn_principal = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_container = new System.Windows.Forms.Panel();
            this.barra_controles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.barra_controles.Margin = new System.Windows.Forms.Padding(2);
            this.barra_controles.Name = "barra_controles";
            this.barra_controles.Size = new System.Drawing.Size(960, 20);
            this.barra_controles.TabIndex = 0;
            this.barra_controles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_controles_MouseDown);
            // 
            // btn_min
            // 
            this.btn_min.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_min.Image = global::sistema_modular_cafe_majada.Properties.Resources.eliminar__1_;
            this.btn_min.Location = new System.Drawing.Point(894, 0);
            this.btn_min.Margin = new System.Windows.Forms.Padding(2);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(22, 20);
            this.btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_min.TabIndex = 2;
            this.btn_min.TabStop = false;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_max.Image = global::sistema_modular_cafe_majada.Properties.Resources.cuadrado__2_;
            this.btn_max.Location = new System.Drawing.Point(916, 0);
            this.btn_max.Margin = new System.Windows.Forms.Padding(2);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(22, 20);
            this.btn_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_max.TabIndex = 1;
            this.btn_max.TabStop = false;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Image = global::sistema_modular_cafe_majada.Properties.Resources.x__1___1_;
            this.btn_close.Location = new System.Drawing.Point(938, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(22, 20);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_close.TabIndex = 0;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel2.Controls.Add(this.lbl_User);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btn_CloseSection);
            this.panel2.Controls.Add(this.btn_admin_panel);
            this.panel2.Controls.Add(this.btn_reportes);
            this.panel2.Controls.Add(this.btn_activos);
            this.panel2.Controls.Add(this.btn_principal);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 565);
            this.panel2.TabIndex = 1;
            // 
            // lbl_User
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_username.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.Color.White;
            this.lbl_username.Location = new System.Drawing.Point(0, 599);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl_username.Size = new System.Drawing.Size(91, 32);
            this.lbl_username.TabIndex = 8;
            this.lbl_username.Text = "username";
            this.lbl_username.Click += new System.EventHandler(this.lbl_username_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 16);
            this.panel1.TabIndex = 7;
            // 
            // btn_CloseSection
            // 
            this.btn_CloseSection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_CloseSection.FlatAppearance.BorderSize = 0;
            this.btn_CloseSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseSection.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloseSection.ForeColor = System.Drawing.Color.White;
            this.btn_CloseSection.Image = global::sistema_modular_cafe_majada.Properties.Resources.cerrar_sesion_24px;
            this.btn_CloseSection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CloseSection.Location = new System.Drawing.Point(0, 528);
            this.btn_CloseSection.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CloseSection.Name = "btn_CloseSection";
            this.btn_CloseSection.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_CloseSection.Size = new System.Drawing.Size(188, 37);
            this.btn_CloseSection.TabIndex = 6;
            this.btn_CloseSection.Text = "Cerrar Sesión";
            this.btn_CloseSection.UseVisualStyleBackColor = true;
            this.btn_CloseSection.Click += new System.EventHandler(this.btn_CloseSection_Click);
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
            this.btn_admin_panel.Location = new System.Drawing.Point(0, 267);
            this.btn_admin_panel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_admin_panel.Name = "btn_admin_panel";
            this.btn_admin_panel.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_admin_panel.Size = new System.Drawing.Size(188, 37);
            this.btn_admin_panel.TabIndex = 4;
            this.btn_admin_panel.Text = "Administración";
            this.btn_admin_panel.UseVisualStyleBackColor = true;
            this.btn_admin_panel.Click += new System.EventHandler(this.btn_admin_panel_Click);
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
            this.btn_reportes.Location = new System.Drawing.Point(0, 230);
            this.btn_reportes.Margin = new System.Windows.Forms.Padding(2);
            this.btn_reportes.Name = "btn_reportes";
            this.btn_reportes.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_reportes.Size = new System.Drawing.Size(188, 37);
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
            this.btn_activos.Location = new System.Drawing.Point(0, 193);
            this.btn_activos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_activos.Name = "btn_activos";
            this.btn_activos.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_activos.Size = new System.Drawing.Size(188, 37);
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
            this.btn_principal.Location = new System.Drawing.Point(0, 156);
            this.btn_principal.Margin = new System.Windows.Forms.Padding(2);
            this.btn_principal.Name = "btn_principal";
            this.btn_principal.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btn_principal.Size = new System.Drawing.Size(188, 37);
            this.btn_principal.TabIndex = 2;
            this.btn_principal.Text = "Panel Principal";
            this.btn_principal.UseVisualStyleBackColor = true;
            this.btn_principal.Click += new System.EventHandler(this.btn_principal_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 102);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 54);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.logo_cafe_majada;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.Color.White;
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.ForeColor = System.Drawing.Color.Black;
            this.panel_container.Location = new System.Drawing.Point(188, 20);
            this.panel_container.Margin = new System.Windows.Forms.Padding(2);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(772, 565);
            this.panel_container.TabIndex = 2;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barra_controles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(2880, 1755);
            this.MinimumSize = new System.Drawing.Size(960, 585);
            this.Name = "form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_main_Load);
            this.barra_controles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btn_CloseSection;
        private System.Windows.Forms.Button btn_admin_panel;
        private System.Windows.Forms.Button btn_reportes;
        private System.Windows.Forms.Button btn_activos;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Panel panel1;
    }
}