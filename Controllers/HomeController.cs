using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tp05_escapeRoom.Models;
namespace Tp05_escapeRoom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();



[HttpGet]
public IActionResult Iniciar()
{
    return View();
}

        [HttpPost]
        public IActionResult Iniciar(string nombreJugador)
        {
            HttpContext.Session.SetString("Nombre", nombreJugador);
            HttpContext.Session.SetString("SalaActual", "1");
            HttpContext.Session.SetString("LlavesEncontradas", "0");
            HttpContext.Session.SetString("GuantesObtenidos", "0");
            HttpContext.Session.SetString("GolpesAlJefe", "0");
            HttpContext.Session.SetString("Cafeteras", "0");
            return RedirectToAction("Sala", new { id = 1 });
        }

        public IActionResult Sala(int id)
        {
            string salaActual = HttpContext.Session.GetString("SalaActual") ?? "1";
            if (id.ToString() != salaActual)
                return RedirectToAction("Sala", new { id = salaActual });
            return View("Sala" + id);
        }

        [HttpPost]
        public IActionResult Sala1(string respuesta)
        {
            if (respuesta == "juanceto01")
            {
                HttpContext.Session.SetString("SalaActual", "2");
                SumarCafetera();
                return RedirectToAction("Sala", new { id = 2 });
            }
            ViewBag.Error = "Respuesta incorrecta";
            return View("Sala1");
        }

        [HttpPost]
        public IActionResult EncontrarLlave()
        {
            int llaves = int.Parse(HttpContext.Session.GetString("LlavesEncontradas") ?? "0");
            llaves++;
            HttpContext.Session.SetString("LlavesEncontradas", llaves.ToString());
            if (llaves >= 3)
            {
                HttpContext.Session.SetString("SalaActual", "3");
                SumarCafetera();
                return Json(new { avanzar = true });
            }
            return Json(new { avanzar = false, llaves });
        }

        [HttpPost]
        public IActionResult Sala3(string prenda)
        {
            if (prenda == "imagen4")
            {
                HttpContext.Session.SetString("SalaActual", "4");
                SumarCafetera();
                return RedirectToAction("Sala", new { id = 4 });
            }
            ViewBag.Error = "Esa prenda no sirve para la boda";
            return View("Sala3");
        }

        [HttpPost]
            public IActionResult Sala4(int eleccion)
        {       
         if (eleccion == 4)
            {
        HttpContext.Session.SetString("SalaActual", "5");
        SumarCafetera();
        return View("Gol"); 
         }
             return View("Penal");   
            }


        [HttpPost]
        public IActionResult EncontrarGuante()
        {
            int guantes = int.Parse(HttpContext.Session.GetString("GuantesObtenidos") ?? "0");
            guantes++;
            HttpContext.Session.SetString("GuantesObtenidos", guantes.ToString());
            return Json(new { guantes });
        }

        [HttpPost]
        public IActionResult GolpearViruzz()
        {
            int guantes = int.Parse(HttpContext.Session.GetString("GuantesObtenidos") ?? "0");
            if (guantes < 2)
                return Json(new { exito = false, mensaje = "Sin los dos guantes no le haces daño." });

            int golpes = int.Parse(HttpContext.Session.GetString("GolpesAlJefe") ?? "0");
            golpes++;
            HttpContext.Session.SetString("GolpesAlJefe", golpes.ToString());

            if (golpes >= 3)
            {
                HttpContext.Session.SetString("SalaActual", "6");
                SumarCafetera();
                return Json(new { fin = true, ganado = true });
            }

            string imagen = golpes >= 2 ? "imagenviruzz2" : "imagenviruzz1";
            return Json(new { exito = true, imagenViruzz = imagen });
        }

        public IActionResult Victoria() => View();

        private void SumarCafetera()
        {
            int c = int.Parse(HttpContext.Session.GetString("Cafeteras") ?? "0");
            HttpContext.Session.SetString("Cafeteras", (c + 1).ToString());
        }
    }
}


