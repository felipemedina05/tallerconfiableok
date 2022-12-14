using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tallerconfiable.Models;
using tallerconfiable.Datos;


namespace tallerconfiable.Controllers
{
    public class MantenedorController : Controller
    {

        PersonaDatos _PersonaDatos = new PersonaDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _PersonaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PersonaModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _PersonaDatos.Guardar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Idpersona)
        {
            //devuelve la vista
            var opersona = _PersonaDatos.Obtener(Idpersona);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult Editar(PersonaModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var resouesta = _PersonaDatos.Editar(oPersona);
            if (resouesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idpersona)
        {
            //devuelve la vista
            var opersona = _PersonaDatos.Eliminar(Idpersona);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(PersonaModelo oPersona)
        {
            //validacion de campos
            
            //recibe un objeto y guarda en la base de datos
            var repuesta = _PersonaDatos.Eliminar (oPersona.Idpersona);
            if (repuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
