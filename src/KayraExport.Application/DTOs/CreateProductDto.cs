using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Application.DTOs
{
    /// <summary>
    /// Represents the data required to create a new product.
    /// </summary>
    public class CreateProductDto
    {
        /// <summary>
        /// The name of the new product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The initial stock quantity for the new product.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The price of the new product.
        /// </summary>
        public decimal Price { get; set; }
    }
}