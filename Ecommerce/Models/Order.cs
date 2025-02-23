namespace Ecommerce.Models
{
    public class Order
    {
        public int  OrderId{ get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public AppLocationUser User { get; set; }
        public decimal TotalAmount {  get; set; }
        public ICollection<OrderItem> orderItems { get; set; }


    }
}
