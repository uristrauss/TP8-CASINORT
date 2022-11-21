using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP8.Models;

namespace TP8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaJugadores = BD.ListarJugadores();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult AgregarJugador()
    {
        ViewBag.ListaPaises = BD.ListarPaises();
        return View("AgregarJugador");
    }

    [HttpPost]
    public IActionResult GuardarJugador(string Username, DateTime FechaNacimiento, string FotoJugador, int Pais)
    {
         BD.AgregarJugador(Username, FechaNacimiento, FotoJugador, Pais);
         Actual.Username = Username;
         Actual.PuntajeActual = 100;
         Actual.FotoJugador = FotoJugador;
         Actual.FechaNacimiento = FechaNacimiento;
         ViewBag.ListaJugadores = BD.ListarJugadores();
         return RedirectToAction("Puntos");
    }

    public IActionResult Puntos()
    {
        if (Actual.PuntajeActual <= 0)
        {
            return View("FinMAL", "Home");
        }
        else
        {
        return View("Juegos", "Home");
        }
    }

    public IActionResult Juego1()
    {
     
        Random numero = new Random();
        Actual.Num1 = numero.Next(1, 13);         
        ViewBag.NumeroRandom1 = Actual.Num1;

        
        Actual.Num2 = numero.Next(1, 13);
        ViewBag.NumeroRandom2 = Actual.Num2;
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        return View("MayorMenorIgual", "Home");
    }

[HttpPost]
    public IActionResult MayorMenorIgual(int Opcion)
    {
        System.Console.WriteLine("siiiiiiiiiii");
        switch(Opcion)
        {
        case 1:
        if(Actual.Num2 > Actual.Num1)
        {
            Actual.PuntajeActual = Actual.PuntajeActual + 10;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("GanasteMMI");
        }
        else
        {
            Actual.PuntajeActual = Actual.PuntajeActual - 10;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("PerdisteMMI");
        }
        break;
        case 2:
        if(Actual.Num2 < Actual.Num1)
        {
            Actual.PuntajeActual = Actual.PuntajeActual + 10;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("GanasteMMI");
        }
        else
        {
            Actual.PuntajeActual = Actual.PuntajeActual - 10;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("PerdisteMMI");
        }
        break;
        case 3:
        if(Actual.Num2 == Actual.Num1)
        {
           Actual.PuntajeActual = Actual.PuntajeActual + 10;
           ViewBag.PuntajeActual = Actual.PuntajeActual;
           return View("GanasteMMI");
        }
        else
        {
            Actual.PuntajeActual = Actual.PuntajeActual - 10;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("PerdisteMMI");
        }
        break;

        }      

        return RedirectToAction("Juego1", "Home");
    }

    public IActionResult Caballos()
    {

        Random numero = new Random();
        Actual.Num3 = numero.Next(1, 7);         
        ViewBag.CaballoGanador = Actual.Num3;
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        return View("Caballos");
    }

[HttpPost]
    public IActionResult Carrera(int Carrera)
    {

        if (Actual.Num3 == Carrera)
        {
            ViewBag.CaballoGanador = Actual.Num3;
            Actual.PuntajeActual = Actual.PuntajeActual + 60;
             ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("GanasteCaballos");
        }
        else
        {
            ViewBag.CaballoGanador = Actual.Num3;
            Actual.PuntajeActual = Actual.PuntajeActual - 10;
             ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("PerdisteCaballos");
        }
    }

public IActionResult Blackjack()
    {
        Random numero = new Random();
        Actual.Num5 = numero.Next(16, 22);  
        ViewBag.Crupier = Actual.Num5;
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        Actual.Puntblack = 0;
        return View("Blackjack");
    }

    public IActionResult PuntosBlack()
    {

        Random numero = new Random();
        Actual.Num4 = numero.Next(2, 11);  
        ViewBag.Carta = Actual.Num4;
        Actual.Puntblack = Actual.Puntblack + Actual.Num4;
        System.Console.WriteLine(Actual.Puntblack);
        ViewBag.Puntblack = Actual.Puntblack;

        /*
        if (Actual.Puntblack < 18)
        {
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            ViewBag.Puntblack = Actual.Puntblack;
            return View("BlackJack");
        }
        else if(Actual.Puntblack > 18 && Actual.Puntblack <= 21)
        {
            ViewBag.Puntblack = Actual.Puntblack;
            Actual.PuntajeActual = Actual.PuntajeActual + 60;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            return View("Ganasteblack");
        }
        */
        if(Actual.Puntblack > 21)
        {
            ViewBag.Puntblack = Actual.Puntblack;
            Actual.PuntajeActual = Actual.PuntajeActual - 30;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            ViewBag.Crupier = Actual.Num5;
            return View("Perdisteblack");
        }

        ViewBag.PuntajeActual = Actual.PuntajeActual;
        return View("BlackJack");

    }

    public IActionResult Verificar(int Puntoslocos)
    {
        if (Puntoslocos < Actual.Num5)
        {
            ViewBag.Puntblack = Actual.Puntblack;
            Actual.PuntajeActual = Actual.PuntajeActual - 30;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            ViewBag.Crupier = Actual.Num5;
            return View("Perdisteblack");
        }
        else
        {
            ViewBag.Puntblack = Actual.Puntblack;
            Actual.PuntajeActual = Actual.PuntajeActual + 60;
            ViewBag.PuntajeActual = Actual.PuntajeActual;
            ViewBag.Crupier = Actual.Num5;
            return View("Ganasteblack");
        }
    }

    public IActionResult Volver()
    {
        return View("Juegos");
    }

    public IActionResult VolverBlack()
    {
   
        Actual.Puntblack = 0;
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        return View("BlackJack");
    }

    public IActionResult VolverMMI()
    {
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        return View("MayorMenorIgual");
    }

    public IActionResult Fin()
    {
     
       BD.Actualizar(Actual.Username, Actual.PuntajeActual);
        ViewBag.ListaJugadores = BD.ListarJugadores();
        ViewBag.PuntajeActual = Actual.PuntajeActual;
        ViewBag.PaisPosta = BD.TraerPais(Actual.Username);
        return View("Fin");
    }





}
