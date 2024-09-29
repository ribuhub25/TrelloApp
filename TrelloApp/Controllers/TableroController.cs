using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using TrelloApp.Models;
using TrelloApp.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TrelloApp.Controllers
{
    public class TableroController : Controller
    {

        private readonly ITableroRepository _tableroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITarjetaRepository _tarjetaRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly TrelloContext _context;

        public TableroController(ITableroRepository tableroRepository, IUsuarioRepository usuarioRepository, ITarjetaRepository tarjetaRepository, IEstadoRepository estadoRepository, TrelloContext context )
        {
            _context = context;
            _tableroRepository = tableroRepository;
            _usuarioRepository = usuarioRepository;
            _tarjetaRepository = tarjetaRepository;
            _estadoRepository = estadoRepository;
        }
        // GET: TableroController
        //[Route ("/Tablero/Index/{tableroid}")]
        public async Task<IActionResult> Index(int tableroid)
        {
            TempData["TableroId"] = tableroid;
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Estado> estadosForTablero = await _tableroRepository.GetEstadosByTableroId(tableroid);
            ViewBag.ListaEstados = new SelectList(estadosForTablero, "Id", "Name");
            var Estados = estadosForTablero.ToList();
            ViewBag.EstadosJson = JsonSerializer.Serialize(Json(new { data = Estados }));
            return View(estadosForTablero);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewCard(string description, int estado, string title)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tableroId = (int)TempData["TableroId"];

            Tarjeta tarjeta = new Tarjeta()
            {
                UsuarioId = userId,
                EstadoId = estado,
                Title = title,
                Description = description,
                date_created = DateTime.Now,
            };
            var response = await _tarjetaRepository.Insert(tarjeta);
            if(response)
            {
                //TempData.AddToastMessage("La tarjeta se creó correctamente.", new ToastrOptions
                //{
                //    Title = "Éxito",
                //    PositionClass = "toast-top-right",
                //    TimeOut = "2000"
                //});
                TempData["messageInsert"] = "Se creó con éxito la tarjeta!";
            }
            else
            {
                TempData["messageInsert"] = "No se pudo crear la tarjeta!";
            }
            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");

        }
        public async Task<IActionResult> UpdateCard(int id, string description, string title, int estado)
        {
            var tableroId = (int)TempData["TableroId"];
            var tarjetaUpdated = new Tarjeta()
            {
                Description = description,
                Title = title,
                Id = id,
                EstadoId = estado
            };
            var response = await _tarjetaRepository.Update(tarjetaUpdated);
            if (response)
            {
                TempData["messageUpdate"] = "Se modificó con éxito la tarjeta!";
            }
            else
            {
                TempData["messageUpdate"] = "No se pudo modificar la tarjeta!";
            }
            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");

        }
        public async Task<IActionResult> DeleteCard(int id)
        {
            var tableroId = (int)TempData["TableroId"];
            var tarjetaRemovida = await _tarjetaRepository.DeleteTarjeta(id);
            if (tarjetaRemovida)
            {
                TempData["messageDelete"] = "Se eliminó con éxito la tarjeta!";
            }
            else
            {
                TempData["messageDelete"] = "no se pudo eliminar la tarjeta!";
            }

            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");
        }
        public async Task<IActionResult> AddEstado(string Name)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tableroId = (int)TempData["TableroId"];
            Estado estado = new Estado()
            {
                UsuarioId = userId,
                TableroId = tableroId,
                Name = Name
            };
            var response = await _estadoRepository.AddEstado(estado);
            if (response)
            {
                TempData["messageInsertEstado"] = "Se creó el Estado con éxito!";
            }
            else
            {
                TempData["messageInsertEstado"] = "No se pudo crear el Estado!";
            }
            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");

        }
        public async Task<IActionResult> UpdateEstado(string Name, string estadoId)
        {
            var tableroId = (int)TempData["TableroId"];

            Estado estado = new Estado()
            {
                Id = int.Parse(estadoId),
                TableroId = tableroId,
                Name = Name
            };
            var response = await _estadoRepository.UpdateEstado(estado);
            if (response)
            {
                TempData["messageInsertEstado"] = "Se modificó el Estado con éxito!";
            }
            else
            {
                TempData["messageInsertEstado"] = "No se pudo modificar el Estado!";
            }
            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");

        }

        public async Task<JsonResult> UpdateStatusCard(string cardId, string estadoFirstId, string estadoEndId)
        {
            var query = (from tarjet in _context.Tarjetas
                        where tarjet.Id == int.Parse(cardId) && tarjet.EstadoId == int.Parse(estadoEndId)
                        select tarjet).FirstOrDefault();
            if(query != null)
            {
                TempData["messageInsertEstado"] = "No se pudo modificar el Estado!";
                return Json(new { Results = "Error" });
            }

            Tarjeta tarjeta = new Tarjeta()
            {
                Id = int.Parse(cardId),
                EstadoId = int.Parse(estadoEndId),
            };
            var response = await _tarjetaRepository.PutEstado(tarjeta);
            if (response)
            {
                TempData["messageInsertEstado"] = "Se modificó el Estado con éxito!";
                return Json(new { data = response, Results = "Success" });
            }
            else
            {
                TempData["messageInsertEstado"] = "No se pudo modificar el Estado!";
                return Json(new { data = response, Results = "Error" });
            }
            
        }
        public JsonResult GetTarjetasByComboEstados(int estadoId)
        {
            //var tableroId = (int)TempData["TableroId"];
            var query = (from tarjeta in _context.Tarjetas
                        where tarjeta.EstadoId == estadoId
                         select new { tarjeta.Id, tarjeta.Title  }).ToList();
            ViewBag.ListaCardsByEstado = new SelectList(query, "Id", "Title");
            return Json(new
            {
                data = query,
            });
        }
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var tableroId = (int)TempData["TableroId"];
            var response = await _estadoRepository.DeleteEstado(id);
            if (response)
            {
                TempData["messageDelete"] = "Se eliminó con éxito el Estado!";
            }
            else
            {
                TempData["messageDelete"] = "No se pudo eliminar el Estado!";
            }
            return Redirect($"https://localhost:44304/Tablero/Index?tableroid={tableroId}");
        }

    }
}
