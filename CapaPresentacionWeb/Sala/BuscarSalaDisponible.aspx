<%@ Page Title="" Language="C#"
    AutoEventWireup="true" CodeFile="BuscarSalaDisponible.aspx.cs" Inherits="Sala_BuscarSalaDisponible" %>
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

   <div style="padding-top:8px;">
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
        //Ejecutar un PostBack desde un boton dentro de un GridView
        function RegistrarTriggers(control) {
            //Verificando Estado Session
            if (TiempoSessionEstado()) return false;
            //
            Sys.WebForms.PageRequestManager.getInstance()._updateControls(['"<% = udpgrvDatos.ClientID %>"'], [], [control.id], 90);
            return true;
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
                    Listado de Salas Disponibles</div>
                <table class="TablaGeneral">
                    <tr>
                        <td>
                            <table class="TablaGeneral">
                                <tr>
                                   
                                    <td style="width: 60%">
                                        <table class="TablaGeneral">
                                            <tr>
                                                <td style="width: 5%" class="tdleft">
                                                    <asp:Label ID="Label1" runat="server" Text="Criterio:"></asp:Label>
                                                </td>

                                                <td style="width: 25%" class="tdcenterAli">
                                                  <asp:Calendar ID="cldInicio" runat="server" BackColor="White" 
                                                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                                                    Width="200px">
                                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                    <NextPrevStyle VerticalAlign="Bottom" />
                                                    <OtherMonthDayStyle ForeColor="#808080" />
                                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                    <SelectorStyle BackColor="#CCCCCC" />
                                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                                </asp:Calendar>
                                                </td>
                                                <td style="width: 25%" class="tdcenterAli">
                                                  <asp:Calendar ID="cldFin" runat="server" BackColor="White" 
                                                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                                                    Width="200px">
                                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                                    <NextPrevStyle VerticalAlign="Bottom" />
                                                    <OtherMonthDayStyle ForeColor="#808080" />
                                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                                    <SelectorStyle BackColor="#CCCCCC" />
                                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                                </asp:Calendar>
                                                </td>
                                                 <td style="width: 25%" class="tdcenterAli">
                                                    <asp:DropDownList ID="ddlTipoSala" runat="server" Width="90%" Height="16px">                                                      
                                                        <asp:ListItem>Todas las Salas</asp:ListItem>
                                                        <asp:ListItem>Ejecutiva</asp:ListItem>
                                                        <asp:ListItem>Junior</asp:ListItem>
                                                        <asp:ListItem>Principal</asp:ListItem>                                                                                           
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%" class="tdcenterAli">
                                                    <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BonMan/Buscar4.png"
                                                        ToolTip="Buscar Registros"  OnClientClick="return(ManBuscar())" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ManPrinDetalle">
                <div class="GrillaDiv">
                    <asp:UpdatePanel ID="udpgrvDatos" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdfListIndex" runat="server" 
                               />
                            <asp:GridView ID="grvDatos" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                Width="100%" AllowPaging="True" PageSize="20" AllowSorting="True" 
                                OnRowDataBound="grvDatos_RowDataBound" 
                               >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <div id="grvPopupTool<%# Container.DataItemIndex %>" class="grvPopupTool">
                                        </div>
                                        <div id="grvPopupDiv<%# Container.DataItemIndex %>" class="grvPopupDiv" style="width: 90px">
                                        <p>
                                            <img alt="" class="grvPopupDivImg" 
                                                            src="../Imagenes/BonMan/Buscar4.png" /><asp:LinkButton
                                                            ID="btnReservaMenuSel" runat="server" 
                                                            CommandArgument="<%# Container.DataItemIndex %>"
                                                            OnClick="grvDatosBoton_Seleccionar" 
                                                            OnClientClick="return(RegistrarTriggers(this))"
                                                            Text="Seleccionar" />
                                        </p>                                     
                                        </div>
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nº"><ItemTemplate><asp:Label ID="lblccdsnum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" /></asp:TemplateField>
                                    <asp:BoundField DataField="tipo" HeaderText="TIPO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" /></asp:BoundField>
                                    <asp:BoundField DataField="numero" HeaderText="NRO. SALA">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    </asp:BoundField>                                  
                                    <asp:BoundField DataField="capacidad" HeaderText="CAPACIDAD">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="incluye" HeaderText="INCLUYE">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="precio" HeaderText="PRECIO UNITARIO">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    </asp:BoundField>                                 
                                    <asp:BoundField DataField="total" HeaderText="PRECIO TOTAL">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    </asp:BoundField>
                                
                                </Columns>
                                <PagerTemplate>
                                    <table class="TablaGeneral">
                                        <tr>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvFirst" runat="server" CommandArgument="First" CommandName="Page"
                                                    ToolTip="Primera Página"><<</asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%;">
                                                <asp:LinkButton ID="lbtgrvPrev" runat="server" CommandArgument="Prev" CommandName="Page"
                                                    ToolTip="Página Anterior"><</asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 15%;">
                                                <asp:Label ID="lblgrvPagina" runat="server"></asp:Label>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvNext" runat="server" CommandArgument="Next" CommandName="Page"
                                                    ToolTip="Siguiente Página">></asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvLast" runat="server" CommandArgument="Last" CommandName="Page"
                                                    ToolTip="Última Página">>></asp:LinkButton>
                                            </td>
                                            <td class="tdrightAli" style="width: 81%;">
                                                <asp:Label ID="lblgrvRegistroNum" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                                <PagerStyle CssClass="GrillaPagerstyle" />
                                <AlternatingRowStyle CssClass="GrillaRowAlternating" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers><asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" /></Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
</div>
      
    </div>
    </form>
</body>
</html>
