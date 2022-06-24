namespace Core.DTOs
{
    public class UserUpdateDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}