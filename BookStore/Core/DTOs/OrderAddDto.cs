namespace Core.DTOs
{
    public class OrderAddDto : BaseDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}