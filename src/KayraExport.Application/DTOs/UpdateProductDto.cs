using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Application.DTOs
{
    /// <summary>
    /// Represents the data required to update an existing product.
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// The new name for the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The new stock quantity for the product.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The new price for the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}