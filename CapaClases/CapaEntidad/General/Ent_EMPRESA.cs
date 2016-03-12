using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_EMPRESA
	{
		#region "Entidades y Propiedades"
		[Description("COD_EMPRESA")]
        public String COD_EMPRESA { get; set; }
        [Description("NOMBRE")]
        public String NOMBRE { get; set; }
        [Description("RUC")]
        public String RUC { get; set; }
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
        public Ent_EMPRESA()
		{
            COD_EMPRESA = null;
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

