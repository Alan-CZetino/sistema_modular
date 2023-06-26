using System;
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
    public partial class form_personal : Form
    {
        public form_personal()
        {
            InitializeComponent();
        }

        private void btn_tablePerson_Click(object sender, EventArgs e)
        {
            form_tableperson ftPerson = new form_tableperson();
            ftPerson.ShowDialog();
        }
    }
}
