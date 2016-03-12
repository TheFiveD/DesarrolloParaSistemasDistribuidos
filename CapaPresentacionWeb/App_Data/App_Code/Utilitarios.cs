using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// Descripción breve de Utilitarios
/// </summary>

namespace HerraAppCode
{
    public class Utilitarios
    {
        Herramienta.Utilitarios HerUtil = new Herramienta.Utilitarios();
        public void SesionLUsuarioActiva(System.Web.UI.Page page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                //string appPath = page.Request.ApplicationPath;
                page.Response.Redirect("~/default.aspx?MensajeLUsuario=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación");
            }
        }
        public void SesionLUsuarioActivaMaster(System.Web.UI.MasterPage page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                //string appPath = page.Request.ApplicationPath;
                page.Response.Redirect("~/default.aspx?MensajeLUsuario=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación");
            }
        }
        public void SesionLUsuarioCerrar(System.Web.UI.MasterPage page)
        {
            HerUtil.SesionLimpiar(page.Session);
            page.Response.Redirect("~/default.aspx");
        }
        public Boolean SesionLUsuarioActivaMensaje(System.Web.UI.Page page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                HerUtil.MensajeBox(page, "El Período de la Sesión ha Terminado", eMensajeTipo.Msgerror);
                return true;
            }
            return false;
        }
        public Boolean SesionLUsuarioActivaMensaje(System.Web.UI.Page page, UpdatePanel uPanel)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                HerUtil.MensajeBox(uPanel, "El Período de la Sesión ha Terminado", eMensajeTipo.Msgerror);
                return true;
            }
            return false;
        }
    }
}
