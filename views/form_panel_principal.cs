using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema_modular_cafe_majada.controller;
using sistema_modular_cafe_majada.controller.InfrastructureController;
using sistema_modular_cafe_majada.controller.ProductController;
using sistema_modular_cafe_majada.model.Mapping;
using sistema_modular_cafe_majada.model.Mapping.Infrastructure;
using sistema_modular_cafe_majada.model.Mapping.Product;
using sistema_modular_cafe_majada.views;

namespace sistema_modular_cafe_majada
{
    public partial class form_panel_principal : Form
    {
        private int iTabla;
        public int Itabla
        {
            get { return iTabla; }
            set { iTabla = value; }
        }

        public form_panel_principal()
        {
            InitializeComponent();

            ShowCountBDCard();
        }

        //funcion para mostrar los totales de registros de cada tarjeta en el panel principal
        public void ShowCountBDCard()
        {
            //para calidad de cafe
            var ccafe = new CCafeController();
            CalidadCafe totalccafe = ccafe.CountCalidad();
            lbl_calidad.Text = totalccafe.CountCalidad.ToString();
            
            //para tipo de cafe
            var tipocafe = new TipoCafeController();
            TipoCafe totaltipo = tipocafe.CountTipoCafe();
            lbl_tipo.Text = totaltipo.CountTipoCafe.ToString();
            
            //para finca de cafe
            var finca = new FincaController();
            Finca totalFinca = finca.CountFincas();
            lbl_finca.Text = totalFinca.CountFinca.ToString();

            //para tipo de cafe
            var beneficio = new BeneficioController();
            Beneficio totalBeneficio = beneficio.CountBeneficio();
            lbl_beneficio.Text = totalBeneficio.CountBeneficio.ToString();
        }

        private void pnl_calCafe_Click(object sender, EventArgs e)
        {
            iTabla = 1;
            form_opcGeneralData form_Opc = new form_opcGeneralData(this);
            form_Opc.ShowDialog();
        }

        private void pnl_subProd_Click(object sender, EventArgs e)
        {
            iTabla = 2;
            form_opcGeneralData form_Opc = new form_opcGeneralData(this);
            form_Opc.ShowDialog();
        }

        private void pnl_Uva_Click(object sender, EventArgs e)
        {
            iTabla = 3;
            form_opcGeneralData form_Opc = new form_opcGeneralData(this);
            form_Opc.ShowDialog();
        }

        private void pnl_fincas_Click(object sender, EventArgs e)
        {
            iTabla = 4;
            form_opcGeneralData form_Opc = new form_opcGeneralData(this);
            form_Opc.ShowDialog();
        }

        private void pnl_beneficios_Click(object sender, EventArgs e)
        {
            iTabla = 5;
            form_opcGeneralData form_Opc = new form_opcGeneralData(this);
            form_Opc.ShowDialog();
        }
    }
}
