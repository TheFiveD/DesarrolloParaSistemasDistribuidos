using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
using Herramienta;
using CapaEntidad;
//
public partial class MPageSistema : System.Web.UI.MasterPage
{

   
    Utilitarios HerUtil = new Utilitarios();
    
    #region "Procedimiento Principales"
    private void MenuCargando()
    {     
        Usuario login = (Usuario)Session["LoginUsuario"];
        lblPUsuario.Text = login.apellidos.Trim() + " , " + login.nombre.Trim();

        TreeNode bandejaReserva = new TreeNode();
        TreeNode registrarReserva = new TreeNode();
        TreeNode reserva = new TreeNode();

        //PRINCIPAL
        TreeView1.Nodes.Add(new TreeNode("Reservas", "RS", "../Imagenes/General/folderOpen.gif"));
        //BANDEJA DE RESERVA
        bandejaReserva = new TreeNode("Bandeja de Reservas", "BR", "../Imagenes/General/iconText.gif", "../Registro/BandejaReserva.aspx", "_self");
        //AGREGAR EN PADRE RESERVA
        reserva.ChildNodes.Add(bandejaReserva);

        if ("ADMIN".Equals(login.tipoUsuarioDescripcion.Trim()))
        {
            //RESERVA
            //registrarReserva = new TreeNode("Reserva de Sala", "RR", "../Imagenes/General/iconText.gif", "../Registro/ReservarSala.aspx", "_self");
        }
        else
        {
            //RESERVA
            registrarReserva = new TreeNode("Reserva de Sala", "RR", "../Imagenes/General/iconText.gif", "../Registro/ReservarSala.aspx", "_self");
            reserva.ChildNodes.Add(registrarReserva);
        }
             
       
        
        //AREGAR AL ARBOL 
        TreeView1.Nodes.Add(reserva);       
      
    }

    #endregion

    #region "Controles"
    protected void lkbPCerrarSession_Click(object sender, EventArgs e)
    {
        SesionLUsuarioCerrar(this);
    }
    public void SesionLUsuarioCerrar(System.Web.UI.MasterPage page)
    {
        HerUtil.SesionLimpiar(page.Session);
        page.Response.Redirect("~/default.aspx");
    }

    #endregion

    #region "WebForm"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            MenuCargando();
        }
    }
    #endregion

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
