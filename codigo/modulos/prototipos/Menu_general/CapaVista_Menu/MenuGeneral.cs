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
            Help.ShowHelp(this, rutaAyuda, "MDI.html");
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
                Editar = true;
                txtNombre.Text = Dgv1.CurrentRow.Cells["Pk_Id_TIPO_PUESTO"].Value.ToString();
                txtDesc.Text = Dgv1.CurrentRow.Cells["Cmp_NOMBRE_PUESTO"].Value.ToString();
                txtMarca.Text = Dgv1.CurrentRow.Cells["Cmp_SALARIO"].Value.ToString();
                txtNombre.Text = Dgv1.CurrentRow.Cells["Pk_Id_TIPO_PUESTO"].Value.ToString();
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

