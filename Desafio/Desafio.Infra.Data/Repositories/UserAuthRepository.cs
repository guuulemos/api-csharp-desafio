using Desafio.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Infra.Data.Repositories
{
    public class UserAuthRepository
    {
        public static UserAuth Get(string username, string password)
        {
            var users = new List<UserAuth>();

            users.Add(new UserAuth { Id = 1, Username = "admin", Password = "123", Role = "admin" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() & x.Password == x.Password).FirstOrDefault();
        }
    }
}
