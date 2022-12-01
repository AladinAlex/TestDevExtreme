using TestDevExtreme.Models;
using Microsoft.EntityFrameworkCore;

namespace TestDevExtreme.Models
{
    public class dbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Good> Goods { get; set; } = null!;

        public dbContext(DbContextOptions<dbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var warehouses = new List<Warehouse>()
            {
                new Warehouse
                    {
                        WarehouseID = 1,
                        WarehouseName = "sklad1",
                        Country = "Russia",
                        Region = "Krasnodarskii krai",
                        City = "Krasnodar",
                        Street = "Severnaya",
                        Building = 11,
                        PostCode = 350888
                    },
                new Warehouse
                {
                    WarehouseID = 2,
                    WarehouseName = "sklad2",
                    Country = "Russia",
                    Region = "Krasnodarskii krai",
                    City = "Anapa",
                    Street = "tikhaya",
                    Building = 82,
                    PostCode = 353537
                },
                new Warehouse
                {
                    WarehouseID = 3,
                    WarehouseName = "sklad3",
                    Country = "Russia",
                    Region = "Moskovskaya oblast",
                    City = "Moskva",
                    Street = "red square",
                    Building = 1,
                    PostCode = 100100
                },
                new Warehouse
                {
                    WarehouseID = 4,
                    WarehouseName = "sklad4",
                    Country = "Russia",
                    Region = "Rostovskaya obl",
                    City = "Rostov-on-don",
                    Street = "donskaya",
                    Building = 294,
                    PostCode = 654768
                },
                new Warehouse
                {
                    WarehouseID = 5,
                    WarehouseName = "sklad5",
                    Country = "Russia",
                    Region = "Kemerovskaya obl",
                    City = "Kemerovo",
                    Street = "krasnaya",
                    Building = 99,
                    PostCode = 893607
                },
                new Warehouse
                {
                    WarehouseID = 6,
                    WarehouseName = "sklad6",
                    Country = "Russia",
                    Region = "Kamchatskii krai",
                    City = "kamchatka",
                    Street = "ak. koroleva",
                    Building = 47,
                    PostCode = 344300
                },
                new Warehouse
                {
                    WarehouseID = 7,
                    WarehouseName = "sklad7",
                    Country = "Russia",
                    Region = "stavkopolskii krai",
                    City = "stavropol",
                    Street = "stavropolskaya",
                    Building = 224,
                    PostCode = 789053
                }
            };
            modelBuilder.Entity<Warehouse>().HasKey(k => k.WarehouseID);
            modelBuilder.Entity<Warehouse>().Property(p => p.WarehouseID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Warehouse>().HasData(warehouses);

            var goods = new List<Good>()
            {
                new Good
                {
                        GoodID = 1,
                        GoodName = "Табуретка",
                        GoodCount = 778,
                        //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 1)
                        warehouseID = 1

                },
                new Good
                {
                    GoodID = 2,
                    GoodName = "Стол",
                    GoodCount = 123,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 2)
                    warehouseID = 2
                },
                new Good
                {
                    GoodID = 3,
                    GoodName = "Столешница",
                    GoodCount = 857,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 3)
                    warehouseID = 3
                },
                new Good
                {
                    GoodID = 4,
                    GoodName = "Шкаф",
                    GoodCount = 46,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 4)
                    warehouseID = 4
                },
                new Good
                {
                    GoodID = 5,
                    GoodName = "Стул",
                    GoodCount = 244,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 5)
                    warehouseID = 5
                },
                new Good
                {
                    GoodID = 6,
                    GoodName = "Кровать",
                    GoodCount = 978,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 6)
                    warehouseID = 6
                },
                new Good
                {
                    GoodID = 7,
                    GoodName = "Батарея",
                    GoodCount = 669,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 7)
                    warehouseID = 7
                },
                new Good
                {
                    GoodID = 8,
                    GoodName = "Принтер",
                    GoodCount = 199,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 1)
                    warehouseID = 1
                },
                new Good
                {
                    GoodID = 9,
                    GoodName = "Ноутбук",
                    GoodCount = 352,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 4)
                    warehouseID = 4
                },
                new Good
                {
                    GoodID = 10,
                    GoodName = "Мышка",
                    GoodCount = 41,
                    //warehouse = warehouses.FirstOrDefault(id => id.WarehouseID == 6)
                    warehouseID = 6
                }
            };
            modelBuilder.Entity<Good>().HasKey(k => k.GoodID);
            modelBuilder.Entity<Good>().HasData(goods);
        }

    }
}