using Microsoft.AspNetCore.Mvc;
using TrelloApp.Repositories;
using TrelloApp.Models;
namespace TrelloApp.ViewComponents
{

    public class TarjetaCardViewComponent:ViewComponent
    {
        private readonly ITarjetaRepository _repo;
        public TarjetaCardViewComponent(ITarjetaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //var tarjetas = await _repo.GetTarjetas().Where(t => t.EstadoId.Equals(id));
            var query = from trj in await _repo.GetTarjetas()
                        where trj.EstadoId == id
                        select trj;
            var tarjetas = query.ToList();
            ViewBag.Estadoid = id;
            return View(tarjetas);
        }

    }
}
