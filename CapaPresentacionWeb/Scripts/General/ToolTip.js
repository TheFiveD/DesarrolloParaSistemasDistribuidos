$('.ToolTip').hide;
jQuery(function ($) {
    $(':has(".ToolTip")').hover(
    //Cuando entra el ratón
		function () {
		    var Separador = 3;
		    var ToolTipcontainer = $(this); //El link o el span donde estará el ToolTip
		    var ToolTip = $(this).children('.ToolTip');
		    var Tooltipheight = ToolTip.height();
		    ToolTip.css({ display: 'block', opacity: 0 });
		    //
		    var Left = ToolTipcontainer.position().left;
		    var Top = ToolTipcontainer.position().top;
		    var Bottom = ToolTipcontainer.parent().outerHeight();
		    //
		    //Capturando Pisicion
		    if (ToolTip.hasClass('arriba') == true) {
		        Bottom += Top - Separador;
		        if (ToolTip.hasClass('centro') == true) {
		            Left += (ToolTipcontainer.outerWidth() / 2) - (ToolTip.outerWidth() / 2);
		        }
		        else if (ToolTip.hasClass('derecha') == true) {
		            Left += ToolTipcontainer.outerWidth();
		        }
		        else if (ToolTip.hasClass('izquierda') == true) {
		            Left += ToolTip.outerWidth();
		        }
		        else {
		            Left += (ToolTipcontainer.outerWidth() / 2) - (ToolTip.outerWidth() / 2);
		        }
		    }
		    else if (ToolTip.hasClass('abajo') == true) {
		        var top = ToolTipcontainer.position().top + ToolTipcontainer.outerHeight() + Separador;
		        if (ToolTip.hasClass('centro') == true) {
		            Left += (ToolTipcontainer.outerWidth() / 2) - (ToolTip.outerWidth() / 2);
		        }
		        else if (ToolTip.hasClass('derecha') == true) {
		            Left += ToolTipcontainer.outerWidth();
		        }
		        else if (ToolTip.hasClass('izquierda') == true) {
		            Left += ToolTip.outerWidth();
		        }
		        else {
		            Left += (ToolTipcontainer.outerWidth() / 2) - (ToolTip.outerWidth() / 2);
		        }
		    }
		    else if (ToolTip.hasClass('centro') == true) {
		        var top = ToolTipcontainer.position().top + ToolTipcontainer.outerHeight() / 2 - ToolTip.outerHeight() / 2;
		        if (ToolTip.hasClass('derecha') == true) {
		            Left += ToolTipcontainer.outerWidth() + Separador;
		        }
		        else if (ToolTip.hasClass('izquierda') == true) {
		            Left += ToolTip.outerWidth() - Separador;
		        }
		        else {
		            Left += ToolTipcontainer.outerWidth() + Separador;
		        }
		    }
		    else {
		        Left += ToolTipcontainer.outerWidth() + Separador;
		        Top += (ToolTipcontainer.outerHeight() / 2) - (ToolTip.outerHeight() / 2);
		    }
		    //Asigando Posicion
		    if (ToolTip.hasClass('arriba') == true) {
		        ToolTip.css({ bottom: Bottom, left: Left });
		    }
		    else {
		        ToolTip.css({ top: Top, left: Left });
		    }
		    //Animamos
		    ToolTip.animate({ opacity: '1' });
		},
//Cuando sale el ratón
		function () {
		    //Definimos otra vez las variables que usamos y lo animamos
		    var ToolTipcontainer = $(this);
		    var ToolTip = $(this).children('.ToolTip');
		    ToolTip.fadeOut("fast");
		}
    );
});

var ToolTipText = function () {
    var Divtooltip = $("<div id='DivToolTip'/>");
    var DivID = "DivToolTip"
    var Tooltipheight = 0;
    return {
        Posicion: function (event) {
            var posX = event.pageX;
            var posY = event.pageY;
            Divtooltip.css({ left: posX, top: posY });
        },
        Crear: function (event) {
            if ($("#" + DivID).length == 0) {
                Divtooltip.attr("id", DivID);
                Divtooltip.addClass("ToolTipText");
                Divtooltip.appendTo('body');
            }
            this.Posicion(event);
            Divtooltip.css({ display: 'block', opacity: 0 });
        },
        Mostrar: function (event, Texto) {
            this.Crear(event);
            Divtooltip.html(Texto);
            //
            clearInterval(Divtooltip.timer);
            Divtooltip.timer = setInterval(function (event) {
                Divtooltip.css({ opacity: '1' });
            }, 10);
        },
        MostrarImagen: function (event, Imagen, Alto, Ancho) {
            if (Imagen == null || Imagen == '') { return; }
            this.Crear(event);
            var StyleImagen = "";
            if (Alto != null && Ancho != null) {
                StyleImagen = ' style = height:' + Alto + '; width:' + Ancho;
            }
            Divtooltip.html('<img src=\'' + Imagen + '\'' + StyleImagen + '/>');
            //
            clearInterval(Divtooltip.timer);
            Divtooltip.timer = setInterval(function (event) {
                Divtooltip.css({ opacity: '1' });
            }, 15);
        },
        Ocultar: function (event) {
            //Divtooltip.fadeOut("fast");
            clearInterval(Divtooltip.timer);
            Divtooltip.timer = setInterval(function (event) {
                Divtooltip.css({ opacity: '0' });
            }, 2);
            Divtooltip.remove();
        }
    };
} ();