using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace LibraryApp.Models
{
    public class Prestamo
    {
        public int codigoPrestamo { get; set; }
        public int codigoSocio { get; set; }
        public int codigoLibro { get; set; }
        public DateTime fechaReserva { get; set; }
        public bool estado { get; set; }
    }
}