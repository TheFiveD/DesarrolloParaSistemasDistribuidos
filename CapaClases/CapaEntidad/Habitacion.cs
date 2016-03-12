using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Habitacion
    {
        [Description("correlativo")]
        public int correlativo { get; set; }
        [Description("numero")]
        public int numero { get; set; }
       
        [Description("piso")]
        public int piso { get; set; }
        [Description("estado")]
        public string estado { get; set; }
        [Description("descripcion")]
        public string descripcion { get; set; }
        [Description("estadoDescripcion")]
        public string estadoDescripcion { get; set; }

        public void asignarEstado()
        {
            if (estado.Trim().Equals("A"))
                estadoDescripcion = "HABILITADO";
            else if (estado.Trim().Equals("R"))
                estadoDescripcion = "RESERVADO";
            else if (estado.Trim().Equals("M"))
                estadoDescripcion = "MANTENIMIENTO";
            else if (estado.Trim().Equals("D"))
                estadoDescripcion = "DESHABILITADO";
            else
                estadoDescripcion = "";
        }

    }
}
