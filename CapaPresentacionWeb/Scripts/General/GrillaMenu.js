function grvPopupShow(PopupTool, PopupDiv, RegTotal, RegActual) {
    if ($("#" + PopupDiv).is(":visible") == true) {
        return;
    }
    var position = $("#" + PopupTool).position();
    var MenWidth = $("#" + PopupDiv).outerWidth();
    var MenHeight = $("#" + PopupDiv).outerHeight() - 19;
    $("#" + PopupTool).css("background", "transparent url(../Imagenes/Grilla/Menu.png) no-repeat")
    if (RegTotal - 4 > RegActual) {
        //Menu Abajo
        $("#" + PopupDiv).css({ "display": "block", "top": position.top - 2, "left": position.left - MenWidth });
    }
    else {
        //Menu Arriba
        $("#" + PopupDiv).css({ "display": "block", "top": position.top - MenHeight, "left": position.left - MenWidth });
    }
    //$("#" + PopupDiv).css({ "display": "block", "top": position.top - 2, "left": position.left - $("#" + PopupDiv).outerWidth() });
    //$("#" + PopupDiv).css({ "display": "block", "top": position.top + 14, "left": position.left + 14 });
}
function grvPopupHide(PopupTool, PopupDiv) {
    if ($("#" + PopupDiv).is(":visible") == false) {
        return;
    }
    //alert($(this).parent())
    $("#" + PopupTool).css("background", "transparent url(../Imagenes/Grilla/Herramienta.png) no-repeat")
    $("#" + PopupDiv).css("display", "none")
}