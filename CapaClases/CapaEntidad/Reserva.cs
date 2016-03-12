using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Reserva
    {
        [Description("correlativo")]
        public int correlativo { get; set; }

        [Description("numero")]
        public int numero { get; set; }

        [Description("tipo")]
        public string tipo { get; set; }

        [Description("estado")]
        public string estado { get; set; }

        [Description("descripcion")]
        public string descripcion { get; set; }

        [Description("estadoDescripcion")]
        public string estadoDescripcion { get; set; }

        [Description("fechaInicio")]
        public string fechaInicio { get; set; }

        [Description("fechaFin")]
        public string fechaFin { get; set; }

        [Description("montoTotal")]
        public string montoTotal { get; set; }

        [Description("codigoOperacion")]
        public string codigoOperacion { get; set; }

        [Description("cliente")]
        public string cliente { get; set; }

    }
}
