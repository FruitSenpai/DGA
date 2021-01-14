namespace WebApi.Models.Users
{
  public class UpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email {get; set;}
        public string CellNumber {get; set;}
        public string TelephoneNumber{get; set;}
    }
}