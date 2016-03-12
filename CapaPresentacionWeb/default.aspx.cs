 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Herramienta;
using System.Configuration;
using CapaEntidad;

public partial class Login_Login : System.Web.UI.Page
{
    Utilitarios HerUtil = new Utilitarios();

    #region "Procedimiento Principales"
    private void AccesoCuentaUsuario()
    {
        try
        {
            //VALIDA LOS DATOS INGRESADOS POR EL USUARIO
            string loginTmp = txtlogin.Text.Trim();
            string usuarioTmp = txtcontra.Text.Trim();

          
            if ("LMENDEZ".Equals(loginTmp.Trim()))
            {
                if ("123456".Equals(usuarioTmp.Trim()))
                {
                    //DECLARA E INSTANCIA LA ENTIDAD USUARIO
                    CapaEntidad.Usuario usuario = new CapaEntidad.Usuario();

                    //OBTIENE LOGIN Y CONTRASENIA INGRESADA POR EL USUARIO
                    usuario.login = txtlogin.Text.Trim();
                    usuario.contrasenia = txtcontra.Text.Trim();
                    usuario.apellidos = "Mendez Albinagorta";
                    usuario.nombre = "Lisbeth";
                    usuario.tipoUsuarioDescripcion = "USER";
                    Session["LoginUsuario"] = usuario;

                    Response.Redirect(Page.ResolveUrl("MasterPage\\MPageSistema.aspx"), true);
                }
                else
                {
                    SetFocus(txtcontra);
                    HerUtil.MensajeBox(this, "Contraseña incorrecta", eMensajeTipo.Msgerror);
                }
            }
            else
            {
                SetFocus(txtlogin);
                HerUtil.MensajeBox(this, "Verifique su cuenta de usuario", eMensajeTipo.Msgerror);
            }


            //ADMINISTRADOR
            if ("KMORALES".Equals(loginTmp.Trim()))
            {
                if ("123456".Equals(usuarioTmp.Trim()))
                {
                    //DECLARA E INSTANCIA LA ENTIDAD USUARIO
                    CapaEntidad.Usuario usuario = new CapaEntidad.Usuario();

                    //OBTIENE LOGIN Y CONTRASENIA INGRESADA POR EL USUARIO
                    usuario.login = txtlogin.Text.Trim();
                    usuario.contrasenia = txtcontra.Text.Trim();
                    usuario.apellidos = "Morales Ruiz";
                    usuario.nombre = "Karla";
                    usuario.tipoUsuarioDescripcion = "ADMIN";
                    Session["LoginUsuario"] = usuario;

                    Response.Redirect(Page.ResolveUrl("MasterPage\\MPageSistema.aspx"), true);
                }
                else
                {
                    SetFocus(txtcontra);
                    HerUtil.MensajeBox(this, "Contraseña incorrecta", eMensajeTipo.Msgerror);
                }
            }
            else
            {
                SetFocus(txtlogin);
                HerUtil.MensajeBox(this, "Verifique su cuenta de usuario", eMensajeTipo.Msgerror);
            }
        }
        catch (AccistExcepcion accEx)
        {
            HerUtil.MensajeBox(this, accEx.mensajeUsuario , eMensajeTipo.Msgerror);

            if (accEx.nroCampo == 1)
            {
                SetFocus(txtlogin);
            }
            else if (accEx.nroCampo == 2)
            {
                SetFocus(txtcontra);
            }
        }
        catch (Exception ex)
        {
            HerUtil.MensajeBox(this, "Error en la capa presentación : Al ontener sesión de usuario", eMensajeTipo.Msgerror);
        }
    
    }
    private void CookieCrear(String UsuarioLogin)
    {
        // Creamos elemento HttpCookie con su nombre y su valor
        HttpCookie addCookie = new HttpCookie("UsuLogin", UsuarioLogin);
        // Si queremos le asignamos un fecha de expiración: mañana
        addCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        // Y finalmente ñadimos la cookie a nuestro usuario
        Response.Cookies.Add(addCookie);
    }
    private void CookieRecoger()
    {
        // Recogemos la cookie que nos interese
        HttpCookie cogeCookie = Request.Cookies.Get("UsuLogin");
        if (cogeCookie != null)
        {
            txtlogin.Text = (String)cogeCookie.Value;
        }
    }
    #endregion


    #region "Controles"
    protected void btnisession_Click(object sender, EventArgs e)
    {
       AccesoCuentaUsuario(); 
    }
    #endregion

    #region "WebForm"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //Capturando mensaje de la session caducada
            if (Request.QueryString["MensajeLUsuario"] != null) {
                HerUtil.MensajeBox(this, Request.QueryString["MensajeLUsuario"].ToString(), eMensajeTipo.Msgerror);
            }
            
            CookieRecoger();

        }
    }
    #endregion

   
   
    
}