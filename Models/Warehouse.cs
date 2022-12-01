using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDevExtreme.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string? WarehouseName { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? Building { get; set; }
        public int? PostCode { get; set; }

        //public List<Good> Goods { get; set; }
        public List<Good> Goods { get; set; } = new(); //товары склада
    }
}
