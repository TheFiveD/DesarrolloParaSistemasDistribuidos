using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CapaEntidad.GEN
{
	public class Ent_SOLICITUD
	{
		#region "Entidades y Propiedades"
		[Description("NUM_SOLICITUD")]
		public String NUM_SOLICITUD { get; set; }
		[Description("NOM_COMPANIA")]
		public String NOM_COMPANIA { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        [Description("DES_ESTADO")]
        public String DES_ESTADO { get; set; }
        [Description("FECHA_REGISTRO")]
        public String FECHA_REGISTRO { get; set; }
        [Description("FECHA_ENVIO")]
        public String FECHA_ENVIO { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        
        //Campos de Registro -- inicio

        [Description("COD_AREA_EMPRESA")]
        public String COD_AREA_EMPRESA { get; set; }
        [Description("COD_SUBAREA_EMP")]
        public String COD_SUBAREA_EMP { get; set; }
        [Description("DESCRIPCION_AREA")]
        public String DESCRIPCION_AREA { get; set; }


        

        [Description("COD_UBICACION")]
        public String COD_UBICACION { get; set; }
        [Description("DESCRIPCION_UBICACION")]
        public String DESCRIPCION_UBICACION { get; set; }

        [Description("NOMBRE_MATPEL")]
        public String NOMBRE_MATPEL { get; set; }

        [Description("TIPO_ESTADO_MATERIAL")]
        public String TIPO_ESTADO_MATERIAL { get; set; }
        [Description("COMP_PRINCIPAL")]
        public String COMP_PRINCIPAL { get; set; }
        [Description("NUM_CAS")]
        public String NUM_CAS { get; set; }
        [Description("FABRICANTE")]
        public String FABRICANTE { get; set; }
        [Description("SUS_FISCALIZADA")]
        public Object SUS_FISCALIZADA { get; set; }
        [Description("CUMPLE_HOJAS")]
        public Object CUMPLE_HOJAS { get; set; }
        [Description("CAR_INFLAMABLE")]
        public Object CAR_INFLAMABLE { get; set; }
        [Description("CAR_CORROSIVO")]
        public Object CAR_CORROSIVO { get; set; }
        [Description("CAR_REACTIVO")]
        public Object CAR_REACTIVO { get; set; }
        [Description("CAR_EXPLOSIVO")]
        public Object CAR_EXPLOSIVO { get; set; }
        [Description("CAR_TOXICO")]
        public Object CAR_TOXICO { get; set; }
        [Description("CAR_MUTAG")]
        public Object CAR_MUTAG { get; set; }
        [Description("CAR_MEDIO_AMBIENTE")]
        public Object CAR_MEDIO_AMBIENTE { get; set; }
        [Description("CAR_RADIOACTIVO")]
        public Object CAR_RADIOACTIVO { get; set; }

        [Description("TIPO_ENVASE")]
        public String TIPO_ENVASE { get; set; }
        [Description("TAMANO_ENVASE")]
        public String TAMANO_ENVASE { get; set; }
        [Description("TAMANO_PAQUETE")]
        public String TAMANO_PAQUETE { get; set; }
        [Description("NUM_UNIDADES")]
        public String NUM_UNIDADES { get; set; }
        [Description("ORIGEN_DISTRIBUCION")]
        public String ORIGEN_DISTRIBUCION { get; set; }
        [Description("RUTA_TRANSPORTE")]
        public String RUTA_TRANSPORTE { get; set; }

        [Description("MEDIO_TRANSPORTE")]
        public String MEDIO_TRANSPORTE { get; set; }
        [Description("COMPANIA_TRANSPORTE")]
        public String COMPANIA_TRANSPORTE { get; set; }
        [Description("NUM_ENVIO_SEMANA")]
        public Int32 NUM_ENVIO_SEMANA { get; set; }
        [Description("NUM_ENVIO_MES")]
        public Int32 NUM_ENVIO_MES { get; set; }
        [Description("NUM_ENVIO_ANIO")]
        public Int32 NUM_ENVIO_ANIO { get; set; }

        [Description("CANTIDAD_TOTAL")]
        public Int32 CANTIDAD_TOTAL { get; set; }
        [Description("NUM_TRANSPORTE")]
        public Int32 NUM_TRANSPORTE { get; set; }

        [Description("PLAN_CONTING")]
        public Object PLAN_CONTING { get; set; }
        [Description("PERMISO_ESPECIAL")]
        public Object PERMISO_ESPECIAL { get; set; }
        [Description("POLIZA")]
        public Object POLIZA { get; set; }
        [Description("ETIQUETADO")]
        public String ETIQUETADO { get; set; }
        [Description("REALIZA_COMPRA")]
        public String REALIZA_COMPRA { get; set; }

        [Description("EXISTE_PRODUCTO")]
        public Object EXISTE_PRODUCTO { get; set; }
        [Description("PRODUCTO")]
        public String PRODUCTO { get; set; }
        [Description("REEMPLAZARA")]
        public Object REEMPLAZARA { get; set; }
        [Description("NOM_RESPONSABLE")]
        public String NOM_RESPONSABLE { get; set; }

        [Description("RAZON_USO")]
        public String RAZON_USO { get; set; }
        [Description("FORMA_USADO")]
        public String FORMA_USADO { get; set; }

        [Description("CANT_USADO")]
        public Int32 CANT_USADO { get; set; }
        [Description("TIEMPO_USADO")]
        public String TIEMPO_USADO { get; set; }
        [Description("RESIDUOS")]
        public Object RESIDUOS { get; set; }

        [Description("TIPO_RESIDUOS")]
        public String TIPO_RESIDUOS { get; set; }
        [Description("FORMA_DISPO")]
        public String FORMA_DISPO { get; set; }

        [Description("PROC_AMBIENTALES")]
        public String PROC_AMBIENTALES { get; set; }
        [Description("NUM_TRAB_EX")]
        public Int32 NUM_TRAB_EX { get; set; }
        [Description("TIEMPO_EXPUESTOS")]
        public Int32 TIEMPO_EXPUESTOS { get; set; }
        [Description("LUGAR_ALMACENAMIENTO")]
        public String LUGAR_ALMACENAMIENTO { get; set; }

        [Description("SALUD")]
        public String SALUD { get; set; }
        [Description("INFLAMABILIDAD")]
        public String INFLAMABILIDAD { get; set; }
        [Description("REACTIVIDAD")]
        public String REACTIVIDAD { get; set; }
        [Description("ESPECIAL")]
        public String ESPECIAL { get; set; }

        [Description("SIS_VENTILACION")]
        public Object SIS_VENTILACION { get; set; }
        [Description("EXTRACTOR")]
        public Object EXTRACTOR { get; set; }
     
         
        // -- fin
		
		[Category("OUTPUT"), Description("OUTPUTPARAM01")]
		public Object OUTPUTPARAM01 { get; set; }
		[Description("BusCriterio")]
		public String BusCriterio { get; set; }
		[Description("BusValor")]
		public String BusValor { get; set; }
		[Description("RegEstado")]
		public Int32 RegEstado { get; set; }


        
        [Description("ESTADO_ACTIVO")]
        public Object ESTADO_ACTIVO { get; set; }

       

        //CAMPOS DE REVISION AREA AMBIENTAL

        [Description("A_HOJAS_ESP")]
        public Object A_HOJAS_ESP { get; set; }
        [Description("A_ANTIGUEDAD")]
        public Object A_ANTIGUEDAD { get; set; }
        [Description("A_REQUISITOS")]
        public String A_REQUISITOS { get; set; }
        [Description("A_CONFIRMAR")]
        public Object A_CONFIRMAR { get; set; }
        [Description("A_RECOMIENDA")]
        public Object A_RECOMIENDA { get; set; }
        
      
        //CAMPOS DE OBSERVACIONES GENERALES
        [Description("A_OBSERVACIONES")]
        public String A_OBSERVACIONES { get; set; }
        [Description("R_OBSERVACIONES")]
        public String R_OBSERVACIONES { get; set; }
        [Description("S_OBSERVACIONES")]
        public String S_OBSERVACIONES { get; set; }
        [Description("SE_OBSERVACIONES")]
        public String SE_OBSERVACIONES { get; set; }
        //
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }


        [Category("LIST"), Description("ListAREA")]
        public List<Ent_SOLICITUD> ListAREA { get; set; }
        [Category("LIST"), Description("ListUBICACION")]
        public List<Ent_SOLICITUD> ListUBICACION { get; set; }
         [Category("LIST"), Description("ListSUCURSAL")]
        public List<Ent_SOLICITUD> ListSUCURSAL { get; set; }

         [Category("LIST"), Description("ListEliTABLA")]
         public List<Ent_SOLICITUD> ListEliTABLA { get; set; }
        

		#endregion

		#region "Constructor"
        public Ent_SOLICITUD()
		{
			NUM_SOLICITUD = null;
			NOM_COMPANIA = null;
            ESTADO = null;
			FECHA_REGISTRO = null;
			OUTPUTPARAM01 = null;
			BusCriterio = null;
			BusValor = null;
			RegEstado = -1;
            NUM_ENVIO_SEMANA = -1;
            NUM_ENVIO_MES= -1;
            NUM_ENVIO_ANIO= -1;
            CANTIDAD_TOTAL= -1;
            NUM_TRANSPORTE= -1;
            CANT_USADO= -1;
            NUM_TRAB_EX= -1;
            TIEMPO_EXPUESTOS = -1;
		}
		#endregion
	}
}

