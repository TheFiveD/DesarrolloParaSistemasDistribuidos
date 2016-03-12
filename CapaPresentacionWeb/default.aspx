<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal Contratistas</title>
    <link href="Styles/Formulario.css" rel="stylesheet" type="text/css" />
   
    <script src="Scripts/Plugin/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/General/Herramientas.js" type="text/javascript"></script>
    <style type="text/css">
        #DivMascara
        {
            width: 100%;
        }
        #ImgFondo
        {
            position: absolute;
            width: 100%;
            height: 100%;
            z-index: 0;
            top: 0px;
            left: 0px;
            
        }
        #DivUsuario
        {
            position: absolute;
            width: 300px;
            height: auto;
            top: 50%;
            left: 50%;
            margin-top: -100px;
            margin-left: -140px;
            z-index: 2;
        }
        #DivUsuarioTitulo
        {
            font-size: 17px;
        }
        #DivUsuarioPassword
        {
            position: absolute;
            width: 90%;
            background-color: #FFFFFF;
            top: 30px;
            padding: 5px 0px 5px 0px;
            margin: 2px;
        }
        #DivUsuarioCumple
        {
            position: absolute;
            width: 90%;
            height: auto;
            top: 120px;
            padding: 2px;
            margin: 2px;
        }

        /*Fixer: Trabaja con el z-index, las posicion coge desde la pagina
        absolute: establece una posicion fija y la posicion se basa al contenedor que la contenga
        relative: la posicion se basa al ultimo elemento*/
    </style>
    <script type="text/javascript">
        function VentanaAutosize() {
            var Alto = $(window).outerHeight();
            $("#DivMascara").css("height", Alto);
        }
        //Ocultando Mensaje
        function LimpiarMensaje() {
            MensajeSpam("");
            $("#DivMensaje").fadeOut("fast"); //Ocultando Div
        }
        function PaginaCargaInicial() {
            //PintarFocoControl();
            //
            //DivMascara Autozise
            if ($("#<%= hdfParamInicial.ClientID  %>").val() == '') {
                $("#<%= hdfParamInicial.ClientID  %>").val("1");
                VentanaMaximizar();
                VentanaAutosize();
            }
            //
            //Validando Ingreso de Datos
            $("#<% = txtlogin.ClientID %>").attr("onkeyup", "LetraMayuscula(this)");
            //GGR COMENTADO $("#<% = txtcontra.ClientID %>").attr("onkeyup", "LetraMayuscula(this)");
            //
            //Asignando Foco
            $("#<% = txtlogin.ClientID %>").focus();
            //
            //Almcenando Tiempo de duracion de la session
            //$.cookie("SessionTimeout", "<%= Session.Timeout %>" * 60, { path: '/' });
        }
        $(document).ready(function (e) {
            //Activando Parametros de Inicializacion
            PaginaCargaInicial();
            //
            //Seleccionar Contenido de un Text
            $("#<% = txtlogin.ClientID %>").focus(function (event) {
                this.select();
            })
            $("#<% = txtcontra.ClientID %>").focus(function (event) {
                this.select();
            })
            //
            $("#<% = btnisession.ClientID %>").click(function (event) {
                if ($("#<% = txtlogin.ClientID %>").val() == "") {
                    MensajeSpam("Ingrese Login", 1)
                    $("#<% = txtlogin.ClientID %>").focus();
                    return false;
                }
                if ($("#<% = txtcontra.ClientID %>").val() == "") {
                    MensajeSpam("Ingrese Contraseña", 1)
                    $("#<% = txtcontra.ClientID %>").focus();
                    return false;
                }
            })
        });
        $(window).resize(function (e) {
            VentanaAutosize();
        })
        function ImgFondo_onclick() {

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdfParamInicial" runat="server" />
    <div id="DivMensaje">
    </div>
    <div id="DivMascara" >
        <img id="ImgFondo"   alt="" title="" onclick="return ImgFondo_onclick()" />
       
        <div id="DivUsuario">
            <div id="DivUsuarioTitulo">
                Iniciar Sesión</div>
            <div id="DivUsuarioPassword">
                <table class="TablaGeneral2" style="width: 98%">
                    <tr>
                        <td style="width: 30%">
                            Login
                        </td>
                        <td style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtlogin" runat="server" Width="98%" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            Contraseña
                        </td>
                        <td style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtcontra" runat="server" Width="98%" MaxLength="30" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLineSeparador" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdrightAli" colspan="3">
                            <asp:Button ID="btnisession" runat="server" Text="Iniciar Sesión" Width="102px" OnClick="btnisession_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="DivUsuarioCumple" style="color: Blue; font-size: 12px;font-family:sans-serif; width: 300px; padding-top: 5%;">
                 <asp:Literal ID="ltlNuevoUsurario" runat="server" 
                    Text="¿No dispones de una cuenta?">
                 </asp:Literal>
               
                <p style="color:Black"> <asp:HyperLink   ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Registro/RegistrarCliente.aspx">Resgitrate Ahora</asp:HyperLink></p>
           
                <asp:Literal ID="ltlCumplePersona" runat="server" 
                    Text="Importante: Cada usuario es responsable de mantener su contraseña. Si Usted olvidó su contraseña, envíe su solicitud al correo:"></asp:Literal><p style="color:Black">Martha.Villamarin@elremanso.com</p>
            </div>
            
         
        </div>
    </div>
    </form>
</body>
</html>
