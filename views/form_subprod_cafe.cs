﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_modular_cafe_majada.views
{
    public partial class form_subprod_cafe : Form
    {
        public form_subprod_cafe()
        {
            InitializeComponent();
        }

        private void btn_tableCalidades_Click(object sender, EventArgs e)
        {
            form_tablaCCafe tablaCCafe = new form_tablaCCafe();
            tablaCCafe.ShowDialog();
        }
    }
}
