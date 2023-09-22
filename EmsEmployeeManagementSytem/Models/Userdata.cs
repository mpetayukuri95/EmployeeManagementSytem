using System.ComponentModel.DataAnnotations;

namespace EmsEmployeeManagementSytem.Models
{
    public class Userdata
    {
        private string name = "";

        [MaxLength(16)]
        private int nationalId;

        private string phoneNumber = "";

        private string email = "";

        private string dateOfBirth = "";

        private string status = "";

        private string position = "";

        private string username = "";

        private string password = "";

        public string Name { get => name; set => name = value; }
        public int NationalId { get => nationalId; set => nationalId = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Status { get => status; set => status = value; }
        public string Position { get => position; set => position = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
    }
}
