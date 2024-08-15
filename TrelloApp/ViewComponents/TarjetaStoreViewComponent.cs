using Microsoft.AspNetCore.Mvc;
using TrelloApp.Data;
using TrelloApp.Repositories;

namespace TrelloApp.ViewComponents
{
    public class TarjetaStoreViewComponent:ViewComponent
    {
        private readonly IFakeApiStoreRepository _repository;
        public TarjetaStoreViewComponent(IFakeApiStoreRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //Para invokar todos los productos
            //List<Producto> productos = await _repository.GetAllData(); 
            //return View(productos);

            //Para invokar solo un producto
            Producto producto = await _repository.GetOneProducto(id);
            return View(producto);
        }
    }
}
