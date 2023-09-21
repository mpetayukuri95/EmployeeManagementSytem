using System.ComponentModel.DataAnnotations;

namespace EmsEmployeeManagementSytem.Models
{
    public class Employee
    {
        [Key]
        private int id;

        private string name = "";

        [MaxLength(16)]
        private int nationalId;

        private string code = "";

        private string phoneNumber="";

        private string email = "";

        private string dateOfBirth = "";

        private string status = "";

        private string position = "";

        private DateTime createDate;

        public string Name { get => name; set => name = value; }
        public int NationalId { get => nationalId; set => nationalId = value; }
        public string Code { get => code; set => code = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Status { get => status; set => status = value; }
        public string Position { get => position; set => position = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public int Id { get => id; set => id = value; }

        internal bool Exists(int id)
        {
            throw new NotImplementedException();
        }
    }
}