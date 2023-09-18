namespace SistemaDeTarefas_api_basica_.Models
{
    public class UserAuth
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}