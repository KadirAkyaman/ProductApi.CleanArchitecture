using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}