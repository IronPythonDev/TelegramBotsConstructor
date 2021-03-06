using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IronPython.User.Contracts.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Email is required!"), JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
