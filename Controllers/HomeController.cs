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
    string salaActual = HttpContext.Session.GetString("SalaActual");

    if (salaActual == null)
    {
        salaActual = "1";
    }

    if (id.ToString() != salaActual)
    {
        return RedirectToAction("Sala", new { id = salaActual });
    }

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
    string valorLlaves = HttpContext.Session.GetString("LlavesEncontradas");
    int llaves;

    if (valorLlaves == null)
    {
        llaves = 0;
    }
    else
    {
        llaves = int.Parse(valorLlaves);
    }

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
public IActionResult Sala3(int eleccion)
{
    if (eleccion == 3)
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
    string valorGuantes = HttpContext.Session.GetString("GuantesObtenidos");
    int guantes;

    if (valorGuantes == null)
    {
        guantes = 0;
    }
    else
    {
        guantes = int.Parse(valorGuantes);
    }

    guantes++;
    HttpContext.Session.SetString("GuantesObtenidos", guantes.ToString());

    return Json(new { guantes });
}

[HttpPost]
public IActionResult GolpearViruzz()
{
    string valorGuantes = HttpContext.Session.GetString("GuantesObtenidos");
    int guantes;

    if (valorGuantes == null)
    {
        guantes = 0;
    }
    else
    {
        guantes = int.Parse(valorGuantes);
    }

    if (guantes < 2)
    {
        return Json(new { exito = false, mensaje = "Sin los dos guantes no le haces daño." });
    }

    string valorGolpes = HttpContext.Session.GetString("GolpesAlJefe");
    int golpes;

    if (valorGolpes == null)
    {
        golpes = 0;
    }
    else
    {
        golpes = int.Parse(valorGolpes);
    }

    
    golpes = golpes + 1;
    HttpContext.Session.SetString("GolpesAlJefe", golpes.ToString());

  
    if (golpes >= 3)
    {
        HttpContext.Session.SetString("SalaActual", "6");
        SumarCafetera();
        return Json(new { fin = true, ganado = true, golpes = golpes });
    }

    string imagen;
    if (golpes >= 2)
    {
        imagen = "imagenviruzz2";
    }
    else
    {
        imagen = "imagenviruzz1";
    }

    return Json(new { exito = true, imagenViruzz = imagen, golpes = golpes });
}




      public IActionResult Victoria()
{
    return View();
}


       private void SumarCafetera()
{
    string valorCafeteras = HttpContext.Session.GetString("Cafeteras");
    int cafeteras;

    if (valorCafeteras == null)
    {
        cafeteras = 0;
    }
    else
    {
        cafeteras = int.Parse(valorCafeteras);
    }

    cafeteras++;
    HttpContext.Session.SetString("Cafeteras", cafeteras.ToString());
}

    }
}


