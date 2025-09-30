using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo_Menu
{
    class Conexion
    {
            // Método para abrir conexión ODBC
            public OdbcConnection AbrirConexion()
            {
                // Creación de la conexión via ODBC
                OdbcConnection conn = new OdbcConnection("Dsn=segundoparcial2k25");
                try
                {
                    conn.Open();
                    Console.WriteLine("Conexión ODBC abierta correctamente");
                }
                catch (OdbcException ex)
                {
                    Console.WriteLine($"Error al conectar: {ex.Message}");
                    throw; // Re-lanzar la excepción para manejarla arriba
                }
                return conn;
            }

            // Método para cerrar la conexión
            public void CerrarConexion(OdbcConnection conn)
            {
                try
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        Console.WriteLine("Conexión ODBC cerrada correctamente");
                    }
                }
                catch (OdbcException ex)
                {
                    Console.WriteLine($"Error al cerrar conexión: {ex.Message}");
                }
            }

            // Método alternativo usando using (recomendado)
            public OdbcConnection CrearConexion()
            {
                return new OdbcConnection("Dsn=controlempleados");
            }
        }




    }

