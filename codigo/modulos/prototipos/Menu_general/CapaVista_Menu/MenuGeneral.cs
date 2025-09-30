using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaVista_Seguridad;

namespace CapaVista_Menu
{
    public partial class MenuGeneral : Form
    {

        public MenuGeneral()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar sesión?", "Mensaje",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();//Cierra el formulario
        }

        private void consultaBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaVista_Seguridad.frmBitacora bitacora = new CapaVista_Seguridad.frmBitacora();
            bitacora.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaRisko/AyudaRiskoAS2.chm", "MDI.html");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudaRisko/AyudaRiskoAS2.chm", "MDI.html");

        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
