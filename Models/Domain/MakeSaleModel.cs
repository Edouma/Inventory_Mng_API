namespace Inventory_Mngt_API.Models.Domain
{
    public class MakeSaleModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }  // Foreign Key
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public DateTime Date { get; set; }
        public int TotalCost { get; set; }

        //Navigation property
        public ProductsModel Product { get; set; }
    }

}
