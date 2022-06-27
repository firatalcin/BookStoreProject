namespace Core.DTOs
{
    public class OrderListDto : BaseDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}