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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tarjetas = _repo.GetTarjetas();
            return View(tarjetas);
        }

    }
}
