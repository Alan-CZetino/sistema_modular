
namespace sistema_modular_cafe_majada.views
{
    partial class form_calidades_cafe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_modCalidad = new System.Windows.Forms.PictureBox();
            this.btn_deleteCalidad = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txb_desCalidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_nameCalidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_SaveCalidad = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dtg_calidadCafe = new System.Windows.Forms.DataGridView();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_modCalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_deleteCalidad)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_calidadCafe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 490);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1005, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 489);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(1, 489);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1004, 1);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1004, 70);
            this.panel5.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_modCalidad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_deleteCalidad, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(870, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(127, 55);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btn_modCalidad
            // 
            this.btn_modCalidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_modCalidad.Image = global::sistema_modular_cafe_majada.Properties.Resources.editar;
            this.btn_modCalidad.Location = new System.Drawing.Point(3, 3);
            this.btn_modCalidad.Name = "btn_modCalidad";
            this.btn_modCalidad.Size = new System.Drawing.Size(57, 49);
            this.btn_modCalidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_modCalidad.TabIndex = 1;
            this.btn_modCalidad.TabStop = false;
            this.btn_modCalidad.Click += new System.EventHandler(this.btn_modCalidad_Click);
            // 
            // btn_deleteCalidad
            // 
            this.btn_deleteCalidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_deleteCalidad.Image = global::sistema_modular_cafe_majada.Properties.Resources.boton_eliminar;
            this.btn_deleteCalidad.Location = new System.Drawing.Point(66, 3);
            this.btn_deleteCalidad.Name = "btn_deleteCalidad";
            this.btn_deleteCalidad.Size = new System.Drawing.Size(58, 49);
            this.btn_deleteCalidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_deleteCalidad.TabIndex = 2;
            this.btn_deleteCalidad.TabStop = false;
            this.btn_deleteCalidad.Click += new System.EventHandler(this.btn_deleteCalidad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "*LLene los campos que se le solicitan a continuación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulario de Registro de Calidades de Café";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(1, 71);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(296, 418);
            this.panel6.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.Controls.Add(this.txb_desCalidad);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.txb_nameCalidad);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(296, 371);
            this.panel8.TabIndex = 7;
            // 
            // txb_desCalidad
            // 
            this.txb_desCalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_desCalidad.Font = new System.Drawing.Font("Oswald Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_desCalidad.Location = new System.Drawing.Point(11, 100);
            this.txb_desCalidad.Multiline = true;
            this.txb_desCalidad.Name = "txb_desCalidad";
            this.txb_desCalidad.Size = new System.Drawing.Size(231, 188);
            this.txb_desCalidad.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descripción";
            // 
            // txb_nameCalidad
            // 
            this.txb_nameCalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_nameCalidad.Font = new System.Drawing.Font("Oswald Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_nameCalidad.Location = new System.Drawing.Point(11, 35);
            this.txb_nameCalidad.Name = "txb_nameCalidad";
            this.txb_nameCalidad.Size = new System.Drawing.Size(231, 33);
            this.txb_nameCalidad.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Calidad del Café";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_SaveCalidad);
            this.panel7.Controls.Add(this.btn_Cancel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 371);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(296, 47);
            this.panel7.TabIndex = 6;
            // 
            // btn_SaveCalidad
            // 
            this.btn_SaveCalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SaveCalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btn_SaveCalidad.FlatAppearance.BorderSize = 0;
            this.btn_SaveCalidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(115)))), ((int)(((byte)(71)))));
            this.btn_SaveCalidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(115)))), ((int)(((byte)(71)))));
            this.btn_SaveCalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveCalidad.Font = new System.Drawing.Font("Oswald SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveCalidad.ForeColor = System.Drawing.Color.White;
            this.btn_SaveCalidad.Image = global::sistema_modular_cafe_majada.Properties.Resources.btn_guardar;
            this.btn_SaveCalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveCalidad.Location = new System.Drawing.Point(19, 3);
            this.btn_SaveCalidad.Name = "btn_SaveCalidad";
            this.btn_SaveCalidad.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_SaveCalidad.Size = new System.Drawing.Size(110, 40);
            this.btn_SaveCalidad.TabIndex = 2;
            this.btn_SaveCalidad.Text = "Guardar";
            this.btn_SaveCalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SaveCalidad.UseVisualStyleBackColor = false;
            this.btn_SaveCalidad.Click += new System.EventHandler(this.btn_SaveCalidad_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Oswald SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Image = global::sistema_modular_cafe_majada.Properties.Resources.btn_eliminar;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.Location = new System.Drawing.Point(161, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_Cancel.Size = new System.Drawing.Size(110, 40);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dtg_calidadCafe
            // 
            this.dtg_calidadCafe.AllowUserToAddRows = false;
            this.dtg_calidadCafe.AllowUserToDeleteRows = false;
            this.dtg_calidadCafe.AllowUserToOrderColumns = true;
            this.dtg_calidadCafe.AllowUserToResizeColumns = false;
            this.dtg_calidadCafe.AllowUserToResizeRows = false;
            this.dtg_calidadCafe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_calidadCafe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_calidadCafe.BackgroundColor = System.Drawing.Color.White;
            this.dtg_calidadCafe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_calidadCafe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_calidadCafe.EnableHeadersVisualStyles = false;
            this.dtg_calidadCafe.GridColor = System.Drawing.Color.Black;
            this.dtg_calidadCafe.Location = new System.Drawing.Point(308, 82);
            this.dtg_calidadCafe.Name = "dtg_calidadCafe";
            this.dtg_calidadCafe.ReadOnly = true;
            this.dtg_calidadCafe.RowHeadersVisible = false;
            this.dtg_calidadCafe.RowHeadersWidth = 51;
            this.dtg_calidadCafe.RowTemplate.Height = 24;
            this.dtg_calidadCafe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_calidadCafe.Size = new System.Drawing.Size(686, 396);
            this.dtg_calidadCafe.TabIndex = 15;
            this.dtg_calidadCafe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_calidadCafe_CellDoubleClick);
            this.dtg_calidadCafe.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtg_calidadCafe_CellPainting);
            // 
            // form_calidades_cafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 490);
            this.Controls.Add(this.dtg_calidadCafe);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_calidades_cafe";
            this.Text = "form_calidades_cafe";
            this.Load += new System.EventHandler(this.form_calidades_cafe_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_modCalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_deleteCalidad)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_calidadCafe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox btn_modCalidad;
        private System.Windows.Forms.PictureBox btn_deleteCalidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_SaveCalidad;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txb_nameCalidad;
        private System.Windows.Forms.DataGridView dtg_calidadCafe;
        private System.Windows.Forms.TextBox txb_desCalidad;
        private System.Windows.Forms.Label label4;
    }
}