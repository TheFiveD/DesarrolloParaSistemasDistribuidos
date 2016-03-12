using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Usuario
    {
        public Usuario()
        {
            tipoUsuario = new TipoUsuario();
        }

        [Description("dni")]
        public string dni { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        
        [Description("cuenta")]
        public string cuenta { get; set; }

        [Description("login")]
        public string login { get; set; }

        public string contrasenia { get; set; }


        public string nombre { get; set; }
        public string apellidos { get; set; }

        [Description("fechaNacimiento")]
        public string fechaNacimiento { get; set; }

        public string direccion { get; set; }
        public string distrito { get; set; }

        [Description("correo")]
        public string correo { get; set; }

        public string estado { get; set; }

        [Description("estadoDescripcion")]
        public string estadoDescripcion { get; set; }
        [Description("nombreCompleto")]
        public string nombreCompleto { get; set; }

        [Description("tipoUsuarioDescripcion")]
        public string tipoUsuarioDescripcion { get; set; }

        public void asignarEstado()
        {
            if (estado.Trim().Equals("A"))
                estadoDescripcion = "HABILITADO";
            else if (estado.Trim().Equals("D"))            
                estadoDescripcion = "DESHABILITADO";
            else
                estadoDescripcion = "";
        }
    }
}
