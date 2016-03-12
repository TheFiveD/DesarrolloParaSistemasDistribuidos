using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramienta;
using CapaEntidad;

public partial class Registro_BandejaReserva : System.Web.UI.Page
{
    Utilitarios utilitarios = new Utilitarios();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        List<Reserva> listaHabitacion = new List<Reserva>();
        Usuario login = (Usuario)Session["LoginUsuario"];


        if (IsPostBack == false)
        {
            Reserva reserva1 = new Reserva();

            reserva1.correlativo = 1;
            reserva1.tipo = "Ejecutiva";
            reserva1.numero = 200;
            reserva1.fechaInicio = "15/03/2016";
            reserva1.fechaFin = "15/03/2016";
            reserva1.estado = "PENDIENTE";
            reserva1.montoTotal = "3000";
            reserva1.codigoOperacion = "";

            if ("ADMIN".Equals(login.tipoUsuarioDescripcion.Trim()))
            {
                reserva1.codigoOperacion = "5544515";
                reserva1.cliente = "MENDEZ ALBINAGORTA, LISBETH";

                listaHabitacion.Add(reserva1);

                utilitarios.GrillaLlenar(grvDatosAdmin, listaHabitacion, 0);
            }
            else {
                listaHabitacion.Add(reserva1);

                utilitarios.GrillaLlenar(grvDatos, listaHabitacion, 0);
            }

            Session["ListaReserva"] = listaHabitacion;
           
        }
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void grvReservaBoton_Consultar(Object sender, EventArgs e)
    {
        LinkButton Boton = (LinkButton)sender;
        Int32 ListIndex = 0;
        if (Int32.TryParse(Boton.CommandArgument.ToString(), out ListIndex) == false)
        {
            return;
        }
        /*
        if (utilitarios.SesionEstado(Session["ListUsuario"]) == false)
        {
            utilitarios.MensajeBox(udpgrvDatos, "La sesión a caducado; Actualize", eMensajeTipo.Msgerror);
            return;
        }*/
    }

    protected void grvReservaBoton_Operacion(Object sender, EventArgs e)
    {
        LinkButton Boton = (LinkButton)sender;
        Int32 ListIndex = 0;
        if (Int32.TryParse(Boton.CommandArgument.ToString(), out ListIndex) == false)
        {
            return;
        }

        /*
       if (utilitarios.SesionEstado(Session["ListUsuario"]) == false)
       {
           utilitarios.MensajeBox(udpgrvDatos, "La sesión a caducado; Actualize", eMensajeTipo.Msgerror);
           return;
       }*/
    }

    protected void grvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Menu Desplegable
        GridViewRow fila = e.Row;

        if (fila.RowType == DataControlRowType.DataRow)
        {
            String grvPopupTool = "grvPopupTool" + fila.DataItemIndex.ToString();
            String grvPopupDiv = "grvPopupDiv" + fila.DataItemIndex.ToString();
            fila.Cells[0].Attributes.Add("onmouseover", "grvPopupShow('" + grvPopupTool + "','" + grvPopupDiv + "', '" + grvDatos.PageSize + "', '" + fila.RowIndex + "' )");
            fila.Cells[0].Attributes.Add("onmouseout", "grvPopupHide('" + grvPopupTool + "','" + grvPopupDiv + "')");

            //Pintado Grilla
            fila.Attributes.Add("onmouseover", "GrillaChangeBackColor(this, event);");
            fila.Attributes.Add("onmouseout", "GrillaChangeBackColor(this, event);");
        }
    }

    protected void btnItemCancelar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void grvDatosTotales_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvReservaAdminBoton_Consultar(Object sender, EventArgs e)
    {
        LinkButton Boton = (LinkButton)sender;
        Int32 ListIndex = 0;
        if (Int32.TryParse(Boton.CommandArgument.ToString(), out ListIndex) == false)
        {
            return;
        }
         try
        {
           // List<Reserva> listaTmp = (List<Reserva>)Session["ListaReserva"];
    


            //utilitarios.MensajeBox(udpgrvDatos, "Registro Eliminado Correctamente", eMensajeTipo.Msgexito);
        }
        catch (Exception ex)
        {
            utilitarios.MensajeBox(udpgrvDatos, ex.Message.ToString(), eMensajeTipo.Msgerror);
        }
        /*
        if (utilitarios.SesionEstado(Session["ListUsuario"]) == false)
        {
            utilitarios.MensajeBox(udpgrvDatos, "La sesión a caducado; Actualize", eMensajeTipo.Msgerror);
            return;
        }*/
    }

    protected void grvReservaAdminBoton_Operacion(Object sender, EventArgs e)
    {
        LinkButton Boton = (LinkButton)sender;
        Int32 ListIndex = 0;
        if (Int32.TryParse(Boton.CommandArgument.ToString(), out ListIndex) == false)
        {
            return;
        }

        /*
       if (utilitarios.SesionEstado(Session["ListUsuario"]) == false)
       {
           utilitarios.MensajeBox(udpgrvDatos, "La sesión a caducado; Actualize", eMensajeTipo.Msgerror);
           return;
       }*/
    }
}