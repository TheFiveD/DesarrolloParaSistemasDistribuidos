<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MPageSistema.master" 
AutoEventWireup="true" CodeFile="ReservarSala.aspx.cs" Inherits="Registro_ReservarSala" %>
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
            width: 400px; /* display:block; 
            position: static;*/
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
        //Eventos keydown dentro del Formulario
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

        function openPopUp(url) {
            newwindow = window.open(url, 'name', 'height=400,width=1000');
            if (window.focus) { newwindow.focus() }
            return false;
        }


        var my_window = null;

        function popupwindow(url, title, w, h) {
            var screenLeft = 0, screenTop = 0;
            var windowWidth = 0, windowHeight = 0;
            var newTop = 0, newLeft = 0;

            if (typeof window.screenLeft !== 'undefined') {
                screenLeft = window.screenLeft;
                screenTop = window.screenTop;
            }
            else if (typeof window.screenX !== 'undefined') {
                screenLeft = window.screenX;
                screenTop = window.screenY;
            }

            //console.log(screenLeft + ',' + screenTop);

            windowWidth = window.innerWidth;
            windowHeight = window.innerHeight;

            //console.log(windowWidth + ',' + windowHeight);

            newLeft = screenLeft + (windowWidth / 2) - (w / 2);
            screenTop + (windowHeight / 2);

            if (my_window == null) {
                my_window = window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + newTop + ', left=' + newLeft);
            }
            else {
                if (my_window.closed) {
                    my_window = null;
                    my_window = window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + newTop + ', left=' + newLeft);
                }
                else {
                    my_window.moveTo(newLeft, newTop);
                }
            }

            my_window.focus();

            return false;
        }
    </script>
   
    <%--Manejador de Mensajes--%>
    <div id="DivMensaje">
    </div>
    <%--Definicion del Progress de los UpdatePanel--%>
    <div id="UProgDivMascara">
        <div id="UProgDivImagen">
        </div>
    </div>
     <table class="TablaGeneral">
                <tr>
 
                    <td class="tdleftAli" style="width: 5%">
                        <asp:ImageButton ID="btnCancelar" runat="server" 
                            ImageUrl="~/Imagenes/BonMan/Cancelar.png"  style="height: 24px" 
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
                                Datos del Cliente
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Nombre y Apellidos
                            </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtNombre" runat="server"   Width="90%" MaxLength="100" 
                                ReadOnly="True"></asp:TextBox>
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
                            <asp:TextBox ID="txtApellidoPaterno"  Width="90%" runat="server" MaxLength="30" ReadOnly="True" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            RUC</td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtApellidoMaterno" runat="server"  Width="90%" MaxLength="30" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Teléfono Fijo
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="90%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Celular
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtDistrito" runat="server" Width="90%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>                    
                     <tr>
                        <td class="style1">
                            Correo
                        </td>
                        <td class="style2">
                            :
                         </td>
                        <td class="style3">
                            <asp:TextBox ID="txtCorreo" runat="server" Width="90%" MaxLength="50" 
                                ReadOnly="True" ></asp:TextBox>
                        </td>
                    </tr>
                    
                     <tr>
                        <td class="tdleft" style="width: 30%">
                            Correo Empresa</td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtCelular" runat="server" onkeypress='validate(event)' Width="90%" MaxLength="50" ></asp:TextBox>
                        </td>
                    </tr>
                    </table>

                <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <h5>
                                Datos De la Sala
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Tipo de Sala
                            </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtTipoSala" runat="server"   Width="90%" MaxLength="100" 
                                ReadOnly="True"></asp:TextBox>
                            <asp:ImageButton ID="btnBuscarSala" runat="server" 
                            ImageUrl="~/Imagenes/BonMan/Buscar4.png" 
                                style="height: 18px; padding-left: 10px;" 
                               
                           OnClientClick="return openPopUp('../Sala/BuscarSalaDisponible.aspx')" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            N° Sala 
                        </td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        
                        <td style="width: 68%">
                            <asp:TextBox ID="txtNroSala"  Width="90%" runat="server" MaxLength="30" ReadOnly="True" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Fecha Inicio</td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtFechaInicio" runat="server"  Width="90%" MaxLength="30" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Fecha Fin
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtFechaFin" runat="server" Width="90%" MaxLength="100" 
                                ReadOnly="True" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Hora Inicio
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="TextBox5" runat="server" Width="90%" MaxLength="100" ></asp:TextBox>
                        </td>
                    </tr>                    
                    </table>

                    <!--ADICIONALES ARTICULO-->
                    <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <h5>
                                Adicionales
                            </h5>
                        </td>
                    </tr>
                     <tr>
                                                <td style="width: 30%" class="tdleft">
                                                    <asp:Label ID="Label1" runat="server" Text="Criterio:"></asp:Label>
                                                </td>
                                                <td class="tdcenter" style="width: 2%">
                                                    :
                                                </td>
                                                <td style="width: 30%" class="tdcenterAli">
                                                   <asp:DropDownList ID="ddlArticulo" runat="server"  Height="16px"                                                         
                                                        AutoPostBack="True">
                                                        <asp:ListItem>Seleccionar Artículo</asp:ListItem>
                                                        <asp:ListItem>Micrófono</asp:ListItem>
                                                        <asp:ListItem>Equipo de Sonido</asp:ListItem>
                                                        <asp:ListItem>Equipo Multimedia</asp:ListItem>
                                                        <asp:ListItem>E-cran</asp:ListItem>
                                                        <asp:ListItem>Computadora portátil</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                              
                                                 <td style="width: 30%" class="tdcenterAli">
                                                    <asp:DropDownList ID="ddlCantidad" runat="server"  Height="16px">
                                                        <asp:ListItem>Seleccionar Cantidad</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>   
                                                        <asp:ListItem>4</asp:ListItem>                                               
                                                    </asp:DropDownList>
                                                </td>
                                     
                                                <td style="width: 8%" class="tdcenterAli">
                                                    <asp:ImageButton ID="btnAgregarArticulo" runat="server" ImageUrl="~/Imagenes/Grilla/Next.png"
                                                        ToolTip="Agregar Artículo" Height="16px" />
                                                </td>
                    
                    </tr>  
                  
                    </table>
                                       
               <div class="ManPrinDetalle">
                <div class="GrillaDiv">
                    <asp:UpdatePanel ID="udpgrvDatos" runat="server">
                        <ContentTemplate>
                            
                            <asp:GridView ID="grvDatos" runat="server" AutoGenerateColumns="False" CssClass="Grilla"
                                Width="100%" AllowPaging="False" AllowSorting="True" 
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
                                                            src="../Imagenes/BonMan/Eliminar4.png" />
                                                            <asp:LinkButton
                                                            ID="btnReservaMenuEliminar" runat="server" 
                                                            CommandArgument="<%# Container.DataItemIndex %>"
                                                            OnClick="grvDatos_Boton_Consultar" 
                                                            OnClientClick="return(RegistrarTriggers(this))"
                                                            Text="Consultar" />
                                        </p>                                     
                                        </div>
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nº"><ItemTemplate><asp:Label ID="lblccdsnum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" /></asp:TemplateField>
                                    <asp:BoundField DataField="numero" HeaderText="CODIGO ARTÍCULO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>
                                    <asp:BoundField DataField="descripcion" HeaderText="ARTÍCULO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>                                  
                                    <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" /></asp:BoundField>
                                    <asp:BoundField DataField="precioUnitario" HeaderText="PRECIO UNITARIO"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>                                  
                                    <asp:BoundField DataField="precioTotal" HeaderText="PRECIO TOTAL"><ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" /></asp:BoundField>                                  
                                
                                </Columns>                               
                                <AlternatingRowStyle CssClass="GrillaRowAlternating" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers><asp:AsyncPostBackTrigger ControlID="btnAgregarArticulo" EventName="Click" /></Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
              <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <h5>
                                Totales
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Precio Total de Sala 
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="txtTotalSala" runat="server"   Width="90%" MaxLength="100" 
                                ReadOnly="True"></asp:TextBox>                          
                        </td>
                    </tr>
                    <tr>
                        <td class="tdleft" style="width: 30%">
                           Precio Total Adicionales
                        </td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        
                        <td style="width: 68%">
                            <asp:TextBox ID="txtTotalAdicional"  Width="90%" runat="server" MaxLength="30" ReadOnly="True" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            Precio Total</td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        <td style="width: 68%">
                            <asp:TextBox ID="TextBox3" runat="server"  Width="90%" MaxLength="30" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="tdleft" style="width: 30%">
                            Cuenta BCP (S/.)</td>
                        <td class="tdcenter" style="width: 2%">
                           :
                        </td>
                        <td style="width: 68%">
                            192-1235848888-0-12
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdleft" style="width: 30%">
                            (*) Recomendación 
                        </td>
                        <td class="tdcenter" style="width: 2%">
                            :
                         </td>
                        <td style="width: 68%">
                            Para no perder su reserva debe depositar el 50% del total dentro de las 24 horas
                        </td>
                    </tr>                    
                    </table>
                    <asp:Button ID="btnReservar" runat="server" Text="Reservar"  Width="102px"/>
</asp:Content>
