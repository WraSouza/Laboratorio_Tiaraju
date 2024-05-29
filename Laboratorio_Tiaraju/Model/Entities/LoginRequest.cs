namespace Laboratorio_Tiaraju.Model.Entities
{
    public class LoginRequest
    {
        public LoginRequest(string? userName, string? password)
        {
            UserName = userName;
            Password = password;
        }

        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
