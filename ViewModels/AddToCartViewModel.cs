namespace AngularDB.ViewModels
{
    public class AddToCartViewModel
    {
        public int AddToCartID { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public int ProductID { get; set; }
        public string Product { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
