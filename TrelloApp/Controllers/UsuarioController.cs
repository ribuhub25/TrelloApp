using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrelloApp.Models;
using TrelloApp.Repositories;
using TrelloApp.ViewModels;

namespace TrelloApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolesUsuariosRepository _rolesUsuariosRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IRolesUsuariosRepository rolesUsuariosRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolesUsuariosRepository = rolesUsuariosRepository; 
        }
        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = _usuarioRepository.GetUsuarios2().ToList();
            List<RolesUsuarios> rolesbyuser = await _rolesUsuariosRepository.GetRolesUsuarios();
            var viewModel = new TablaUsuarioVM
            {
                Usuarios = usuarios,
                RolesByUser = rolesbyuser,
            };

            return View(viewModel);
        }
        public async Task<IActionResult> _DetalleUsuarioPartialView(int id) 
        { 
            Usuario usuario = await _usuarioRepository.GetUsuario(id);
            return PartialView("_ModalDetalleUsuario", usuario);
        }
    }
}
