<%@ Page Title="" Language="C#"
    AutoEventWireup="true" CodeFile="RegistrarCliente.aspx.cs" Inherits="Registro_RegistrarCliente" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Portal De Reserva de Salas</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    
    <link type="text/css" href="../Styles/PaginaPrin.css" rel="stylesheet" />
    <link type="text/css" href="../Styles/Grilla.css" rel="stylesheet" />
    <link type="text/css" href="../Styles/Formulario.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="../Scripts/Plugin/jquery-ui-1.10.2.custom/css/redmond/jquery-ui-1.10.2.custom.css" />
    <script type="text/javascript" src="../Scripts/Plugin/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugin/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugin/jquery-ui-1.10.2.custom/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"></script>
    <script type="text/javascript" src="../Scripts/Plugin/jquery-migrate-1.1.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugin/jquery.cookie.js"></script>
    <script type="text/javascript" src="../Scripts/Plugin/jquery.maskedinput-1.3.min.js"></script>
    <script type="text/javascript" src="../Scripts/General/GrillaMenu.js"></script>
    <script type="text/javascript" src="../Scripts/General/Herramientas.js"></script>
    <style type="text/css">
        .Modulo
        {
            width: 98%;
            margin-top: 1px;
            padding: 0px;
        }
        .Modulo a
        {
            text-decoration: none;
        }
        .ModuloCaption
        {
            width: 100%;
            padding: 2px;
            background-color: #359BD2;
            color: #FFFFFF;
            vertical-align: middle;
            text-align: center;
        }
        .Grupo
        {
            width: 96%;
            top: 0px;
            margin-left: 3%;
            margin-right: 1%;
            border: 1px solid #DAEAF7;
        }
        .GrupoCaption
        {
            width: 100%;
            background-color: #DAEAF7;
            color: #3F78A1;
            vertical-align: middle;
            text-align: center;
        }
        .Menu
        {
            width: 100%;
            top: 0px;
        }
        .Menu a
        {
            padding: 5px;
            color: #000066;
        }
        .Menu a:hover
        {
            background-color: #D9FF66;
            padding-top: 3px;
            padding-bottom: 3px;
            padding-left: 10px;
            color: #0033CC;
        }
        .Menu a:active
        {
            background-color: #FBDC36;
            font-weight: normal;
        }
        
    </style>
    <script type="text/javascript">
        //Controlar Tiempo de duracion de una Session------------------------------------

        function VentanaAutosize() {
            var Alto = $(window).innerHeight() - 40;
            $("#MasterMenu").css("height", Alto)
            $("#MasterContenedor").css("height", Alto);
        }
        function MenuExpandir(CorrelaModulo, CorrelaGrupo) {
            if (CorrelaGrupo != null) {
                //alert(CorrelaModulo);
                $("#" + "dtlMenu_dtlMGrupo_" + CorrelaModulo + "_dtlMMenu_" + CorrelaGrupo).slideToggle("fast");
            }
            else {
                $("#" + "dtlMenu_dtlMGrupo_" + CorrelaModulo).slideToggle("fast");
            }
        }
        function PaginaCargaInicialMPage() {
            VentanaAutosize();
            //
            //Controla el tiempo de duracion de session
            TiempoSessionReiniciar("<%= Session.Timeout %>", true);

        }
        $(document).ready(function (event) {
            //Activando Parametros de Inicializacion
            PaginaCargaInicialMPage();
        })
        $(window).resize(function (e) {
            VentanaAutosize();
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="MasterScreen">
       <asp:HiddenField ID="hdfPostBackTempMPage" runat="server" />
       <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

   <div style="padding-top:8px;width: 700px; margin: 0 auto;">
    <!-- LAS 2 PRIMERAS LINEAS PARA DARLE ESTILO AL DATETIMEPICKER  -->
    <link href="../Scripts/General/PopupDiv/PopupDiv.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/General/PopupDiv/PopupDiv.js"></script>
    <style type="text/css">
        .colorLabel
        {
            color: #58ACFA;
        }
        
        .ocultar
        {
            display: none;
        }
        .PopupDivFomulario
        {
            height: 180px;
            width: 400px;
            display: block;
            position: static;
        }
        .PopupDivContenedor
        {
            height: 85px;
        }
        </style>
    <script type="text/javascript">


        //Codificacion de los UpdateProgress----------------------------------------------------------------------
        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_beginRequest(BeginRequest);
        manager.add_endRequest(EndRequest);
        function BeginRequest(sender, args) {
            UProgDivMostrar();
        }
        function EndRequest(sender, args) {
            UProgDivCerrar();
            TiempoSessionReiniciar("<%= Session.Timeout %>");
        }
       
        function validate(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        //--------------------------------------------------------------------------------------------------------
    </script>
    <%--Manejador de Mensajes--%>
    <div id="DivMensaje">
    </div>
    <%--Definicion del Progress de los UpdatePanel--%>
    <div id="UProgDivMascara">
        <div id="UProgDivImagen">
        </div>
    </div>

       
            <div class="ManPrinCabezera">
                <div class="ManPrinCabezeraTitulo">
                    Nueva Cuenta</div>
     <table class="TablaGeneral">
                <tr>
 
                    <td class="tdleftAli" style="width: 5%">
                        <asp:ImageButton ID="btnCancelar" runat="server" 
                            ImageUrl="~/Imagenes/BonMan/Cancelar.png" style="height: 24px" 
                           />
                    </td>

                    <td class="tdcenterAli" style="width: 90%">
                        <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
                <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <h5>
                                Datos Del Cliente
                            </h5>
                        </td>
                    </tr>

                  
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            DNI </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtNroDocumento" runat="server"  Width="50%" 
                              
                                onkeypress='validate(event)' MaxLength="20"
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Nombre
                            (*)</td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtNombre" runat="server"   Width="90%" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Apellido Paterno 
                        </td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        
                        <td style="width: 68%">
                            <asp:TextBox ID="txtApellidoPaterno"  Width="90%" runat="server" MaxLength="30" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Apellido Materno</td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtApellidoMaterno" runat="server"  Width="90%" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            RUC
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="50%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Razón Social
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtDistrito" runat="server" Width="90%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Correo
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtProvincia" runat="server" Width="90%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>              
                    </table>

                <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <h5>
                                Nueva Cuenta
                            </h5>
                        </td>
                    </tr>

                  
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Cuenta de Usuario </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="TextBox1" runat="server"  Width="50%" 
                              
                                onkeypress='validate(event)' MaxLength="20"
                                ></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td class="tdleft" style="width: 30%">
                           Nueva Contraseña
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtClave" runat="server" Width="50%" MaxLength="15" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Ingrese Nuevamente 
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtClaveComprobar" runat="server" Width="50%" MaxLength="15" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    </table>




                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
                                                    />


</div>
      
    </div>
    </form>
</body>
</html>
