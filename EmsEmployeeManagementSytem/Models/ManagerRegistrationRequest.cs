using System.ComponentModel.DataAnnotations;

namespace EmsEmployeeManagementSytem.Models
{
    public class ManagerRegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
