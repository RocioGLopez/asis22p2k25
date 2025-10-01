using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_Seguridad;
using System.Data;


namespace CapaControlador_Seguridad
{
   public  class Controlador_Seguridad
    {

        Sentencias sn = new Sentencias();
        public DataTable MostrarBitacora() => sn.Listar();
        //Busca por fecha
        public DataTable BuscarPorFecha(DateTime fecha) => sn.ConsultarPorFecha(fecha);
        //Busca por rango de fechas
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin) => sn.ConsultarPorRango(inicio, fin);
        //Busca por usuario
        public DataTable BuscarPorUsuario(int iIdUsuario) => sn.ConsultarPorUsuario(iIdUsuario);

        //Registrar acciones
        public void RegistrarAccion(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstado)
        {
            sn.InsertarBitacora(iIdUsuario, iIdAplicacion, sAccion, bEstado);
        }
    }
}
