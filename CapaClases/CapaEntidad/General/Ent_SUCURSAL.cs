using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.MAN
{
	public class Ent_SUCURSAL
	{
		#region "Entidades y Propiedades"
		[Description("COD_SUCURSAL")]
		public String COD_SUCURSAL { get; set; }
		[Description("COD_EMPRESA")]
		public String COD_EMPRESA { get; set; }
        [Description("COD_UBIGUEO")]
        public String COD_UBIGUEO { get; set; }
		[Description("COD_ALMACEN")]
		public String COD_ALMACEN { get; set; }
        [Description("NOMBRE")]
		public String NOMBRE { get; set; }
        [Description("DIRECCION")]
		public String DIRECCION { get; set; }
        [Description("TELEFONO")]
		public String TELEFONO { get; set; }
        [Description("FAX")]
		public String FAX { get; set; }
        [Description("EMAIL")]
		public String EMAIL { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }


        //
        [Description("COD_CAJA")]
        public String COD_CAJA { get; set; }
        [Description("DESCRIPCION_CAJA")]
        public String DESCRIPCION_CAJA { get; set; }
        [Description("NUMERO_AUTORIZACION")]
        public String NUMERO_AUTORIZACION { get; set; }
        [Description("NUMERO_SERIE")]
        public String NUMERO_SERIE { get; set; }
        [Description("NOMBRE_IMPRESORA")]
        public String NOMBRE_IMPRESORA { get; set; }
        [Description("VISOR_DATOS")]
        public Object VISOR_DATOS { get; set; }
        [Description("CAJA_REGISTRADORA")]
        public Object CAJA_REGISTRADORA { get; set; }
        [Description("ESTADO_ACTIVO")]
        public Object ESTADO_ACTIVO { get; set; }

        //
        [Description("T_COMPROBANTE")]
        public String T_COMPROBANTE { get; set; }
        [Description("DES_COMPROBANTE")]
        public String DES_COMPROBANTE { get; set; }
        [Description("COD_SUNAT")]
        public String COD_SUNAT { get; set; }
        [Description("SERIE")]
        public String SERIE { get; set; }
        [Description("NUM_DIGITO")]
        public String NUM_DIGITO { get; set; }
        [Description("TIPO_LONGITUD")]
        public String TIPO_LONGITUD { get; set; }
        //
        [Description("DES_LARGA_TDOCUMENTO")]
        public String DES_LARGA_TDOCUMENTO { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListALMACEN")]
        public List<Ent_SUCURSAL> ListALMACEN { get; set; }
        [Category("LIST"), Description("ListDETALLESUCAJAS")]
        public List<Ent_SUCURSAL> ListDETALLESUCAJAS { get; set; }
        [Category("LIST"), Description("ListDETALLECOMPROBANTE")]
        public List<Ent_SUCURSAL> ListDETALLECOMPROBANTE { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_SUCURSAL> ListEliTABLA { get; set; }

        //
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }
		#endregion

		#region "Constructor"
        public Ent_SUCURSAL()
		{
			COD_SUCURSAL = null;
			COD_EMPRESA = null;
            COD_UBIGUEO = null;
			COD_ALMACEN = null;
			OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
		}
		#endregion
	}
}

