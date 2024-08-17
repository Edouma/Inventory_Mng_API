using System.ComponentModel.DataAnnotations;

namespace Inventory_Mngt_API.Models.DTO
{
    public class AddProductsDto
    {
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
