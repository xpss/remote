namespace DiplomApp.Models
{
    public class CredentialsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
