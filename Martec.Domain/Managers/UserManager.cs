using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Interfaces.Utility;
using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Managers
{
    public class UserManager
    {
       // private IEmailNotification _email;
        private IEncryption _encrypt;
        private IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo, IEncryption encrypt /*IEmailNotification email*/)
        {
            _userRepo = userRepo;
            _encrypt = encrypt;
            //_email = email;
        }
        public UserModel Login(string email,string password)
        {
            //check to see if user exists
            var passwordHash = _encrypt.Encrypt(password);
            var user = _userRepo.ValidateUser(email, passwordHash);
            return user;
        }

        public UserModel RegisterUser(UserModel model, string password)
        {
           
            //chect if User Exists
            var user = _userRepo.GetUser(model.Email);


            if (user != null) throw new Exception("The Email already exist");

            //Create user
            user = _userRepo.Create(model);

            //Encrypt Password
            var passwordHash = _encrypt.Encrypt(password);

            //Store Encrypted Password
            _userRepo.SetPasswordHash(passwordHash, user.UserId);
            return model;
        }
        //public void SendEmailToAdmin()
        //{
        //    // Get All The Admin
        //    var admins = _userRepo.GetAdminUser();

        //    //Send Email notification to all the Admins
        //    _email.SendEmail(admins);
        //}
    }
}
