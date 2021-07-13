using System.ComponentModel.DataAnnotations;

namespace WebApiBase.DTO
{
    public class SessionDTO
    {
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}