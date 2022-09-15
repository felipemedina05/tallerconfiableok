using Microsoft.AspNetCore.Mvc;
using tallerconfiable.Datos;
using tallerconfiable.Models;

namespace tallerconfiable.Controllers
{
    public class MantenedorVehiculo : Controller
    {
  
            VehiculoDatos _VehiculoDatos = new VehiculoDatos();
            public IActionResult Listar()
            {
                //listar contactos
                var oLista = _VehiculoDatos.Listar();
                return View(oLista);
            }

            public IActionResult Guardar()
            {
                //devuelve la vista

                return View();
            }

            [HttpPost]
            public IActionResult Guardar(VehiculoModelo oVehiculo)
            {
                //validacion de campos
                if (!ModelState.IsValid)
                    return View();
                //recibe un objeto y guarda en la base de datos
                var respuesta = _VehiculoDatos.Guardar(oVehiculo);
                if (respuesta)
                    return RedirectToAction("Listar");
                else
                    return View();
            }

            public IActionResult Editar(int Idvehiculo)
            {
                //devuelve la vista
                var ovehiculo = _VehiculoDatos.Obtener(Idvehiculo);
                return View(ovehiculo);
            }

            [HttpPost]
            public IActionResult Editar(VehiculoModelo oVehiculo)
            {
                //validacion de campos
                if (!ModelState.IsValid)
                    return View();
                //recibe un objeto y guarda en la base de datos
                var repouesta = _VehiculoDatos.Editar(oVehiculo);
                if (repouesta)
                    return RedirectToAction("Listar");
                else
                    return View();
            }

            public IActionResult Eliminar(int Idvehiculo)
            {
                //devuelve la vista
                var opersona = _VehiculoDatos.Eliminar(Idvehiculo);
                return View();
            }

            [HttpPost]
            public IActionResult Eliminar(VehiculoModelo oVehiculo)
            {
                //validacion de campos

                //recibe un objeto y guarda en la base de datos
                var repuesta = _VehiculoDatos.Eliminar(oVehiculo.Idvehiculo);
                if (repuesta)
                    return RedirectToAction("Listar");
                else
                    return View();
            }

        }

    }




