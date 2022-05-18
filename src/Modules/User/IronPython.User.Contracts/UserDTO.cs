using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IronPython.User.Contracts
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? RefreshToken { get; set; }

        [Required(ErrorMessage = "Email is required!"), JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
