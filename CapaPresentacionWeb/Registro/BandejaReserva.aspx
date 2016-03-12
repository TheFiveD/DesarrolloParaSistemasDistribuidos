<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPageSistema.master"
    AutoEventWireup="true" CodeFile="BandejaReserva.aspx.cs" Inherits="Registro_BandejaReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" runat="Server">
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
        .style1
        {
            text-align: left;
            vertical-align: middle;
            width: 30%;
            height: 21px;
            background-color: #E8F3FB;
        }
        .style2
        {
            text-align: center;
            vertical-align: middle;
            width: 2%;
            height: 21px;
            background-color: #E8F3FB;
        }
        .style3
        {
            width: 68%;
            height: 21px;
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
    <asp:HiddenField ID="hdfRegEstado" runat="server" />
    <asp:MultiView ID="MTVPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwMantenimiento" runat="server">
            <div class="ManPrinCabezera">
                <div class="ManPrinCabezeraTitulo">
                    Listado de Reservas</div>
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
                                                    <asp:DropDownList ID="ddlTipoSala" runat="server" Width="90%" Height="16px">
                                                        <asp:ListItem>Todas las Salas</asp:ListItem>
                                                        <asp:ListItem>Ejecutiva</asp:ListItem>
                                                        <asp:ListItem>Junior</asp:ListItem>
                                                        <asp:ListItem>Principal</asp:ListItem>                                                                                           
                                                    </asp:DropDownList>
                                                </td>
                                                 <td style="width: 25%" class="tdcenterAli">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="90%" Height="16px">
                                                        <asp:ListItem>Todos los Estados</asp:ListItem>
                                                        <asp:ListItem>Pendiente</asp:ListItem>
                                                        <asp:ListItem>Reservado</asp:ListItem>
                                                        <asp:ListItem>Cancelado</asp:ListItem>                                                                                           
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 10%" class="tdcenterAli">
                                                    <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BonMan/Buscar4.png"
                                                        ToolTip="Buscar Registros" OnClick="btnBuscar_Click" OnClientClick="return(ManBuscar())" />
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
                                            <img alt="" src="../Imagenes/BonMan/Modificar4.png" class="grvPopupDivImg" /><asp:LinkButton
                                                        ID="btnMangrvMenuEli" Text="Operación" runat="server" 
                                                        CommandArgument='<%# Container.DataItemIndex %>'
                                                        OnClick="grvReservaBoton_Operacion" 
                                                       
                                                        />
                                            
                                        </p>
                                        <p>
                                            <img alt="" class="grvPopupDivImg" 
                                                            src="../Imagenes/BonMan/Buscar4.png" /><asp:LinkButton
                                                            ID="btnReservaMenuCons" runat="server" 
                                                            CommandArgument="<%# Container.DataItemIndex %>"
                                                            OnClick="grvReservaBoton_Consultar" 
                                                            OnClientClick="return(RegistrarTriggers(this))"
                                                            Text="Consultar" />
                                        </p>                                     
                                        </div>
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nº"><ItemTemplate><asp:Label ID="lblccdsnum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" /></asp:TemplateField>
                                    <asp:BoundField DataField="fechaInicio" HeaderText="FECHA INICIO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:BoundField DataField="fechaFin" HeaderText="FECHA FIN"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>                                  
                                    <asp:BoundField DataField="tipo" HeaderText="TIPO SALA"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" /></asp:BoundField>
                                    <asp:BoundField DataField="numero" HeaderText="NRO. SALA"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="ESTADO">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codigoOperacion" HeaderText="COD. OPER">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="montoTotal" HeaderText="MONTO TOTAL"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" /></asp:BoundField>
                                   <asp:TemplateField headertext="FUNCIÓN">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEnviar" runat="server" ImageUrl="~/Imagenes/Grilla/Next.png"
                                                        ToolTip="Enviar" />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                             <div style="margin-top:20px;margin-bottom:10px;"">
                             <asp:GridView ID="grvDatosAdmin" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                Width="100%" AllowPaging="True" PageSize="20" AllowSorting="True" onrowdatabound="grvDatosTotales_RowDataBound" 
                                >
                                <Columns>
                                 
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <div id="grvPopupTool<%# Container.DataItemIndex %>" class="grvPopupTool">
                                        </div>
                                        <div id="grvPopupDiv<%# Container.DataItemIndex %>" class="grvPopupDiv" style="width: 90px">
                                        
                                        
                                        <p>
                                            <img alt="" src="../Imagenes/BonMan/Modificar4.png" class="grvPopupDivImg" /><asp:LinkButton
                                                        ID="btnMangrvMenuEli" Text="Operación" runat="server" 
                                                        CommandArgument='<%# Container.DataItemIndex %>'
                                                        OnClick="grvReservaAdminBoton_Operacion" 
                                                       
                                                        />
                                            
                                        </p>   
                                        <p>
                                            <img alt="" class="grvPopupDivImg" 
                                                            src="../Imagenes/BonMan/Buscar4.png" /><asp:LinkButton
                                                            ID="btnReservaMenuCons" runat="server" 
                                                            CommandArgument="<%# Container.DataItemIndex %>"
                                                            OnClick="grvReservaAdminBoton_Consultar" 
                                                            OnClientClick="return(RegistrarTriggers(this))"
                                                            Text="Consultar" />
                                        </p>                                  
                                        </div>
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nº"><ItemTemplate><asp:Label ID="lblccdsnum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" /></asp:TemplateField>
                                    <asp:BoundField DataField="cliente" HeaderText="CLENTE"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" /></asp:BoundField>
                                    <asp:BoundField DataField="fechaInicio" HeaderText="FECHA INICIO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:BoundField DataField="fechaFin" HeaderText="FECHA FIN"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>                                  
                                    <asp:BoundField DataField="tipo" HeaderText="TIPO SALA"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:BoundField DataField="numero" HeaderText="NRO. SALA"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    
                                   

                                    <asp:TemplateField headertext="ESTADO">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlEstado" runat="server">
                                            <asp:ListItem Value="1">PENDIENTE</asp:ListItem>
                                            <asp:ListItem Value="2">RESERVADO</asp:ListItem>
                                            <asp:ListItem Value="3">CANCELADO</asp:ListItem>                                            
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="codigoOperacion" HeaderText="COD. OPER">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="montoTotal" HeaderText="MONTO TOTAL"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:TemplateField headertext="FUNCIÓN">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAdminEnviar" runat="server" ImageUrl="~/Imagenes/Grilla/Next.png"
                                                        ToolTip="Enviar" />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                
                                </Columns>
                                <PagerTemplate>
                                    <table class="TablaGeneral">
                                        <tr>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvFirstAdmin" runat="server" CommandArgument="First" CommandName="Page"
                                                    ToolTip="Primera Página"><<</asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%;">
                                                <asp:LinkButton ID="lbtgrvPrevAdmin" runat="server" CommandArgument="Prev" CommandName="Page"
                                                    ToolTip="Página Anterior"><</asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 15%;">
                                                <asp:Label ID="lblgrvPaginaAdmin" runat="server"></asp:Label>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvNextAdmin" runat="server" CommandArgument="Next" CommandName="Page"
                                                    ToolTip="Siguiente Página">></asp:LinkButton>
                                            </td>
                                            <td class="tdcenterAli" style="width: 1%">
                                                <asp:LinkButton ID="lbtgrvLastAdmin" runat="server" CommandArgument="Last" CommandName="Page"
                                                    ToolTip="Última Página">>></asp:LinkButton>
                                            </td>
                                            <td class="tdrightAli" style="width: 81%;">
                                                <asp:Label ID="lblgrvRegistroNumAdmin" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>
                                <PagerStyle CssClass="GrillaPagerstyle" />
                                <AlternatingRowStyle CssClass="GrillaRowAlternating" />
                            </asp:GridView>
                        
                            </div>
                        </ContentTemplate>
                        <Triggers><asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" /></Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:View>       
    </asp:MultiView>
</asp:Content>
