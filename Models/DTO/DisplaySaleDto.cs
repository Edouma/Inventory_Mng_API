namespace Inventory_Mngt_API.Models.DTO
{
    public class DisplaySaleDto
    {
            //public Guid Id { get; set; }
            public Guid ProductId { get; set; }  // Foreign Key
            public int Quantity { get; set; }
            public int UnitPrice { get; set; }
            public DateTime Date { get; set; }
            public int TotalCost { get; set; }
            public string ProductName { get; set; }
        }
    
}
