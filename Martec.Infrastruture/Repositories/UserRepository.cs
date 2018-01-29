using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public UserModel Create(UserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedDate = DateTime.Now

            };
            _context.Set<User>().Add(user);
            _context.SaveChanges();

            model.UserId = user.UserId;
            return model;
        }

        public UserModel[] GetAdminUser()
        {
            var query = from user in _context.Set<User>()
                        from userRole in user.UserRoles
                        where userRole.RoleId == 2
                        select new
                        {
                            user

                        };
            var record = query.ToArray();

            var transform = from records in record
                            select new UserModel
                            {
                                Email = records.user.Email
                            };
            return transform.ToArray();

        }

        public UserModel GetUser(string email)
        {
            var query = from user in _context.Set<User>()
                        where user.Email == email
                        select new
                        {
                            user,
                            role = from userRole in user.UserRoles
                                   select userRole.Role.Name
                        };
            var records = query.ToArray();

            var transform = from record in records
                            select new UserModel
                            {
                                Email = record.user.Email,
                                FirstName = record.user.FirstName,
                                LastName = record.user.LastName,
                                Roles = record.role.ToArray()

                            };

            return transform.FirstOrDefault();

        }

        public void SetPasswordHash(string passwordHash, int userId)
        {
            var user = _context.Set<User>().Find(userId);
            if (user == null) throw new Exception("User not found");
            user.PasswordHash = passwordHash;
            _context.SaveChanges();
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            var query = from user in _context.Set<User>()
                        where user.Email == email
                        where user.PasswordHash == passwordHash
                        let roles = from userRole in user.UserRoles
                                    select userRole.Role.Name
                        select new
                        {
                            user,
                            roles
                        };
            var record = query.FirstOrDefault();
            if (record != null)
            {
                return new UserModel
                {
                    UserId = record.user.UserId,
                    Email = record.user.Email,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    CreatedDate = record.user.CreatedDate,
                    Roles = record.roles.ToArray()
                };
            }
            return null;

        }
    }
}
