namespace Inventory_Mngt_API.Models.DTO
{
    public class ReplenishStockDto
    {
            public Guid ProductId { get; set; }
            public int QuantityToAdd { get; set; }

    }
}
