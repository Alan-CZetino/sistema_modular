﻿
namespace sistema_modular_cafe_majada.views
{
    partial class form_tableperson
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
            this.btn_close = new System.Windows.Forms.Button();
            this.dtg_tablePerson = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_tablePerson)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::sistema_modular_cafe_majada.Properties.Resources.x__1___1_;
            this.btn_close.Location = new System.Drawing.Point(578, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(22, 24);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dtg_tablePerson
            // 
            this.dtg_tablePerson.AllowUserToAddRows = false;
            this.dtg_tablePerson.AllowUserToDeleteRows = false;
            this.dtg_tablePerson.AllowUserToOrderColumns = true;
            this.dtg_tablePerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_tablePerson.Location = new System.Drawing.Point(9, 33);
            this.dtg_tablePerson.Margin = new System.Windows.Forms.Padding(2);
            this.dtg_tablePerson.Name = "dtg_tablePerson";
            this.dtg_tablePerson.ReadOnly = true;
            this.dtg_tablePerson.RowHeadersWidth = 51;
            this.dtg_tablePerson.RowTemplate.Height = 24;
            this.dtg_tablePerson.Size = new System.Drawing.Size(582, 317);
            this.dtg_tablePerson.TabIndex = 1;
            this.dtg_tablePerson.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_tablePerson_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 24);
            this.panel1.TabIndex = 2;
            // 
            // form_tableperson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtg_tablePerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "form_tableperson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "form_tableperson";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_tablePerson)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dtg_tablePerson;
        private System.Windows.Forms.Panel panel1;
    }
}