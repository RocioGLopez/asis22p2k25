using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_Seguridad;

namespace CapaVista_Seguridad
{
    public partial class frmBitacora : Form
    {
        Controlador_Seguridad cn = new Controlador_Seguridad();
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void Btn_BuscarRango_Click(object sender, EventArgs e)
        {
            CargarEnGrid(cn.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
            cn.RegistrarAccion(1, 1, "Consulta", false);
        }
        private void CargarEnGrid(DataTable dt)
        {
            Dgv_Bitacora.DataSource = dt;
            Dgv_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Bitacora.ReadOnly = true;
            Dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
