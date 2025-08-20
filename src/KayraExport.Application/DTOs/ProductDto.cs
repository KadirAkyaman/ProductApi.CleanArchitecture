using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Application.DTOs
{
    /// <summary>
    /// Represents a product returned by the API.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// The unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The number of items available in stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The date and time the product was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}