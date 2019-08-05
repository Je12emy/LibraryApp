using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using LibraryApp.Models;
using LibraryApp.LibraryWS;

namespace LibraryApp.Controllers
{
    public class SocioController : Controller
    {

        LibraryWebServiceSoapClient cliente = new LibraryWS.LibraryWebServiceSoapClient();
        DataTable tabla = new DataTable();
        // GET: Socio
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IniciarSesion(Socio _socio)
        {
            if (!String.IsNullOrEmpty(_socio.clave))
            {
                if (ModelState.IsValid)
                {
                    tabla = cliente.VerificarSocio(_socio.codigoSocio, _socio.clave);
                    if (Convert.ToBoolean(tabla.Rows[0][0]))
                    {
                        TempData["codigoSocio"] = _socio.codigoSocio.ToString();                        
                        return RedirectToAction("AreaSocio");
                    }
                    else
                    {
                        ViewBag.Error = "Ese codigo de Socio no existe o es erroneo";
                        return View();
                    }
                }
                else
                    return View();
            }
            else {
                ViewBag.Clave = "Por favor ingrese su clave";
                return View();
            }

        }
        [HttpGet]
        public ActionResult AreaSocio() {
            Socio _socio = new Socio();
            

            tabla = cliente.BuscarSocio(Convert.ToInt32(TempData["codigoSocio"]));
            if (tabla.Rows.Count > 0)
            {
                _socio.codigoSocio = Convert.ToInt32(tabla.Rows[0][0].ToString());
                _socio.nombreSocio = tabla.Rows[0][1].ToString();
                _socio.primerApellido = tabla.Rows[0][2].ToString();
                _socio.segundoApellido = tabla.Rows[0][3].ToString();
                _socio.direccionSocio = tabla.Rows[0][4].ToString();
                _socio.clave = tabla.Rows[0][6].ToString();
                int codigoSocio = Convert.ToInt32(TempData["codigoSocio"]);
                TempData["codigoSocio"] = codigoSocio;
                TempData.Keep();

                return View(_socio);
            }
            else
                return RedirectToAction("IniciarSesion");
       
        }
        [HttpGet]
        public ActionResult ModificarInformacion()
        {
            int codigoSocio = Convert.ToInt32(TempData["codigoSocio"]);
            TempData["codigoSocio"] = codigoSocio;
            return View();
        }
        [HttpPost]
        public ActionResult ModificarInformacion(Socio _socio)
        {
            int codigoSocio = Convert.ToInt32(TempData["codigoSocio"]);
            TempData["codigoSocio"] = codigoSocio;
            int i;
            if (ModelState.IsValid)
            {
                i = cliente.ModificarSocio(codigoSocio, _socio.nombreSocio, _socio.primerApellido, _socio.segundoApellido, _socio.direccionSocio);
                if (i > 0)
                {
                    return RedirectToAction("IniciarSesion");
                }
                else
                    return View();
            }
            else
                return View();  
        }
        [HttpGet]
        public ActionResult Registrarme() {
            return View();
        }
        [HttpPost]
        public ActionResult Registrarme(Socio _socio) {
            int i;
            if (ModelState.IsValid)
            {
                i = cliente.AgregarSocio(_socio.nombreSocio, _socio.primerApellido, _socio.segundoApellido, _socio.direccionSocio, true, _socio.clave);
                if (i > 0)
                {
                    // Se registra con exito
                    return RedirectToAction("IniciarSesion");
                }
                else
                    return View();
            }
            else
                return View();
        }

    }
}