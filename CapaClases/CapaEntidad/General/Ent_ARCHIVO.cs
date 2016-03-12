using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_ARCHIVO
	{
		#region "Entidades y Propiedades"
		[Description("IDARCHIVO")]
        public Int32 IDARCHIVO { get; set; }
        [Description("IDRAIZ")]
        public Int32 IDRAIZ { get; set; }
		[Description("NIVEL")]
        public Int32 NIVEL { get; set; }
        [Description("NOMBRE")]
		public String NOMBRE { get; set; }
         [Description("RUTA")]
		public String RUTA { get; set; }
         [Description("TIPO")]
		public String TIPO { get; set; }
        [Description("ESTADO")]
		public String ESTADO { get; set; }
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
      
        [Category("LIST"), Description("ListGRUPO")]
        public List<Ent_ARCHIVO> ListHIJO { get; set; }
        //   public List<Archivo> listaNivel_2;
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }
		#endregion

		#region "Constructor"
        public Ent_ARCHIVO()
		{
           // COD_CARGO = null;
            NOMBRE = null;
          //  OBSERVACIONES = null;
            OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
		}
		#endregion
	}
}

