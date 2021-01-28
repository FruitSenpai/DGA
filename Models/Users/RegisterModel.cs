using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email {get; set;}
        public string CellNumber {get; set;}
        public string TelephoneNumber{get; set;}
    }
}