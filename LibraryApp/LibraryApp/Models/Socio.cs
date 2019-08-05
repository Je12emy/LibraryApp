using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Socio
    {
        public int codigoSocio { get; set; }
        public string nombreSocio { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string direccionSocio { get; set; }
        public string clave { get; set; }
    }
}