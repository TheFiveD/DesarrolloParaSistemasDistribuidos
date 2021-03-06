using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_CARGO
	{
		#region "Entidades y Propiedades"
		[Description("COD_CARGO")]
        public String COD_CARGO { get; set; }
        [Description("NOMBRE")]
        public String NOMBRE { get; set; }
		[Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("ESTADO_ACTIVO")]
		public Object ESTADO_ACTIVO { get; set; }
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }
		#endregion

		#region "Constructor"
        public Ent_CARGO()
		{
            COD_CARGO = null;
            NOMBRE = null;
            OBSERVACIONES = null;
            OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
		}
		#endregion
	}
}

