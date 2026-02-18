using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult Index()
        {
            byte[] data = HttpContext.Session.Get("MASCOTA");

            if (data != null)
            {
                Mascota mascota = (Mascota) HelperBinarySession.ByteToObject(data);

                return View(mascota); 
            }

            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            if(accion != null)
            {
                if(accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados en Session";
                }
                
                else if (accion.ToLower() == "mostrar")
                {
                    ViewData["NOMBRE"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }

        public IActionResult SessionMascotaBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota();

                    mascota.Nombre = "Wall-E";
                    mascota.Raza = "Cleaner";
                    mascota.Edad = 18;

                    byte[] data = HelperBinarySession.ObjectToByte(mascota);

                    HttpContext.Session.Set("MASCOTA", data);
                    
                    ViewData["MENSAJE"] = "Mascota almacenada en Session";
                }

                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    
                    Mascota mascota = (Mascota) HelperBinarySession.ByteToObject(data);

                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaCollectionBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota> 
                    {
                        new Mascota{Nombre = "Nala", Raza = "Leona", Edad = 21},
                        new Mascota{Nombre = "Sebastian", Raza = "Cangrejo", Edad = 24 },
                        new Mascota{Nombre = "Rafiki", Raza = "Brujo", Edad = 23},
                        new Mascota{Nombre = "Olaf", Raza = "Muñeco", Edad = 14},
                    };

                    byte[] data = HelperBinarySession.ObjectToByte(mascotas);

                    HttpContext.Session.Set("MASCOTAS", data);

                    ViewData["MENSAJE"] = "Colección almacenada correctamente";
                }

                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTAS");

                    List<Mascota> mascotas = (List<Mascota>) HelperBinarySession.ByteToObject(data);
                    
                    return View(mascotas);
                }
            }
            return View();
        }
    }
}
