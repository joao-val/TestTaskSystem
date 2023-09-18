using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Repositories
{
    public class UserAuthRepository
    {
        public static UserAuth Get(string username, string password)
        {
            var users = new List<UserAuth>
            {
                new() {Id = 1, Username = "batman", Password = "batman", Role = "manager"},
                new() {Id = 2, Username = "robin", Password = "robin", Role = "employee"}
            };
            return users
                .FirstOrDefault(x =>
                x.Username == username && x.Password == password);
        }
    }
}