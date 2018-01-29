using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string email, string password);
        UserModel GetUser(string email);
        UserModel Create(UserModel model);
        void SetPasswordHash(string passwordHash, int userId);
        UserModel[] GetAdminUser();
    }
}
