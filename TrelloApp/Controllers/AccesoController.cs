using Microsoft.AspNetCore.Mvc;
using TrelloApp.Models;
using TrelloApp.Repositories;
using TrelloApp.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TrelloApp.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AccesoController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            if(modelo.Password != modelo.ConfirmarPassword)
            {
                ViewData["Mensaje"] = "Las Contraseñas no coinciden";
                return View();
            }
            Usuario usuario = new Usuario()
            {
                Name = modelo.Name,
                Email = modelo.Email,
                Password = modelo.Password,
            };
            if(await _usuarioRepository.GetByEmail(modelo.Email))
            {
                ViewData["Mensaje"] = "No se pudo crear el usuario, porque el correo ya existe!";
                return View();
            }
            await _usuarioRepository.Insert(usuario);
            if(usuario.Id != 0) return RedirectToAction("Login", "Acceso");
            ViewData["Mensaje"] = "No se pudo crear el usuario, Error!";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _usuarioRepository.GetByCredencials(modelo.Email, modelo.Password);
            if (usuario_encontrado == null) {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
