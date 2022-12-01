using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestDevExtreme.Models;

namespace TestDevExtreme.Controllers
{
    public class GoodController : Controller
    {
        private readonly dbContext _context;
        public GoodController(dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<object> GetGoodsByWarehouseID(int WarehouseID, DataSourceLoadOptions loadOptions)
        {
            List<Good>? wh = await _context.Goods.Where(r => r.warehouseID == WarehouseID).ToListAsync();
            return DataSourceLoader.Load(wh, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> InsertGood(string values)
        {
            Good gdNew = new();
            JsonConvert.PopulateObject(values, gdNew);

            if (!TryValidateModel(gdNew))
                return BadRequest(new Exception("Неверно введены данные для новой вещи"));

            await _context.Goods.AddAsync(gdNew);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateGood(int key, string values)
        {
            var gd = await _context.Goods.FirstAsync(r => r.GoodID == key);
            JsonConvert.PopulateObject(values, gd);
            if (!TryValidateModel(gd))
                return BadRequest(new Exception("Неверно введены данные для вещи"));

            await _context.SaveChangesAsync();
            return Ok();
        }

        public void DeleteGood(int key)
        {
            var gd = _context.Goods.First(k => k.GoodID == key);
            _context.Goods.Remove(gd);
            _context.SaveChanges();
        }
    }
}
