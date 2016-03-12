using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_PERSONA
	{
		#region "Entidades y Propiedades"
		[Description("ANO")]
		public Int32 ANO { get; set; }
		[Description("COD_DIDENTIDAD")]
		public String COD_DIDENTIDAD { get; set; }
		[Description("COD_ECIVIL")]
		public String COD_ECIVIL { get; set; }
		[Description("COD_ETIPO")]
		public String COD_ETIPO { get; set; }
		[Description("COD_PAIS")]
		public String COD_PAIS { get; set; }
		[Description("COD_PERSONA")]
		public String COD_PERSONA { get; set; }
		[Description("COD_PTIPO")]
		public String COD_PTIPO { get; set; }
		[Description("COD_SECUENCIAL")]
		public Int32 COD_SECUENCIAL { get; set; }
		[Description("COD_SEXO")]
		public String COD_SEXO { get; set; }
		[Description("COD_TCORREO")]
		public String COD_TCORREO { get; set; }
		[Description("COD_TTELEFONO")]
		public String COD_TTELEFONO { get; set; }
		[Description("COD_TVIA")]
		public String COD_TVIA { get; set; }
		[Description("COD_TZONA")]
		public String COD_TZONA { get; set; }
		[Description("COD_UBIGEO")]
		public String COD_UBIGEO { get; set; }
		[Description("ANEXO")]
		public String ANEXO { get; set; }
		[Description("APE_MATERNO")]
		public String APE_MATERNO { get; set; }
		[Description("APE_PATERNO")]
		public String APE_PATERNO { get; set; }
		[Description("APELLIDOS_NOMBRES")]
		public String APELLIDOS_NOMBRES { get; set; }
		[Description("E_MAIL")]
		public String E_MAIL { get; set; }
		[Category("FECHA"), Description("FECHA_NACIMIENTO")]
		public Object FECHA_NACIMIENTO { get; set; }
		[Description("N_DOCUMENTO")]
		public String N_DOCUMENTO { get; set; }
		[Description("NOMBRES")]
		public String NOMBRES { get; set; }
		[Description("NUMERO")]
		public String NUMERO { get; set; }
		[Description("OBSERVACION")]
		public Object OBSERVACION { get; set; }
		[Description("RAZON_SOCIAL")]
		public String RAZON_SOCIAL { get; set; }
		[Description("VIA_INTERIOR")]
		public String VIA_INTERIOR { get; set; }
		[Description("VIA_NOMBRE")]
		public String VIA_NOMBRE { get; set; }
		[Description("VIA_NUMERO")]
		public String VIA_NUMERO { get; set; }
		[Description("ZONA_NOMBRE")]
		public String ZONA_NOMBRE { get; set; }
		[Description("ZONA_REFERENCIAL")]
		public String ZONA_REFERENCIAL { get; set; }
		[Description("DIDENTIDAD")]
		public String DIDENTIDAD { get; set; }
		[Description("ETIPO")]
		public String ETIPO { get; set; }
		[Description("ECIVIL")]
		public String ECIVIL { get; set; }
		[Description("PAIS")]
		public String PAIS { get; set; }
		[Description("SEXO")]
		public String SEXO { get; set; }
		[Description("TVIA")]
		public String TVIA { get; set; }
		[Description("TZONA")]
		public String TZONA { get; set; }
		[Description("DEPARTAMENTO")]
		public String DEPARTAMENTO { get; set; }
		[Description("PROVINCIA")]
		public String PROVINCIA { get; set; }
		[Description("DISTRITO")]
		public String DISTRITO { get; set; }
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }
        [Description("Codigo")]
        public String CODIGO { get; set; }
        [Description("Descripcion")]
        public String DESCRIPCION { get; set; }
        [Description("NOMBRES_CONTACTO")]
        public String NOMBRES_CONTACTO { get; set; }
        [Description("TELEFONO_CONTACTO")]
        public String TELEFONO_CONTACTO { get; set; }
        [Description("COD_EMPRESA")]
        public String COD_EMPRESA { get; set; }
        [Description("COD_SUCURSAL")]
        public String COD_SUCURSAL { get; set; }
        [Description("DES_SUCURSAL")]
        public String DES_SUCURSAL { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        [Description("EMAIL")]
        public String EMAIL { get; set; }
        [Description("RUC")]
        public String RUC { get; set; }
        [Description("COD_EACTIVIDAD")]
        public string COD_EACTIVIDAD { get; set; }
        
		//Lista Objetos
		[Category("LIST"), Description("ListPDCCORREO")]
		public List<Ent_PERSONA> ListPDCCORREO { get; set; }
		[Category("LIST"), Description("ListPDDDOMICILIO")]
		public List<Ent_PERSONA> ListPDDDOMICILIO { get; set; }
		[Category("LIST"), Description("ListPDTTELEFONO")]
		public List<Ent_PERSONA> ListPDTTELEFONO { get; set; }
		[Category("LIST"), Description("ListPDTTIPO")]
		public List<Ent_PERSONA> ListPDTTIPO { get; set; }
        [Category("LIST"), Description("ListTIPODOC")]
        public List<Ent_PERSONA> ListTIPODOC { get; set; }
        [Category("LIST"), Description("ListEACTIVIDAD")]
        public List<Ent_PERSONA> ListEACTIVIDAD { get; set; }
        [Category("LIST"), Description("ListCONTACTOS")]
        public List<Ent_PERSONA> ListCONTACTOS { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PERSONA> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListSUCURSAL")]
        public List<Ent_PERSONA> ListSUCURSAL { get; set; }
        
		//TemEliiminar
		[Description("EliPDCCORREO")]
		public String EliPDCCORREO { get; set; }
		[Description("EliPDDDOMICILIO")]
		public String EliPDDDOMICILIO { get; set; }
		[Description("EliPDTTELEFONO")]
		public String EliPDTTELEFONO { get; set; }
		[Description("EliPDTTIPO")]
		public String EliPDTTIPO { get; set; }

        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }

		#endregion

		#region "Constructor"
		public Ent_PERSONA()
		{
			ANO = -1;
			COD_SECUENCIAL = -1;
			RegEstado = -1;
		}
		#endregion





       
    }
}

