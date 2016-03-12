using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramienta;
using CapaEntidad;

public partial class Sala_BuscarSalaDisponible : System.Web.UI.Page
{
    Utilitarios utilitarios = new Utilitarios();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Sala> lista = new List<Sala>();

        if (IsPostBack == false)
        {
            Sala sala1 = new Sala();
            sala1.numero = 200;
            sala1.tipo = "Ejecutiva";
            sala1.capacidad = "80";
            sala1.incluye = "Pizarra , Podium , Internet";
            sala1.precio = "1000";
            sala1.total = "4000";

            lista.Add(sala1);
            utilitarios.GrillaLlenar(grvDatos, lista, 0);
        }
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

    protected void grvDatosBoton_Seleccionar(Object sender, EventArgs e)
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