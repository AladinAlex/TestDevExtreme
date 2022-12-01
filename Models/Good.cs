using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDevExtreme.Models
{
    public class Good
    {
        public int GoodID { get; set; }
        public string? GoodName { get; set; }
        public int? GoodCount { get; set; }
        public int? warehouseID { get; set; }
        public Warehouse? warehouse { get; set; }

    }
}
