var GrillaColorUsed;
var SessionTimeout = 0;
//function GrillaChangeBackColor(RowId, RowFoco) {
//    if (RowFoco) {
//        GrillaColorUsed = RowId.style.backgroundColor;
//        RowId.style.backgroundColor = '#FFFFCC'; //'pink'; AliceBlue #FFFFC0
//    }
//    else {
//        RowId.style.backgroundColor = GrillaColorUsed;
//    }
//}
function GrillaChangeBackColor(RowId, event) {
//    if ($(RowId).css("background-color") == "rgb(217, 255, 102)") {
//        //72FE38
//        return;
//    }
    if (event.type == "mouseover") {
        $(RowId).addClass("GrillaFocus");
    }
    //if (event.type == "onmouseout")
    else {
        $(RowId).removeClass("GrillaFocus");
    }
}
function GrillaCheckBackColor(Control) {
    if ($(Control).is(":checked") == true) {
        $(Control).closest("tr").addClass("GrillaCheck");
    }
    else {
        $(Control).closest("tr").removeClass("GrillaCheck");
    }
}
function GrillaCheckVerifica(Grilla) {
    var CheckActivo = 0;
    $("#" + Grilla + " input:checkbox").each(function (event) {
        if (this.checked) {
            CheckActivo += 1;
            return false;
        }
    });
    return CheckActivo;
    //$("#<%= btnMarCMarca.ClientID %>").click(function (event) {
    //    alert(GrillaCheckVerifica("<%= grvMarDatos.ClientID %>"));
    //});
}

function GrillaCheckActivaTodo(Control, Grilla) {
    Control.checked = !(Control.checked == true);
    $("#" + Grilla + " input:checkbox").attr("checked", function (event) {
        if (this.disabled == false) {
            this.checked = !(this.checked == true);
            GrillaCheckBackColor(this);
        }
    });
    //<HeaderTemplate>
    //        <input id="chkgrvMarTodo" type="checkbox" onclick="GrillaCheckActivaTodo(this,'<%= grvMarDatos.ClientID %>')" />
    //        <asp:CheckBox ID="chkgrvMarTodo" runat="server" OnClick="GrillaCheckActivaTodo(this,'cphPrincipal_grvMarDatos')" />
    //</HeaderTemplate>
}
function GrillaSelectBackColor(Control, SelectData) {
    $(Control).parents('table').find('tr').each(function (event) {
        $(this).removeClass("GrillaSeleccion");
    });
    //$(Control).parents('tr').addClass("GrillaSeleccion");
    $(Control).parent().parent().addClass("GrillaSeleccion");
    if (SelectData != null && SelectData == true) {
        $(Control).select();
    }
}
function GrillaExpandir(Span, Correlativo) {
    if ($(Span).text().trim() == "-") {
        $(Span).text("+");
    }
    else {
        $(Span).text("-");
    }
    var GrillaID = $(Span).parents().find('.Grilla').attr('id').replace('_0', '') + '_' + Correlativo;
    $("#" + GrillaID).fadeToggle('fast');
}
function GrillaExpandirAll(Span, ClaseNombre, SubBotonExpandir) {
    if ($(Span).text().trim() == "-") {
        $(Span).text("+");
    }
    else {
        $(Span).text("-");
    }
    var Lista = $(Span).parents().find('.' + ClaseNombre).attr('id');
    $("#" + Lista + " .Grilla").each(function (event) {
        $(this).fadeToggle('fast');
    });
    if (SubBotonExpandir == true) {
        $("#" + Lista + " .BotonExpandir").each(function (event) {
            if ($(this).text().trim() == "-") { $(this).text("+"); }
            else { $(this).text("-"); }
        });
    }
}
function GrillaTabIndexControl(Grilla, NumColumna, NumFila, TDesplazamiento) {
    var TabIndex = 100;
    var TDespNombre = '';
    //
    //Mostrando Mascara
    $("#UProgDivMascara").css({ "display": "block", "opacity": "0.5" });
    //
    if (TDesplazamiento == 'H') {
        TDespNombre = 'Horizontal';
        $("#" + Grilla + " input:text").each(function (event) {
            $(this).attr("tabindex", TabIndex);
            TabIndex += 1
        });
    }
    else if (TDesplazamiento == 'V') {
        TDespNombre = 'Vertical';
        var Fila = 100;
        var Col = 1;
        TabIndex = Fila;
        $("#" + Grilla + " input:text").each(function (event) {
            if (Col > NumColumna) {
                Col = 1
                Fila += 1;
                TabIndex = Fila
            }
            $(this).attr("tabindex", TabIndex);
            TabIndex += parseInt(NumFila);
            Col += 1;
        })
    }
    MensajeSpam("Desplazamiento " + TDespNombre + " Asignado Correctamente", 3);
    //
    GrillaFocoPrimerControl(Grilla);
    //
    //Ocultando Mascara
    $("#UProgDivMascara").css("display", "none");
}
function GrillaFocoPrimerControl(Grilla) {
    $("#" + Grilla + " input:text").each(function (event) {
        $(this).focus();
        return false;
    });
}
function ListaExpandir(Span, ClaseNombre) {
    if ($(Span).text().trim() == "-") {
        $(Span).text("+");
    }
    else {
        $(Span).text("-");
    }
    var ListaID = $(Span).parents().find('.' + ClaseNombre).attr('id');
    $("#" + ListaID).fadeToggle('fast');
}
function MensajeSpam(MsgbTexto, MsgbTipo) {
    var _Tipo = "Msgerror";
    if (MsgbTipo == 1) { _Tipo = _Tipo; }
    else if (MsgbTipo == 2) { _Tipo = "Msginfo"; }
    else if (MsgbTipo == 3) { _Tipo = "Msgexito"; }
    else if (MsgbTipo == 4) { _Tipo = "Msgalerta"; }
    var LenMensaje = (MsgbTexto.length * 8) + "px";
    $("#DivMensaje").removeClass();
    $("#DivMensaje").addClass(_Tipo);
    $("#DivMensaje").text(MsgbTexto);
    $("#DivMensaje").css("width", LenMensaje);
    $("#DivMensaje").css("left", ($(window).width() - $("#DivMensaje").outerWidth()) / 2);
    $("#DivMensaje").fadeIn("fast");
}
function MensajeSpamTipo(MsgbTexto, MsgbTipo) {
    var LenMensaje = (MsgbTexto.length * 8) + "px";
    $("#DivMensaje").removeClass();
    $("#DivMensaje").addClass(MsgbTipo);
    $("#DivMensaje").text(MsgbTexto);
    $("#DivMensaje").css("width", LenMensaje);
    $("#DivMensaje").css("left", ($(window).width() - $("#DivMensaje").outerWidth()) / 2);
    $("#DivMensaje").fadeIn("fast");
}
function MensajeAlert(Texto) {
    alert(Texto);
}
function ConfirmaDelRegistro(Control, TipoGrilla) {
    //Verificando Estado Session
    if (TiempoSessionEstado()) return false;
    //
    if (TipoGrilla == 'M') {
        //Ventana Mantenimiento - Grilla con Menu
        GrillaSelectBackColor(Control);
    }
    else if (TipoGrilla == 'I') {
        //Ventana Items - Grilla sin Menu
        GrillaSelectBackColor(Control);
    }
    return confirm('¿ Está seguro de Eliminar el Registro Seleccionado ?')
}
function PintarFocoControl() {
    $("input[type=text]").blur(function () {
        $("input[type=text]").removeClass("FocusControl");
    }).focus(function () {
        $(this).addClass("FocusControl");
    })
    $("textarea").blur(function () {
        $("textarea").removeClass("FocusControl");
    }).focus(function () {
        $(this).addClass("FocusControl");
    })
    $("select").blur(function () {
        $("select").removeClass("FocusControl");
    }).focus(function () {
        $(this).addClass("FocusControl");
    });
}
//function UProgDivMostrar() {
//    $("#UProgDivMascara").css({ "display": "block", "opacity": "0.5" });
//    $(".UProgDivContenedor").css("display", "block");
//}
//function UProgDivCerrar() {
//    $("#UProgDivMascara").css("display", "none");
//    $(".UProgDivContenedor").css("display", "none");
//}
function UProgDivMostrar() {
    $("#UProgDivMascara").css({ "display": "block", "opacity": "0.5" });
}
function UProgDivCerrar() {
    $("#UProgDivMascara").css("display", "none");
}
function CentrarObjeto(Control) {
    //Posicionando Control
    if ($('#' + Control).length) {
        $('#' + Control).addClass("CentrarlControl");
    }
}



function VentanaModal(DireccionURL, Argumento, Alto, Ancho, fullscreen, scroll) {
    if (fullscreen != null) {
        Alto = screen.availHeight;
        Ancho = screen.availWidth;
    }
    if (scroll == null) {
        scroll = 0;
    }
    return (window.showModalDialog(DireccionURL, Argumento, 'dialogHeight:' + Alto + 'px;dialogWidth:' + Ancho + 'px;center:1;scroll:' + scroll + ';status:0'));
    //dialogWidth minimo es 250
}
function VentanaOpen(DireccionURL, Titulo, Alto, Ancho, PosArriba, PosIzquierda, resizable) {
    //Tamaño Ventana
    var AltoAncho = '';
    if (Alto == null && Ancho == null) {
        Alto = screen.availHeight;
        Ancho = screen.availWidth;
    }
    
    AltoAncho = 'height=' + Alto + ', width=' + Ancho + ',';
    //
    //Posicion Ventana
    var PosVentana = '';
    if (PosArriba == null || PosIzquierda == null) {
        PosVentana = 'Top=window.screen.height / 2, Left=window.screen.With / 2,';
    }
    else {
        PosVentana = 'Top=' + PosArriba + ', Left=' + PosIzquierda + ',';
    }
    //Tamaño Resible
    var TamCambiante = '';
    if (resizable == null) {
        TamCambiante = 'resizable=1,';
    }
    else {
        TamCambiante = 'resizable=' + resizable + ',';
    }
    var CaracteOtros = 'fullscreen = no,center=yes, status= no, menubar=no, scrollbars=yes, help= no';

    var Caracteristica = AltoAncho + PosVentana + TamCambiante + CaracteOtros
    Titulo.replace(" ", "_");
    //
    window.open(DireccionURL, Titulo, Caracteristica, false);
}
function VentanaOpenSelf(DireccionURL) {
    var Caracteristica = 'fullscreen = yes, ';
    //
    window.open(DireccionURL, '_blank', Caracteristica, false);
}
function RefrescarClickPadre(boton) {
    var sData = dialogArguments;
    var control = sData.document.getElementById(boton);
    if (control != null) {
        control.click();
    }
}
//
function ValidaTexto(ControlTexto, Mensaje) {
    if ($("#" + ControlTexto).val() == "") {
        MensajeSpam(Mensaje);
        $("#" + ControlTexto).focus();
        return false;
    }
    return true;
}
function ValidaCombo(ControlTexto, Mensaje) {
    if ($("#" + ControlTexto).val() == "-" || $("#" + ControlTexto).val() == "--" || $("#" + ControlTexto).val() == "" || $("#" + ControlTexto).val() == null) {
        MensajeSpam(Mensaje);
        $("#" + ControlTexto).focus();
        return false;
    }
    return true;
}
function ValidaComboGuion(ControlTexto, Mensaje) {
    if ($("#" + ControlTexto).val() == "" || $("#" + ControlTexto).val() == null) {
        MensajeSpam(Mensaje);
        $("#" + ControlTexto).focus();
        return false;
    }
    return true;
}
function LetraMayuscula(elemento) {
    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
    var key = (event.keyCode ? event.keyCode : event.which);
    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
        return true;
    }
    elemento.value = elemento.value.toUpperCase();
    //onkeyup
}
function LetraMinuscula(elemento) {
    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
    var key = (event.keyCode ? event.keyCode : event.which);
    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
        return true;
    }
    elemento.value = elemento.value.toLowerCase();
    //onkeyup
}
function EnterBloquear(event) //Evento onKeyDown
{
    var key = (event.keyCode ? event.keyCode : event.which);
    if (key == 13) {
        event.preventDefault();
    }
    //TxtNota.Attributes.Add("onKeyDown", "EnterBloquear(event)");
}
function SoloNumeros(event, Parametros) {
    var key = (event.keyCode ? event.keyCode : event.which);
    var keyini = 48;
    var keyfin = 57;
    //
    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
        return true;
    }
    //Validando Los Caracteres Especiales pasados como parametros
    if (Parametros != null) {
        var KeyEspecial = "";
        for (var vFor = 0; vFor < Parametros.length; vFor++) {
            KeyEspecial = Parametros.charAt(vFor);
            KeyEspecial = KeyEspecial.charCodeAt() //Convierte de Caracter a Ascci
            if (KeyEspecial == key) {
                return true;
            }
        }
    }
    //
    if (key < keyini || key > keyfin) {
        return false;
    }
}
function SoloLetras(event, Parametros) {
    var key = (event.keyCode ? event.keyCode : event.which);
    //
    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
        return true;
    }
    //Validando Los Racateres Especiales pasados como parametros
    if (Parametros != null) {
        var KeyEspecial = "";
        for (var vFor = 0; vFor < Parametros.length; vFor++) {
            KeyEspecial = Parametros.charAt(vFor);
            KeyEspecial = KeyEspecial.charCodeAt() //Convierte de Caracter a Ascci
            if (KeyEspecial == key) {
                return true;
            }
        }
    }
    //
    if ((key < 65 || key > 90) && (key < 97 || key > 122)) { //mayuscula y minusculas
        return false;
    }
}
function SaltoControl(event, Bloquear) {
    var key = (event.keyCode ? event.keyCode : event.which);
    //
    //Enter Abajo
    if (key == 13 || key == 40) { //Validando Teclas Especiales
        if (Bloquear == true) {
            window.event.keyCode = 0;
        }
        else {
            window.event.keyCode = 9;
        }
    }
}
function ValorIsEMailValue(Valor) {
    // regla con expresiones regulares.
    var Patron = /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/;
    // utilizamos test para comprobar si el parametro valor cumple la regla
    if (Patron.test(Valor)) {
        return true;
    }
    else
        return false;
}
function ValorIsEMail(ControlTexto, ValorRequerido) {
    if (ValorRequerido == 0) {
        if ($("#" + ControlTexto).val() == "") {
            return true;
        }
    }
    if ($("#" + ControlTexto).val() == "") {
        MensajeSpam("Ingrese Correo");
        $("#" + ControlTexto).focus();
        return false;
    }
    var Valor = $("#" + ControlTexto).val();
    if (ValorIsEMailValue(Valor)) {
        return true;
    }
    else {
        MensajeSpam("Formato de Correo Incorrecto");
        $("#" + ControlTexto).select().focus();
        return false;
    }
}
function ValorIsURLValue(Valor) {
    // regla con expresiones regulares.
    var Patron = /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/;
    // utilizamos test para comprobar si el parametro valor cumple la regla
    if (Patron.test(Valor)) {
        return true;
    }
    else {
        return false;
    }
}
function ValorIsURL(ControlTexto) {
    if ($("#" + ControlTexto).val() == "") {
        MensajeSpam("Ingrese Dirección URL");
        $("#" + ControlTexto).focus();
        return false;
    }
    var Valor = $("#" + ControlTexto).val();
    if (ValorIsURLValue(Valor)) {
        return true;
    }
    else {
        MensajeSpam("Formato de URL Incorrecto");
        $("#" + ControlTexto).select().focus();
        return false;
    }
}
function ValorIsFechaDia(valor) {
    var fecha = valor.split("/");
    var dia = parseInt(fecha[0], 10);
    var mes = parseInt(fecha[1], 10);
    var ano = parseInt(fecha[2], 10);
    var diaUltimo = (new Date(ano, mes, 0)).getDate();
    if (dia > diaUltimo) {
        return false;
    }
    return true;
}
function ValorIsFechaValue(Valor) {
    // regla con expresiones regulares.
    var Patron = /^([0][1-9]|[12][0-9]|3[01])(\.|-|\/)(0[1-9]|1[012])\2(\d{4})$/;
    // utilizamos test para comprobar si el parametro valor cumple la regla
    if (Patron.test(Valor)) {
        return ValorIsFechaDia(Valor);
    }
    else {
        return false;
    }
}
function ValorIsFecha(ControlTexto, ValorRequerido) {
    if (ValorRequerido == 1) {
        if ($("#" + ControlTexto).val() == "") {
            MensajeSpam("Ingrese Fecha");
            $("#" + ControlTexto).focus();
            return false;
        }
    }
    else if (ValorRequerido == 0) {
        if ($("#" + ControlTexto).val() == "") {
            return true;
        }
    }
    var Valor = $("#" + ControlTexto).val();
    if (ValorIsFechaValue(Valor)) {
        return true;
    }
    else {
        MensajeSpam("Formato Fecha Incorrecto");
        $("#" + ControlTexto).select().focus();
        return false;
    }
}
function ValidaRangoFecha(FechaInicial, FechaFinal, Mensaje) {
    //Valida
    if (ValorIsFecha(FechaInicial, 1) == false) return false;
    if (ValorIsFecha(FechaFinal, 1) == false) return false;
    //
    //Captura
    var FechaIni = $("#" + FechaInicial).val();
    var FechaFi = $("#" + FechaFinal).val();
    //
    //Desglosando Fecha 01
    var fecha01 = FechaIni.split("/");
    var dia01 = parseInt(fecha01[0], 10);
    var mes01 = parseInt(fecha01[1], 10);
    var ano01 = parseInt(fecha01[2], 10);
    //Desglosando Fecha 02
    var fecha02 = FechaFi.split("/");
    var dia02 = parseInt(fecha02[0], 10);
    var mes02 = parseInt(fecha02[1], 10);
    var ano02 = parseInt(fecha02[2], 10);
    //Calculando Dias
    var DTotal01 = parseInt(dia01 + (mes01 * 30) + ano01);
    var DTotal02 = parseInt(dia02 + (mes02 * 30) + ano02);
    //Validando Año
    if (ano01 < ano02) {
        return true;
    }
    //Validando Rango Fecha
    if (DTotal01 > DTotal02) {
        MensajeSpam((Mensaje == null) ? "La Fecha Inicial debe ser Menor al del Final" : Mensaje);
        $("#" + FechaInicial).focus();
        return false;
    }
    return true;
}
function VentanaMaximizar() {
    try {
        moveTo(0, 0);
        resizeTo(screen.availWidth, screen.availHeight)
    } 
    catch (e) {
        //alert('Error en el posicionamiento de la Ventana'); //works
    }
}
function PopupVenCItemsCentrar(ScrollBar) {
    //Posicionando Contenedor
    var Alto = $(window).innerHeight() - $('#PopupVenTitulo').outerHeight();
    $("#PopupVenContenedor").css("top", $('#PopupVenTitulo').outerHeight());
    $("#PopupVenContenedor").css("height", Alto);
    //
    //Posicionado Contenedor Items
    var _Left = ($('#PopupVenContenedor').width() - $('#PopupVenContenedorItems').outerWidth()) / 2;
    var _Top = ($('#PopupVenContenedor').height() - $('#PopupVenContenedorItems').outerHeight()) / 2;
    if (ScrollBar != null) {
        _Left = 7;
        if (Alto < $('#PopupVenContenedorItems').outerHeight()) {
            _Top = 7;
        }
    }
    $('#PopupVenContenedorItems').css({
        left: _Left,
        top: _Top
    });

}
function FechaActual() {
    var Fecha = new Date();
    var dia = parseInt(Fecha.getDate(), 10);
    var mes = parseInt((Fecha.getMonth() + 1), 10);
    var ano = parseInt(Fecha.getFullYear(), 10);
    if (dia <= 9) { dia = "0" + dia; }
    if (mes <= 9) { mes = "0" + mes; }
    return (dia + "/" + mes + "/" + ano);
}
//Controlar Tiempo de duracion de una Session------------------------------------
function TiempoSessionReiniciar(SesionTiempo, Reiniciar) {
    if ($("#DivMensaje").text().indexOf("Sesión ha Terminado") != -1 ) {
        SessionTimeout = 0;
        return;
    }
    if (Reiniciar != null) {
        SessionTimeout = SesionTiempo * 60;
    }
    else {
        if (SessionTimeout > 0) {
            SessionTimeout = SesionTiempo * 60;
        }
    }
}
function TiempoSessionEstado() {
    if (SessionTimeout <= 0) {
        MensajeSpam("El Período de la Sesión ha Terminado");
        return true;
    }
    return false;
}

//---------------------------------------------------------------------------------
//Continuación  <newline> \ 
//Nueva línea  NL (LF) \n 
//Tab horizontal  HT \t 
//Backspace  BS \b 
//Vuelta carro  CR \r 
//Avance página  FF \f 
//Backslash  \ \\ 
//Comillas simples  ' \' 
//Comillas dobles  " \" 


//Ejemplos por usar
//function SoloNumeros(event, Entrada, Espacio) {
//    var key = (event.keyCode ? event.keyCode : event.which);
//    var keyini = 0;
//    var keyfin = 0;
//    //
//    if (Entrada == 0) { //Solo Numeros
//        keyini = 48;
//        keyfin = 57;
//    }
//    else if (Entrada == 1) { //Solo Numeros Incluye (,-.) 44 45 46
//        keyini = 44;
//        keyfin = 57;
//    }
//    else if (Entrada == 2) //Solo Numeros Incluye ( ()*+,-./:;=<> ) 40 41 42 43 44 45 46 47 58 59 60 61
//    {
//        keyini = 40;
//        keyfin = 62;
//    }
//    else if (Entrada == 3) //Solo Numeros y / (Caso Fecha)
//    {
//        keyini = 47;
//        keyfin = 57;
//    }
//    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
//    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
//        return true;
//    }
//    else if (Espacio == 1 && key == 32) { //Validando Espacio
//        return true;
//    }
//    //
//    if (key < keyini || key > keyfin) {
//        return false;
//    }
//}
//function SoloLetras(event, Espacio) {
//    var key = (event.keyCode ? event.keyCode : event.which);
//    //
//    //backspace, delete, tab or (Derecha Arriba Izquierda Abajo)
//    if (key == 8 || key == 46 || key == 9 || (key >= 37 && key <= 40)) { //Validando Teclas Especiales
//        return true;
//    }
//    else if (Espacio == 1 && key == 32) { //Validando Espacio
//        return true;
//    }
//    //
//    if ((key < 65 || key > 90) && (key < 97 || key > 122)) { //mayuscula y minusculas
//        return false;
//    }
//}
//function LetraMayuscula(event)//INGRESAR SOLO LETRAS MAYUSCULA Evento onKeypress
//{
//    var textoOriginal = String.fromCharCode(window.event.keyCode);
//    window.event.keyCode = 0;
//    var textoMayuscula = textoOriginal.toUpperCase();
//    window.event.keyCode = textoMayuscula.charCodeAt();
//    return false;
//}
//event.preventDefault(); //Impide la Escritura
