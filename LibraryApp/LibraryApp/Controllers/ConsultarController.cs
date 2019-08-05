using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.Models;
using LibraryApp.LibraryWS;
using System.Data;

namespace LibraryApp.Controllers
{
    public class ConsultarController : Controller
    {
        LibraryWebServiceSoapClient cliente = new LibraryWS.LibraryWebServiceSoapClient();
        DataTable tabla = new DataTable();
        // GET: Consultar
        [HttpGet]
        public ActionResult Buscar()
        {
            List<Catalogo> ListaLibros = new List<Catalogo>();
            tabla = cliente.BuscarLibros();
            
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Catalogo _catalogo = new Catalogo();
                _catalogo.codigoLibro = Convert.ToInt32(tabla.Rows[i][0]);
                _catalogo.tituloLibro = tabla.Rows[i][1].ToString();
                _catalogo.autor = tabla.Rows[i][2].ToString();
                _catalogo.disponibilidad = Convert.ToBoolean(tabla.Rows[i][3].ToString());
                _catalogo.codigoUbicacion = Convert.ToInt32(tabla.Rows[i][4].ToString());
                ListaLibros.Add(_catalogo);
            }
            ViewData["CatalogoLibros"] = ListaLibros;
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(Catalogo _catalogo)
        {
            if (ModelState.IsValid)
            {
                tabla = cliente.UbicarLibro(_catalogo.codigoLibro);
                // El codigo del libro ya viene en el post
                _catalogo.tituloLibro = tabla.Rows[0][0].ToString();
                _catalogo.autor = tabla.Rows[0][1].ToString();
                _catalogo.disponibilidad = Convert.ToBoolean(tabla.Rows[0][2]);
                _catalogo.ubicacion = tabla.Rows[0][3].ToString();
                _catalogo.signatura = tabla.Rows[0][4].ToString();
                return View("Ubicacion",_catalogo);
            }else
                return View();
        }
    }
}