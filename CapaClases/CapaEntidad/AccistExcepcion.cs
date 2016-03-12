using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class AccistExcepcion : Exception
    {
        public string mensajeUsuario;
        public TipoExcepcion tipoExcepcion;
        public string mensajeAplicacion;
        public int nroCampo; // El campo que está errado

        public AccistExcepcion(Exception ex, string mensajeUsuario,  TipoExcepcion tipoExcepcion)
           
        {
            this.mensajeAplicacion = ex.Message;
            this.mensajeUsuario = mensajeUsuario;
            this.tipoExcepcion = tipoExcepcion;
        }

        public AccistExcepcion(Exception ex, string mensajeUsuario, int nroCampo ,TipoExcepcion tipoExcepcion)
        {
            this.mensajeAplicacion = ex.Message;
            this.mensajeUsuario = mensajeUsuario;
            this.tipoExcepcion = tipoExcepcion;
            this.nroCampo = nroCampo;
        }

    }
}
