using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp05.Models;
using TP05_LoginRegistro.Models;

namespace tp05.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private BD bd = new BD();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registro(Usuario usuario)
    {
        Usuario usuarioExistente = bd.BuscarUsuarioPorNombre(usuario.NombreUsuario);

        if (usuarioExistente != null)
        {
            ViewBag.Error = "Ese nombre de usuario ya existe.";
            return View();
        }

        bd.AgregarUsuario(usuario);

        return RedirectToAction("Login");
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string NombreUsuario, string Contrasenia)
    {
        Usuario usuario = bd.ValidarLogin(NombreUsuario, Contrasenia);

        if (usuario == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
        HttpContext.Session.SetString("Nombre", usuario.Nombre);
        HttpContext.Session.SetString("Apellido", usuario.Apellido);
        HttpContext.Session.SetString("TipoUsuario", usuario.TipoUsuario);

        return RedirectToAction("Bienvenida");
    }



    public IActionResult Bienvenida()
    {
        string nombreUsuario = HttpContext.Session.GetString("NombreUsuario");

        if (string.IsNullOrEmpty(nombreUsuario))
        {
            return RedirectToAction("Login");
        }

        ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
        ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
        ViewBag.Apellido = HttpContext.Session.GetString("Apellido");
        ViewBag.TipoUsuario = HttpContext.Session.GetString("TipoUsuario");

        return View();
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}