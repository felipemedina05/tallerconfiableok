using Microsoft.AspNetCore.Mvc;
using tallerconfiable.Models;
using tallerconfiable.Datos;

namespace tallerconfiable.Controllers
{
    public class MantenedorMecanico : Controller
    {
        MecanicoDatos _MecanicoDatos = new MecanicoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _MecanicoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(MecanicoModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _MecanicoDatos.Guardar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Idpersona)
        {
            //devuelve la vista
            var opersona = _MecanicoDatos.Obtener(Idpersona);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult Editar(MecanicoModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var resouesta = _MecanicoDatos.Editar(oPersona);
            if (resouesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idpersona)
        {
            //devuelve la vista
            var opersona = _MecanicoDatos.Obtener(Idpersona);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(MecanicoModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var repuesta = _MecanicoDatos.Eliminar(oPersona.Idpersona);
            if (repuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }

}

