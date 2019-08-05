using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using LibraryApp.LibraryWS;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class BibliotecaController : Controller
    {
        LibraryWebServiceSoapClient cliente = new LibraryWS.LibraryWebServiceSoapClient();
        DataTable tabla = new DataTable();
        // GET: Biblioteca
        public ActionResult Administracion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Catalogo()
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
        [HttpGet]
        public ActionResult Agregar() {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(Catalogo _catalogo)
        {

            if (ModelState.IsValid)
            {
                int i;
                i = cliente.InsertarLibro(_catalogo.tituloLibro, _catalogo.autor, _catalogo.disponibilidad, _catalogo.codigoUbicacion);
                if (i > 0)
                {
                    return RedirectToAction("Catalogo");
                }
                else
                    return View();
            } else
                return View();
        }
        [HttpGet]
        public ActionResult Modificar() {
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(Catalogo _catalogo) {
            if (ModelState.IsValid)
            {
                int i;
                i = cliente.ModificarLibro(_catalogo.codigoLibro,_catalogo.tituloLibro, _catalogo.autor, _catalogo.disponibilidad, _catalogo.codigoUbicacion);
                if (i > 0)
                {
                    return RedirectToAction("Catalogo");
                }
                else
                    return View();
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(Catalogo _catalogo)
        {
            if (ModelState.IsValid)
            {
                int i;
                i = cliente.EliminarLibro(_catalogo.codigoLibro);
                if (i > 0)
                {
                    return RedirectToAction("Catalogo");
                }
                else
                    return View();
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult Socios() {
            List<Socio> ListaSocio = new List<Socio>();
            tabla = cliente.BuscarSocioTodo();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Socio _socio = new Socio();
                _socio.codigoSocio = Convert.ToInt32(tabla.Rows[i][0]);
                _socio.nombreSocio = tabla.Rows[i][1].ToString();
                _socio.primerApellido = tabla.Rows[i][2].ToString();
                _socio.segundoApellido = tabla.Rows[i][3].ToString();
                ListaSocio.Add(_socio);
            }
            ViewData["ListaSocios"] = ListaSocio;
            return View();
        }
        [HttpPost]
        public ActionResult Socios(Socio _socio) {
            if (ModelState.IsValid)
            {
                tabla = cliente.BuscarSocio(_socio.codigoSocio);
                if (tabla.Rows.Count > 0)
                {
                    _socio.nombreSocio = tabla.Rows[0][1].ToString();
                    _socio.primerApellido = tabla.Rows[0][2].ToString();
                    _socio.segundoApellido = tabla.Rows[0][3].ToString();

                    tabla = cliente.ComprobarSocio(_socio.codigoSocio);
                    if (tabla.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(tabla.Rows[0][0]))
                        {
                            ViewBag.Estado = "Fiable";
                        }
                        else
                            ViewBag.Estado = "No Fiable";

                        ValidarEstadoCliente(_socio.codigoSocio);
                        return View("Comprobacion", _socio);
                    }
                    else
                        return View();
                }
                else
                    return View();
            }else
                return View();
        }
        [HttpGet]
        public ActionResult Rentas() {
            List<Prestamo> ListaPrestamos = new List<Prestamo>();
            tabla = cliente.BuscarPrestamosTodo();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Prestamo _prestamo = new Prestamo();
                _prestamo.codigoPrestamo = Convert.ToInt32(tabla.Rows[i][0]);
                _prestamo.codigoSocio = Convert.ToInt32(tabla.Rows[i][1]);
                _prestamo.codigoLibro = Convert.ToInt32(tabla.Rows[i][2]);
                _prestamo.fechaReserva = Convert.ToDateTime(tabla.Rows[i][3]);
                _prestamo.estado = Convert.ToBoolean(tabla.Rows[i][4]);

                ListaPrestamos.Add(_prestamo);
            }
            
            ViewData["ListaPrestamos"] = ListaPrestamos;
            return View();
        }
        [HttpGet]
        public ActionResult AgregarPrestamo() {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarPrestamo(Prestamo _prestamo)
        {
            if (ModelState.IsValid)
            {
                int i;
                i = cliente.InsertarPrestamo(_prestamo.codigoSocio,_prestamo.codigoLibro,_prestamo.fechaReserva,true);
                if (i > 0)
                {
                    return RedirectToAction("Rentas");
                }
                else
                    return View();

            }else
                return View();
        }
        [HttpGet]
        public ActionResult ModificarPrestamo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModificarPrestamo(Prestamo _prestamo) {
            if (ModelState.IsValid)
            {
                int i;
                i = cliente.ModificarPrestamo(_prestamo.codigoPrestamo,_prestamo.codigoSocio, _prestamo.codigoLibro, _prestamo.fechaReserva, _prestamo.estado);
                if (i > 0)
                {
                    ValidarEstadoCliente(_prestamo.codigoSocio);
                    return RedirectToAction("Rentas");
                }
                else
                    return View();

            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult EliminarPrestamo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EliminarPrestamo(Prestamo _prestamo)
        {
            if (ModelState.IsValid)
            {
                int i;
                i = cliente.EliminarPrestamo(_prestamo.codigoPrestamo);
                if (i > 0)
                {
                    ValidarEstadoCliente(_prestamo.codigoSocio);
                    return RedirectToAction("Rentas");
                }
                else
                    return View();

            }
            else
                return View();
        }
        public void ValidarEstadoCliente(int codigoCliente) {
            tabla = cliente.ContarPrestamosSocio(codigoCliente);
            int i;
            if (Convert.ToInt32(tabla.Rows[0][0]) <= 10)
            {
                i = cliente.ModificarEstadoSocio(codigoCliente,true);
            }
            else {
                i = cliente.ModificarEstadoSocio(codigoCliente,false);
            }
        }

    }
}