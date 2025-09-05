using System.Collections.Generic;
using System.Threading.Tasks;

using DotnetBackend.Models;

namespace DotnetBackend.Services
{
    public class TestService
    {
        public string GetGreeting(string name)
        {
            return $"Hello {name}";
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Task.Delay(1000); // DB simulation

            List<User> users = new List<User>()
            {
                new User { Id = 1, UserName = "asdafamas", DisplayName = "John Simmons", Password = "password123" },
                new User { Id = 2, UserName = "famas", DisplayName = "John", Email = "Something@g.s", Password = "123123123" },
                new User { Id = 3, UserName = "asda", DisplayName = "Simmons", Email = "GotMail@simmy.c", Password = "Password" },
            };

            return users;
        }
    }
}