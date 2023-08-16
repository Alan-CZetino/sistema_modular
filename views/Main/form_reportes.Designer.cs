
namespace sistema_modular_cafe_majada.views
{
    partial class form_reportes
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
            this.btn_rptCAcumulado = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btn_rptCFinca = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_rptCBodegas = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_rptCCalidades = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_rptSubPartida = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btn_rptCAcumulado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.btn_rptCFinca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.btn_rptCBodegas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.btn_rptCCalidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.btn_rptSubPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rptCAcumulado
            // 
            this.btn_rptCAcumulado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCAcumulado.Controls.Add(this.label5);
            this.btn_rptCAcumulado.Controls.Add(this.pictureBox5);
            this.btn_rptCAcumulado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCAcumulado.Location = new System.Drawing.Point(759, 2);
            this.btn_rptCAcumulado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_rptCAcumulado.Name = "btn_rptCAcumulado";
            this.btn_rptCAcumulado.Size = new System.Drawing.Size(246, 166);
            this.btn_rptCAcumulado.TabIndex = 9;
            this.btn_rptCAcumulado.Click += new System.EventHandler(this.btn_rptCafeAcumulado_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 58);
            this.label5.TabIndex = 3;
            this.label5.Text = "Existencias de Café\r\nAcumulado.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.btn_rptCafeAcumulado_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox5.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox5.Location = new System.Drawing.Point(3, 37);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(103, 87);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.btn_rptCafeAcumulado_Click);
            // 
            // btn_rptCFinca
            // 
            this.btn_rptCFinca.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCFinca.Controls.Add(this.label4);
            this.btn_rptCFinca.Controls.Add(this.pictureBox4);
            this.btn_rptCFinca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCFinca.Location = new System.Drawing.Point(1011, 2);
            this.btn_rptCFinca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_rptCFinca.Name = "btn_rptCFinca";
            this.btn_rptCFinca.Size = new System.Drawing.Size(246, 166);
            this.btn_rptCFinca.TabIndex = 8;
            this.btn_rptCFinca.Click += new System.EventHandler(this.btn_rptGrafica_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Informe Gráfico";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.btn_rptGrafica_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox4.Location = new System.Drawing.Point(3, 37);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(121, 87);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.btn_rptGrafica_Click);
            // 
            // btn_rptCBodegas
            // 
            this.btn_rptCBodegas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCBodegas.Controls.Add(this.label3);
            this.btn_rptCBodegas.Controls.Add(this.pictureBox3);
            this.btn_rptCBodegas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCBodegas.Location = new System.Drawing.Point(507, 2);
            this.btn_rptCBodegas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_rptCBodegas.Name = "btn_rptCBodegas";
            this.btn_rptCBodegas.Size = new System.Drawing.Size(246, 166);
            this.btn_rptCBodegas.TabIndex = 7;
            this.btn_rptCBodegas.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 58);
            this.label3.TabIndex = 3;
            this.label3.Text = "Existencias de Café\r\npor bodega.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox3.Location = new System.Drawing.Point(3, 37);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(103, 87);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // btn_rptCCalidades
            // 
            this.btn_rptCCalidades.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCCalidades.Controls.Add(this.pictureBox6);
            this.btn_rptCCalidades.Controls.Add(this.label1);
            this.btn_rptCCalidades.Controls.Add(this.pictureBox1);
            this.btn_rptCCalidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCCalidades.Location = new System.Drawing.Point(3, 2);
            this.btn_rptCCalidades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_rptCCalidades.Name = "btn_rptCCalidades";
            this.btn_rptCCalidades.Size = new System.Drawing.Size(246, 166);
            this.btn_rptCCalidades.TabIndex = 6;
            this.btn_rptCCalidades.Click += new System.EventHandler(this.btn_rptCCalidades_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "Existencias de Café\r\npor calidades.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.btn_rptCCalidades_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox1.Location = new System.Drawing.Point(3, -243);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btn_rptCCalidades_Click);
            // 
            // btn_rptSubPartida
            // 
            this.btn_rptSubPartida.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptSubPartida.Controls.Add(this.label2);
            this.btn_rptSubPartida.Controls.Add(this.pictureBox2);
            this.btn_rptSubPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptSubPartida.Location = new System.Drawing.Point(255, 2);
            this.btn_rptSubPartida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_rptSubPartida.Name = "btn_rptSubPartida";
            this.btn_rptSubPartida.Size = new System.Drawing.Size(246, 166);
            this.btn_rptSubPartida.TabIndex = 5;
            this.btn_rptSubPartida.Click += new System.EventHandler(this.btn_rptSubpartidas_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 58);
            this.label2.TabIndex = 3;
            this.label2.Text = "Auxiliar de Sub\r\nPartidas.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.btn_rptSubpartidas_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox2.Location = new System.Drawing.Point(3, 37);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btn_rptSubpartidas_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.dtFechaFinal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtFechaInicial);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(10, 187);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 523);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(5, 37);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1248, 523);
            this.reportViewer1.TabIndex = 5;
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinal.Location = new System.Drawing.Point(465, 5);
            this.dtFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(117, 22);
            this.dtFechaFinal.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hasta";
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicial.Location = new System.Drawing.Point(271, 5);
            this.dtFechaInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(117, 22);
            this.dtFechaInicial.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Desde";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Seleccione el rango de fecha:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1280, 720);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_rptCFinca, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_rptCAcumulado, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_rptCCalidades, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_rptSubPartida, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_rptCBodegas, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1260, 170);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox6.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox6.Location = new System.Drawing.Point(3, 37);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(103, 87);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            // 
            // form_reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1030, 696);
            this.Name = "form_reportes";
            this.Text = "form_reportes";
            this.Load += new System.EventHandler(this.form_reportes_Load);
            this.btn_rptCAcumulado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.btn_rptCFinca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.btn_rptCBodegas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.btn_rptCCalidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.btn_rptSubPartida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel btn_rptSubPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel btn_rptCAcumulado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel btn_rptCFinca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel btn_rptCBodegas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel btn_rptCCalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}