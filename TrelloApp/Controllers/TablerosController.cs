using Microsoft.AspNetCore.Mvc;
using TrelloApp.Repositories;
using TrelloApp.Models;
using System.Security.Claims;

namespace TrelloApp.Controllers
{
    public class TablerosController : Controller
    {
        private readonly ITableroRepository _tableroRepository;
        public TablerosController(ITableroRepository tableroRepository)
        {
            _tableroRepository = tableroRepository;
        }
        public async Task<IActionResult> Index()
        {
            var tableros = await _tableroRepository.GetAll();
            return View(tableros);
        }
        [HttpPost]
        public async Task<IActionResult> AddTablero(string Name, string Title)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Tablero tablero = new Tablero()
            {
                Title = Title,
                Name = Name,
                Status = true,
                date_created = DateTime.Now,
                UsuarioId = userId,
            };
            var response = await _tableroRepository.Insert(tablero);
            if (response)
            {
                return RedirectToAction("Index", "Tableros");
            }
            else
            {
                return RedirectToAction("Index", "Tableros");
            }
            
        }
        //[HttpPost]
        //public async Task<IActionResul> AddTablero()
        //{

        //}
    }
}
