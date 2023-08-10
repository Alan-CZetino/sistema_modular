
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel1.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_rptCAcumulado, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_rptCFinca, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_rptCBodegas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_rptCCalidades, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_rptSubPartida, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_rptCAcumulado
            // 
            this.btn_rptCAcumulado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCAcumulado.Controls.Add(this.label5);
            this.btn_rptCAcumulado.Controls.Add(this.pictureBox5);
            this.btn_rptCAcumulado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCAcumulado.Location = new System.Drawing.Point(563, 2);
            this.btn_rptCAcumulado.Margin = new System.Windows.Forms.Padding(2);
            this.btn_rptCAcumulado.Name = "btn_rptCAcumulado";
            this.btn_rptCAcumulado.Size = new System.Drawing.Size(183, 154);
            this.btn_rptCAcumulado.TabIndex = 9;
            this.btn_rptCAcumulado.Click += new System.EventHandler(this.btn_rptCafeAcumulado_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 48);
            this.label5.TabIndex = 3;
            this.label5.Text = "Existencias de Café\r\nAcumulado.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.btn_rptCafeAcumulado_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox5.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox5.Location = new System.Drawing.Point(2, 28);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(128, 110);
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
            this.btn_rptCFinca.Location = new System.Drawing.Point(750, 2);
            this.btn_rptCFinca.Margin = new System.Windows.Forms.Padding(2);
            this.btn_rptCFinca.Name = "btn_rptCFinca";
            this.btn_rptCFinca.Size = new System.Drawing.Size(186, 154);
            this.btn_rptCFinca.TabIndex = 8;
            this.btn_rptCFinca.Click += new System.EventHandler(this.btn_rptGrafica_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Informe Gráfico";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.btn_rptGrafica_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox4.Location = new System.Drawing.Point(2, 28);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 110);
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
            this.btn_rptCBodegas.Location = new System.Drawing.Point(376, 2);
            this.btn_rptCBodegas.Margin = new System.Windows.Forms.Padding(2);
            this.btn_rptCBodegas.Name = "btn_rptCBodegas";
            this.btn_rptCBodegas.Size = new System.Drawing.Size(183, 154);
            this.btn_rptCBodegas.TabIndex = 7;
            this.btn_rptCBodegas.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 48);
            this.label3.TabIndex = 3;
            this.label3.Text = "Existencias de Café\r\npor bodega.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox3.Location = new System.Drawing.Point(2, 28);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 110);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.btn_rptCafeBodegas_Click);
            // 
            // btn_rptCCalidades
            // 
            this.btn_rptCCalidades.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_rptCCalidades.Controls.Add(this.label1);
            this.btn_rptCCalidades.Controls.Add(this.pictureBox1);
            this.btn_rptCCalidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rptCCalidades.Location = new System.Drawing.Point(2, 2);
            this.btn_rptCCalidades.Margin = new System.Windows.Forms.Padding(2);
            this.btn_rptCCalidades.Name = "btn_rptCCalidades";
            this.btn_rptCCalidades.Size = new System.Drawing.Size(183, 154);
            this.btn_rptCCalidades.TabIndex = 6;
            this.btn_rptCCalidades.Click += new System.EventHandler(this.btn_rptCCalidades_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Existencias de Café\r\npor calidades.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.btn_rptCCalidades_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox1.Location = new System.Drawing.Point(2, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 110);
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
            this.btn_rptSubPartida.Location = new System.Drawing.Point(189, 2);
            this.btn_rptSubPartida.Margin = new System.Windows.Forms.Padding(2);
            this.btn_rptSubPartida.Name = "btn_rptSubPartida";
            this.btn_rptSubPartida.Size = new System.Drawing.Size(183, 154);
            this.btn_rptSubPartida.TabIndex = 5;
            this.btn_rptSubPartida.Click += new System.EventHandler(this.btn_rptSubpartidas_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "Auxiliar de Sub\r\nPartidas.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.btn_rptSubpartidas_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.Image = global::sistema_modular_cafe_majada.Properties.Resources.reporte;
            this.pictureBox2.Location = new System.Drawing.Point(2, 28);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 110);
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
            this.panel1.Location = new System.Drawing.Point(10, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 398);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(4, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(930, 365);
            this.reportViewer1.TabIndex = 5;
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinal.Location = new System.Drawing.Point(349, 4);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(89, 20);
            this.dtFechaFinal.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hasta";
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicial.Location = new System.Drawing.Point(203, 4);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(89, 20);
            this.dtFechaInicial.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Desde";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Seleccione el rango de fecha:";
            // 
            // form_reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1350, 821);
            this.Name = "form_reportes";
            this.Text = "form_reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_reportes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.btn_rptCAcumulado.ResumeLayout(false);
            this.btn_rptCAcumulado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.btn_rptCFinca.ResumeLayout(false);
            this.btn_rptCFinca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.btn_rptCBodegas.ResumeLayout(false);
            this.btn_rptCBodegas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.btn_rptCCalidades.ResumeLayout(false);
            this.btn_rptCCalidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.btn_rptSubPartida.ResumeLayout(false);
            this.btn_rptSubPartida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
    }
}