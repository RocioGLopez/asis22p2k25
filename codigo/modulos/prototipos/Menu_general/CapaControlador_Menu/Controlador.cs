using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////librerias////////
using System.Data.Odbc;
using CapaModelo_Menu;
using System.Data;
/////////////////////////


namespace CapaControlador_Menu
{
    public class Controlador
    {
        static Conexion cn = new Conexion();
        //variable para acceder a la clase de sentencias
        Sentencia sn = new Sentencia();
         string connectionString = "Dsn=controlempleados";


        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public static DataTable MostrarEmpleados()
        {
            DataTable tabla = new DataTable();
            OdbcConnection conn = null;

            try
            {
                conn = cn.conexion();
                string consulta = "SELECT Pk_Id_TIPO_PUESTO, Cmp_NOMBRE_PUESTO, Cmp_SALARIO FROM tipo_puesto ";

                using (OdbcCommand comando = new OdbcCommand(consulta, conn))
                using (OdbcDataAdapter da = new OdbcDataAdapter(comando))
                {
                    da.Fill(tabla);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar empleados: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    cn.desconexion(conn);
            }
        }



        // SOLO 3 PARÁMETROS - MySQL genera el código automáticamente
        public static void InsertarEmpleado(string tipo, string puesto, string salario)
        {
            OdbcConnection conn = null;

            try
            {
                conn = cn.conexion();
                string consulta = @"INSERT INTO tipo_puesto 
                                  (Pk_Id_TIPO_PUESTO, Cmp_NOMBRE_PUESTO, Cmp_SALARIO) 
                                  VALUES (?, ?, ?)";

                using (OdbcCommand comando = new OdbcCommand(consulta, conn))
                {
                    comando.Parameters.AddWithValue("?", tipo);
                    comando.Parameters.AddWithValue("?", puesto);
                    comando.Parameters.AddWithValue("?", salario);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar empleado: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    cn.desconexion(conn);
            }
        }
        public static void EditarEmpleado(string codigo, string tipo, string puesto, string salario)
        {
            OdbcConnection conn = null;

            try
            {
                conn = cn.conexion();
                string consulta = @"UPDATE tipo_puesto 
                                  SET Pk_Id_TIPO_PUESTO = ?, Cmp_NOMBRE_PUESTO = ?, Cmp_SALARIO = ? 
                                  WHERE Pk_Id_TIPO_PUESTO = ?";

                using (OdbcCommand comando = new OdbcCommand(consulta, conn))
                {
                    comando.Parameters.AddWithValue("?", tipo);
                    comando.Parameters.AddWithValue("?", puesto);
                    comando.Parameters.AddWithValue("?", salario);
                    comando.Parameters.AddWithValue("?", codigo);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar empleado: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    cn.desconexion(conn);
            }
        }





        public static void EliminarEmpleado(string codigo)
        {
            OdbcConnection conn = null;

            try
            {
                conn = cn.conexion();
                string consulta = "DELETE FROM tipo_puesto WHERE Pk_Id_TIPO_PUESTO = ?";

                using (OdbcCommand comando = new OdbcCommand(consulta, conn))
                {
                    comando.Parameters.AddWithValue("?", codigo);

                    int resultado = comando.ExecuteNonQuery();
                    if (resultado == 0)
                        throw new Exception("No se encontró el empleado para eliminar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    cn.desconexion(conn);
            }
        }
    }
}

