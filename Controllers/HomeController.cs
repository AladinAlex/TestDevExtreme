using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestDevExtreme.Models;
using Newtonsoft.Json;

namespace TestDevExtreme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _context;

        public HomeController(ILogger<HomeController> logger, dbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<object> GetWarehouses(DataSourceLoadOptions loadOptions)
        {
            var warehouse = await _context.Warehouses.ToListAsync();
            return DataSourceLoader.Load(warehouse, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> InsertWarehouse(string values)
        {
            Warehouse whNew = new();
            //whNew = JsonConvert.DeserializeObject<Warehouse>(values);
            JsonConvert.PopulateObject(values, whNew);
            if (!TryValidateModel(whNew))
                return BadRequest(new Exception("Неверно введены данные для нового склада"));

            await _context.Warehouses.AddAsync(whNew);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse(int key, string values)
        {
            var wh = await _context.Warehouses.FirstAsync(w => w.WarehouseID == key);
            JsonConvert.PopulateObject(values, wh);

            if (!TryValidateModel(wh))
                return BadRequest(new Exception("Неверно введены данные для склада"));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public void DeleteWarehouse(int key)
        {
            var wh = _context.Warehouses.First(i => i.WarehouseID == key);
            _context.Warehouses.Remove(wh);
            _context.SaveChanges();
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
    }
}