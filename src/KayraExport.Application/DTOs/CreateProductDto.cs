using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}