namespace IronPython.User.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string? RefreshToken { get; set; }
    }
}
