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

using CapaVista_Seguridad;
using CapaControlador_Menu;
using System.Data.Odbc;



namespace CapaVista_Menu
{
    public partial class MenuGeneral : Form
    {
        string Tipo = "tipo_puesto";
        Controlador cn = new Controlador();
        private bool Editar = false;
        private string idEmpleado = null;

        int idUsuarioConectado = 1;
        int codigoAplicacion = 1; // código de aplicación "Usuario"
        CapaControlador_Seguridad.Controlador_Seguridad auditoriaBitacora = new CapaControlador_Seguridad.Controlador_Seguridad();

        bool bEstado = true;


        public MenuGeneral()
        {
            InitializeComponent();
            MostrarEmpleados();

        }



        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(Tipo);
            /*nombre del datagrid*/
            Dgv1.DataSource = dt;

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



        private void button1_Click_1(object sender, EventArgs e)
        {

            string rutaAyuda = @"C:\Users\WINDOWS\Desktop\examen analisis\asis22p2k25\ayudas\AyudaRisko\AyudaRiskoAS2.chm";
            Help.ShowHelp(this, @"C:\Users\WINDOWS\Desktop\examen analisis\asis22p2k25\ayudas\AyudaRisko\AyudasRiscoAS2.chm", "MDI.html");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void MostrarEmpleados()
        {
            try
            {
                Dgv1.DataSource = Controlador.MostrarEmpleados();
               // MostrandoBitacora = false;
                //btnVerRegistros.Text = "Ver TIPOS"; // Cambié el texto
                //this.Text = $"Sistema - Empleados - Usuario: {usuarioActual}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                   Controlador.InsertarEmpleado(txtNombre.Text, txtDesc.Text, txtMarca.Text);
                    MessageBox.Show("Se insertó correctamente");
                    //auditoriaBitacora.RegistrarAccion(1, 101, "INSERT tipo_puesto", true);
                    auditoriaBitacora.RegistrarAccion(idUsuarioConectado, codigoAplicacion, "INS", bEstado);

                    //MostrarEmpleados();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }


            //EDITAR
            if (Editar == true)
            {
                try
                {
                    Controlador.EditarEmpleado(txtNombre.Text, txtNombre.Text, txtDesc.Text, txtMarca.Text);
                    MessageBox.Show("Se editó correctamente");
                    MostrarEmpleados();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }


        }
        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
        }
        private void btnVerRegistros_Click(object sender, EventArgs e)
        {
            actualizardatagriew();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Dgv1.SelectedRows.Count > 0)
            {   
                auditoriaBitacora.RegistrarAccion(idUsuarioConectado, codigoAplicacion, "UPD", bEstado);

                Editar = true;
                txtNombre.Text = Dgv1.CurrentRow.Cells["Pk_Id_TIPO_PUESTO"].Value.ToString();
                txtDesc.Text = Dgv1.CurrentRow.Cells["Cmp_NOMBRE_PUESTO"].Value.ToString();
                txtMarca.Text = Dgv1.CurrentRow.Cells["Cmp_SALARIO"].Value.ToString();
                txtNombre.Text = Dgv1.CurrentRow.Cells["Pk_Id_TIPO_PUESTO"].Value.ToString();
                // registrar en bitácora
               
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        
            if (Dgv1.SelectedRows.Count > 0)
            {
                idEmpleado = Dgv1.CurrentRow.Cells["Pk_Id_TIPO_PUESTO"].Value.ToString();
                Controlador.EliminarEmpleado(txtNombre.Text);
                MessageBox.Show("Eliminado correctamente");
                // registrar en bitácora
                auditoriaBitacora.RegistrarAccion(idUsuarioConectado, codigoAplicacion, "DEL", bEstado);

                MostrarEmpleados();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
        }
    }
    }

