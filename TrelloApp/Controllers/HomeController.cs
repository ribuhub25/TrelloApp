using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrelloApp.Models;
using TrelloApp.Repositories;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using TrelloApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TrelloApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITableroRepository _tableroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolesRepository _rolesRepository;
        public HomeController(ITableroRepository tableroRepository, IUsuarioRepository usuarioRepository, IRolesRepository rolesRepository)
        {
            _tableroRepository = tableroRepository;
            _usuarioRepository = usuarioRepository;
            _rolesRepository = rolesRepository;
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

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

        public async Task<IActionResult> Tableros()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PanelControl(int codigouser, int codigorol)
        {
            ViewBag.usuarios = new SelectList(await _usuarioRepository.GetUsuarios(), "Id", "Name", codigouser);
            ViewBag.roles = new SelectList(_rolesRepository.GetRoles(), "Id", "Description", codigorol);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PanelControl(AddAdminVM modelo, int codigouser, int codigorol)
        {
            var usuario_admin = await _usuarioRepository.AddRole(codigorol, codigouser);
            if (usuario_admin == null)
            {
                ViewData["mensaje"] = "No se pudo agregar el rol usuario";
                ViewBag.usuarios = new SelectList(await _usuarioRepository.GetUsuarios(), "Id", "Name", codigouser);
                ViewBag.roles = new SelectList(_rolesRepository.GetRoles(), "Id", "Description", codigorol);
                return View();
            }
            else
            {
                ViewData["exito"] = "se agregó el rol " + await _rolesRepository.GetRolById(codigorol) + " con éxito al usuario " + await _usuarioRepository.GetUsuarioById(codigouser);
                ViewBag.usuarios = new SelectList(await _usuarioRepository.GetUsuarios(), "Id", "Name", codigouser);
                ViewBag.roles = new SelectList(_rolesRepository.GetRoles(), "Id", "Description", codigorol);
                return View();
            }
        }
    }
}
