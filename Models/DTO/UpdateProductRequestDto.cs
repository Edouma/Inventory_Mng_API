namespace Inventory_Mngt_API.Models.DTO
{
    public class UpdateProductRequestDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
