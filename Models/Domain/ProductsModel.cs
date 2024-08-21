namespace Inventory_Mngt_API.Models.Domain
{
    public class ProductsModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        //Navigation property
        public ICollection<MakeSaleModel> Sales { get; set; }

    }
}
