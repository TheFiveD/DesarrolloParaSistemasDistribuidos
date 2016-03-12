using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Sala
    {

        [Description("numero")]
        public int numero { get; set; }
        [Description("tipo")]
        public string tipo { get; set; }     
        [Description("estado")]
        public string estado { get; set; }
        [Description("capacidad")]
        public string capacidad { get; set; }
        [Description("incluye")]
        public string incluye { get; set; }
        [Description("precio")]
        public string precio { get; set; }
        [Description("total")]
        public string total { get; set; }

    }
}
