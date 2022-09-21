using Microsoft.AspNetCore.Mvc;
using tallerconfiable.Datos;
using tallerconfiable.Models;

namespace tallerconfiable.Controllers
{
    public class MantenedorServicio : Controller
    {
        ServicioDatos _ServicioDatos = new ServicioDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _ServicioDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ServicioModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _ServicioDatos.Guardar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Idservicio)
        {
            //devuelve la vista
            var opersona = _ServicioDatos.Obtener(Idservicio);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult Editar(ServicioModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _ServicioDatos.Editar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idservicio)
        {
            //devuelve la vista
            var opersona = _ServicioDatos.Eliminar(Idservicio);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(ServicioModelo oPersona)
        {
            //recibe un objeto y guarda en la base de datos
            var respuesta = _ServicioDatos.Eliminar(oPersona.Idservicio);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
