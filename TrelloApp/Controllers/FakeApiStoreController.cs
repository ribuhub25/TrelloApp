using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using TrelloApp.Data;
using TrelloApp.Repositories;

namespace TrelloApp.Controllers
{
    public class FakeApiStoreController : Controller
    {
        private readonly IFakeApiStoreRepository _repository;
        public FakeApiStoreController(IFakeApiStoreRepository repository)
        {
            _repository = repository;
        }

        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive  = true };
        // GET: FakeApiStore
        public async Task<IActionResult> Index()
        {
            var url = "https://fakestoreapi.com/products/";
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Producto>>(content, options);
                return View(products);
            }
            else
            {
                ViewData["mensaje"] = "NO SE PUDO CARGAR LOS PRODUCTOS";
                return View();
            }         
        }
        public ActionResult ApiconAjax()
        {
            return View();
        }

        // GET: FakeApiStore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FakeApiStore/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: FakeApiStore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FakeApiStore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FakeApiStore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FakeApiStore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FakeApiStore/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
