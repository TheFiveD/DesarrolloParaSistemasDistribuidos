using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_USUARIO
	{
		#region "Entidades y Propiedades"
		[Description("COD_USUARIO")]
        public String COD_USUARIO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }
		[Description("APELLIDO_PATERNO")]
        public String APELLIDO_PATERNO { get; set; }
        [Description("APELLIDO_MATERNO")]
        public String APELLIDO_MATERNO { get; set; }
        [Description("APELLIDO_NOMBRES")]
        public String APELLIDO_NOMBRES { get; set; }
        [Description("USUARIO_LOGIN")]
        public String USUARIO_LOGIN { get; set; }
        //
         [Description("N_DOCUMENTO")]
          public string N_DOCUMENTO { get; set; }
         [Description("APE_PATERNO")]
        public string APE_PATERNO { get; set; }
         [Description("APE_MATERNO")]
        public string APE_MATERNO { get; set; }
         [Description("FECHA_NACIMIENTO")]
        public string FECHA_NACIMIENTO { get; set; }
         [Description("EMAIL")]
         public string EMAIL { get; set; }
         [Description("USUARIO_CLAVE")]
        public string USUARIO_CLAVE { get; set; }

        [Description("COD_GRUPO")]
         public string COD_GRUPO { get; set; }
        [Description("COD_EMPRESA")]
        public string COD_EMPRESA { get; set; }

        [Description("COD_AREA")]
        public string COD_AREA { get; set; }
        [Description("COD_CARGO")]
        public string COD_CARGO { get; set; }
        [Description("COD_CATEGORIA")]
        public string COD_CATEGORIA { get; set; }
        [Description("IDOPCION")]
        public string IDOPCION { get; set; }
        [Description("COD_OPCION")]
        public string COD_OPCION { get; set; }
       

        [Description("NOMBRE")]
        public string NOMBRE { get; set; }
         [Category("LIST"), Description("ListGRUPO")]
        public List<Ent_USUARIO> ListGRUPO { get; set; }

         [Category("LIST"), Description("ListEMPRESA")]
         public List<Ent_USUARIO> ListEMPRESA { get; set; }

         [Category("LIST"), Description("ListAREA")]
         public List<Ent_USUARIO> ListAREA { get; set; }
         [Category("LIST"), Description("ListCARGO")]
         public List<Ent_USUARIO> ListCARGO { get; set; }
         [Category("LIST"), Description("ListCATEGORIA")]
         public List<Ent_USUARIO> ListCATEGORIA { get; set; }
         [Category("LIST"), Description("ListMODULO")]
         public List<Ent_USUARIO> ListMODULO { get; set; }
        [Category("LIST"), Description("ListPERMISOS")]
         public List<Ent_USUARIO> ListPERMISOS { get; set; }
        [Category("LIST"), Description("ListTIPO_DOCUMENTO")]
        public List<Ent_USUARIO> ListTIPO_DOCUMENTO { get; set; }
        [Category("LIST"), Description("lscDetalle")]
        public List<Ent_USUARIO> lscDetalle { get; set; }
        
        //
         [Description("GRUPO")]
         public string GRUPO { get; set; }
         [Description("EMPRESA")]
         public string EMPRESA { get; set; }

         [Description("DES_CATEGORIA")]
         public string DES_CATEGORIA { get; set; }
         [Description("DES_OPCION")]
         public string DES_OPCION { get; set; }
          [Description("TIPO_DOCUMENTO")]
         public string TIPO_DOCUMENTO { get; set; }

          //TemEliiminar
          [Description("EliTABLA")]
          public String EliTABLA { get; set; }
          [Description("EliVALOR01")]
          public String EliVALOR01 { get; set; }
          [Description("EliVALOR02")]
          public String EliVALOR02 { get; set; }
        [Description("EliVALOR03")]
          public string EliVALOR03 { get; set; }

          [Category("LIST"), Description("ListEliTABLA")]
          public List<Ent_USUARIO> ListEliTABLA { get; set; }

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
        public Ent_USUARIO()
		{
            COD_PERSONA = null;
           

            OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
		}
		#endregion

















    }
}

