using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6_elecciones.Models;

namespace TP6_elecciones.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {  
        ViewBag.ListaPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    {  
        ViewBag.InfoPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {  
        ViewBag.InfoCandidato = BD.VerInfoCandidato(idCandidato);
        return View("DetalleCandidato");
    }
     public IActionResult AgregarCandidato(int idPartido)
    {  
        ViewBag.IdPartidoo = idPartido;
        return View("AgregarCandidato");
    }
    [HttpPost] public IActionResult GuardarCandidato(Candidato can)
    {
        BD.agregarCandidato(can);
        ViewBag.InfoPartido = BD.VerInfoPartido(can.IdPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(can.IdPartido);
        return View("DetallePartido");
    }
   public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.eliminarCandidato(idCandidato);
        ViewBag.InfoPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult Elecciones()
    {
        return View("Elecciones");
    }
     public IActionResult Creditos()
    {
        return View("Creditos");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
