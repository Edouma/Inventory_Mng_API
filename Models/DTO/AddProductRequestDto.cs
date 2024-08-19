using System.ComponentModel.DataAnnotations;

namespace Inventory_Mngt_API.Models.DTO
{
    public class AddProductRequestDto
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int Price { get; set; }
    }
}
