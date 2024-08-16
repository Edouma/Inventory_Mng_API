using System.ComponentModel.DataAnnotations;

namespace Inventory_Mngt_API.Models.DTO
{
    public class ProductsDto
    {
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
