using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.LOGIS
{
	public class Ent_ALMACEN
	{
		#region "Entidades y Propiedades"
		[Description("COD_ALMACEN")]
		public String COD_ALMACEN { get; set; }
		[Description("COD_UBIGEO")]
		public String COD_UBIGEO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
		[Description("UBI_DIRECCION")]
		public String UBI_DIRECCION { get; set; }
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
        public Ent_ALMACEN()
		{
            COD_ALMACEN = null;
            COD_UBIGEO = null;
            DESCRIPCION = null;
            UBI_DIRECCION = null;
			OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
		}
		#endregion
	}
}

