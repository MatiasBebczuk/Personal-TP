using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_TP.Models;
using System.Collections.Generic;
using System.Linq;

namespace Personal_TP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Usuario> usuarios = new List<Usuario>();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Clubes()
        {
            return View();
        }

        public IActionResult Colegios()
        {
            return View();
        }

        public IActionResult Deportes()
        {
            return View();
        }

        // Acción para mostrar el formulario de creación de usuario
        public IActionResult CrearUsuario()
        {
            return View();
        }

        // Acción para manejar el envío del formulario de creación de usuario
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarios.Add(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Acción para mostrar el formulario de inicio de sesión
        public IActionResult IniciarSesion()
        {
            return View();
        }

        // Acción para manejar el envío del formulario de inicio de sesión
        [HttpPost]
        public IActionResult IniciarSesion(string email, string password)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (usuario != null)
            {
                ViewBag.NombreUsuario = usuario.Nombre;
                return RedirectToAction("Bienvenido");
            }
            else
            {
                ViewBag.Error = "Email o contraseña incorrectos.";
                return View();
            }
        }

        // Acción para mostrar la página de bienvenida después de iniciar sesión
        public IActionResult Bienvenido()
        {
            return View();
        }

        // Acción para mostrar la lista de usuarios (opcional)
        public IActionResult ListaUsuarios()
        {
            return View(usuarios);
        }
    }
}
