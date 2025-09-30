using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaModelo_Menu
{
   public  class Sentencia
    {
        private string connectionString = "Dsn=controlempleados";

        Conexion con = new Conexion();
        // obtener datos de una tabla CAPA MODELO

        public OdbcDataAdapter llenarTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            //consulta la bd y latabla que se le pase como parametro
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }


        public void EliminarEmpleado(string idEmpleado, string usuario)
        {
            try
            {
                // Primero obtener datos del empleado antes de eliminar
                string nombreEmpleado = "";
                using (OdbcConnection conn = new OdbcConnection(connectionString))
                {
                    conn.Open();
                    string querySelect = "SELECT nombre_completo FROM empleados WHERE codigo_empleado = ?";
                    using (OdbcCommand cmd = new OdbcCommand(querySelect, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        nombreEmpleado = cmd.ExecuteScalar()?.ToString();
                    }

                    // Ahora eliminar
                    string queryDelete = "DELETE FROM empleados WHERE codigo_empleado = ?";
                    using (OdbcCommand cmd = new OdbcCommand(queryDelete, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        cmd.ExecuteNonQuery();

                        // Registrar en bitácora
                        string detalles = $"Empleado eliminado: {nombreEmpleado}";
                        //RegistrarBitacora(usuario, "DELETE", Convert.ToInt32(idEmpleado), detalles);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
        }
    }
}
