using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp.Models
{
    public class Catalogo
    {
        public int codigoLibro { get; set; }
        public string tituloLibro { get; set; }
        public string autor { get; set; }
        public bool disponibilidad { get; set; }
        public int codigoUbicacion { get; set; }

        // Variables para ubicacion del libro
        public string ubicacion { get; set; }
        public string signatura { get; set; }
    }
}