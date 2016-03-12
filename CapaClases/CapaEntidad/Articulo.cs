using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Articulo
    {
        [Description("numero")]
        public string numero { get; set; }
        [Description("descripcion")]
        public string descripcion { get; set; }
        [Description("cantidad")]
        public string cantidad { get; set; }
        [Description("precioUnitario")]
        public string precioUnitario { get; set; }
        [Description("precioTotal")]
        public string precioTotal { get; set; }
    }
}
