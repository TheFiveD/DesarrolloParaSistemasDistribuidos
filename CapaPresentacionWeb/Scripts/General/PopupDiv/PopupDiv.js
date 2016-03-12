var vPDivFormulario;
function PopupDivMostrar(DivFormulario, ControlFoco, ZIndex) {
    vPDivFormulario = DivFormulario;
    //
    PupupDivMascara(DivFormulario, ControlFoco, ZIndex)
    //$("#PopupDivMascara").fadeTo("fast", 0.6, PopupDivForm(ControlFoco));
}
function PupupDivMascara(DivFormulario, ControlFoco, ZIndex) {
    var DivID = DivFormulario + 'Mascara'
    var DivIDMascara = $("<div id='" + DivID + "'/>");
    if ($("#" + DivID).length == 0) {
        DivIDMascara.attr("id", DivID);
        DivIDMascara.addClass("PopupDivMascara");
        if (ZIndex != null) {
            var ZIndexPopup = 101 + parseInt(ZIndex, 10);
            DivIDMascara.css("z-index", ZIndexPopup);
        }
        DivIDMascara.appendTo("body");
    }
    $("#" + DivID).fadeTo("fast", 0.6, PopupDivForm(ControlFoco, ZIndex));
}
function PopupDivForm(ControlFoco, ZIndex) {
    if (ZIndex != null) {
        var ZIndexPopup = 102 + parseInt(ZIndex, 10);
        $('#' + vPDivFormulario).css("z-index", ZIndexPopup);
    }
    $('#' + vPDivFormulario).fadeIn("fast");
    //
    //Buscando ID controles conformados por el DivFormulario
    var vTitulo = $('#' + vPDivFormulario).find('.PopupDivTitulo').attr("id");
    var vContenedor = $('#' + vPDivFormulario).find('.PopupDivContenedor').attr("id");
    var vContenedorItems = $('#' + vPDivFormulario).find('.PopupDivContenedorItems').attr("id");
    var vPie = $('#' + vPDivFormulario).find('.PopupDivPie').attr("id");
    //
    //Height Contenedor Principal
    Alto = ($('#' + vPDivFormulario).outerHeight(true) - $('#' + vTitulo).outerHeight(true)) - $('#' + vPie).outerHeight(true);
    $('#' + vContenedor).css("height", Alto - 8);
    //
    //Posicionando Contenedor Items
    if (vContenedorItems != null && vContenedorItems != "") {
        $('#' + vContenedorItems).css({
            left: ($('#' + vContenedor).width() - $('#' + vContenedorItems).outerWidth()) / 2,
            top: ($('#' + vContenedor).height() - $('#' + vContenedorItems).outerHeight()) / 2
        });
    }
    //Posicionar Centro 
    PopupDivAutosize();
    //
    //Permite Mover la Ventana Siempre y cuando coja el titulo para su desplazamiento
    $('#' + vPDivFormulario).draggable({ handle: "div.PopupDivTitulo" });
    //
    //
    //Asigando foco al Control
    if (ControlFoco != null) {
        $("#" + ControlFoco + "").focus();
    }
}
function PopupDivAutosize() {
    var vFormulario = $('#' + vPDivFormulario).attr("id");
    if (vFormulario != null && vFormulario != "") {
        if ($('#' + vFormulario).is(':visible')) {
            $('#' + vPDivFormulario).css({
                left: ($(window).width() - $('#' + vPDivFormulario).outerWidth()) / 2,
                top: ($(window).height() - $('#' + vPDivFormulario).outerHeight()) / 2
            });
        }
    }
}
function PopupDivCerrar(DivFormulario) {
    var DivIDMascara = DivFormulario + 'Mascara'
    $('#' + DivFormulario).fadeOut("fast");
    $('#' + DivIDMascara).fadeOut("fast");
    $('#DivMensaje').fadeOut("fast"); //Ocultando Div
}
//
$(window).resize(function (event) {
    PopupDivAutosize();
})
//$(document).ready(function (event) {
//    //Cerrar Popup
//    $('.PopupDivBotonCerrar').click(function () {
//        PopupDivCerrar();
//    })
//})
//function PopupDivAutisizeContenido() {
//    Alto = ($('#' + vPDivFormulario).outerHeight(true) - $('#PopupDivTitulo').outerHeight(true)) - $('#PopupDivPie').outerHeight()
//    $(".PopupDivContenedor").css("height", Alto - 6);
//}

//fast y slow    200 y 600 milliseconds
//Métodos innerWidth() e innerHeight(): 
//Reciben un objeto jQuery y devuelven las dimensiones internas del primer elemento que haya en dicho objeto jQuery, esto es, la anchura y altura respectivamente del elemento contando el padding del elemento pero no el borde. 

//Métodos outerWidth() e outerHeight(): 
//Reciben un objeto jQuery y devuelven las dimensiones externas del primer elemento de dicho objeto jQuery recibido por parámetro, esto es, la anchura y altura respectivamente del elemento contando el padding del elemento y su borde. 

