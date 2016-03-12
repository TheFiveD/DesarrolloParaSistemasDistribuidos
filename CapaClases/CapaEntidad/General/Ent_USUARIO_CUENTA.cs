using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
	public class Ent_USUARIO_CUENTA
	{
		#region "Entidades y Propiedades"				
		[Description("NIVEL_CUENTA")]
		public Int32 NIVEL_CUENTA { get; set; }
        //Usuario Cuenta
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_CATEGORIA")]
        public string COD_CATEGORIA { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }
		[Description("USU_LOGIN")]
		public String USU_LOGIN { get; set; }
		[Description("USU_PASSWORD")]
		public String USU_PASSWORD { get; set; }
        [Description("USU_PASSWORD_REPETIR")]
        public String USU_PASSWORD_REPETIR { get; set; }
        
        [Description("ESTADO_ACTIVO")]
        public Object ESTADO_ACTIVO { get; set; }
        [Description("ESTADO_EDITPASS")]
        public Object ESTADO_EDITPASS { get; set; }
		[Description("PERSONA")]
		public String PERSONA { get; set; }
		[Description("UGRUPO")]
		public String UGRUPO { get; set; }
        //
        [Description("EDITARCONT")]
        public Object EDITARCONT { get; set; }
        //Usuario Cuenta Menú
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
		[Description("ROL_NUEVO")]
        public Object ROL_NUEVO { get; set; }
        [Description("ROL_MODIFICAR")]
        public Object ROL_MODIFICAR { get; set; }
        [Description("ROL_ELIMINAR")]
        public Object ROL_ELIMINAR { get; set; }
        [Description("MOD_DESCRIPCION")]
        public String MOD_DESCRIPCION { get; set; }
        [Description("GRU_DESCRIPCION")]
        public String GRU_DESCRIPCION { get; set; }
        [Description("MEN_DESCRIPCION")]
        public String MEN_DESCRIPCION { get; set; }
        //Sistema Modulo
        [Description("COD_SMODULOS")]
        public String COD_SMODULOS { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("IMAGEN_UBINOMBRE")]
        public String IMAGEN_UBINOMBRE { get; set; }
        [Description("DIRECCION_URL")]
        public String DIRECCION_URL { get; set; }
        [Description("N_ORDEN")]
        public Int32 N_ORDEN { get; set; }
        //Sistema Modulo Menú
        [Description("COD_SMGRUPO")]
        public String COD_SMGRUPO { get; set; }
        [Description("SMGRUPO")]
        public String SMGRUPO { get; set; }
        //
        //Login Validando & Otros
        [Description("MODULOS")]
        public String MODULOS { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }
        [Description("MENU")]
        public String MENU { get; set; }
        [Description("PAGINA")]
        public String PAGINA { get; set; }
        [Description("CODPAGINA")]
        public String CODPAGINA { get; set; }
        [Description("MENU_URL")]
        public String MENU_URL { get; set; }
        [Description("USU_TSECCION_CODIGO")]
        public String USU_TSECCION_CODIGO { get; set; }
        [Description("USU_TSECCION_DESCRIPCION")]
        public String USU_TSECCION_DESCRIPCION { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }        
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Description("EVALUACION")]
        public String EVALUACION { get; set; }
        [Description("COD_EVALUACION")]
        public String COD_EVALUACION { get; set; }
        [Description("COD_DEVALUACION")]
        public String COD_DEVALUACION { get; set; }
        [Description("COD_CURSO_GRUPO")]
        public String COD_CURSO_GRUPO { get; set; }
        [Description("COD_OPCIONES")]
        public String COD_OPCIONES { get; set; }
        [Description("COD_EMPRESA")]
        public String COD_EMPRESA { get; set; }
        //
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }
        //
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("ESTADO_CONTRASENA")]
        public Object ESTADO_CONTRASENA { get; set; }
        [Description("FOTO")]
        public String FOTO { get; set; }
        [Description("CHECK_GRILLA")]
        public Object CHECK_GRILLA { get; set; }
        //
		//Lista Objetos
		[Category("LIST"), Description("ListUCDMMENU")]
		public List<Ent_USUARIO_CUENTA> ListUCDMMENU { get; set; }
        [Category("LIST"), Description("ListMENUMODULO")]
        public List<Ent_USUARIO_CUENTA> ListMENUMODULO { get; set; }
        [Category("LIST"), Description("ListMENUGRUPO")]
        public List<Ent_USUARIO_CUENTA> ListMENUGRUPO { get; set; }
        [Category("LIST"), Description("ListMENUMENU")]
        public List<Ent_USUARIO_CUENTA> ListMENUMENU { get; set; }
        [Category("LIST"), Description("ListCURSOS")]
        public List<Ent_USUARIO_CUENTA> ListCURSOS { get; set; }
        [Category("LIST"), Description("ListEVALUACION")]
        public List<Ent_USUARIO_CUENTA> ListEVALUACION { get; set; }
        [Category("LIST"), Description("ListEVALOPCIONES")]
        public List<Ent_USUARIO_CUENTA> ListEVALOPCIONES { get; set; }
        //
        [Category("LIST"), Description("ListUCDMMMENU")]
        public List<Ent_USUARIO_CUENTA> ListUCDMMMENU { get; set; }
        [Category("LIST"), Description("ListSMDMMENU")]
        public List<Ent_USUARIO_CUENTA> ListSMDMMENU { get; set; }
        //
        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_USUARIO_CUENTA> ListEliTABLA { get; set; }
		#endregion

		#region "Constructor"
		public Ent_USUARIO_CUENTA()
		{
			COD_SECUENCIAL = -1;
			NIVEL_CUENTA = -1;
            N_ORDEN = -1;
            ANO = -1;
			RegEstado = -1;
		}
		#endregion



        
    }
}

