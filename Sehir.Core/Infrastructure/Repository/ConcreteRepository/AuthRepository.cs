using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sehir.Common.Dto;
using Sehir.Core.Infrastructure.Uow;
using Sehir.Domain.Domains;

namespace Sehir.Core.Infrastructure.Repository.ConcreteRepository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<User> Login(string Username, string password)
        {

            throw new NotImplementedException();
        }

        public async Task<User> Register(RegisterDto user)
        {
            var newuser = new User
            {
                Username = user.Username,

            };


            byte[] passwordHash = default(byte[]);
            byte[] passwordSalt = default(byte[]);

            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            newuser.PasswordHash = passwordHash;
            newuser.Passwordsalt = passwordSalt;

            await UnitOfWork.SehirContext.User.AddAsync(newuser);
             UnitOfWork.SehirContext.SaveChanges();

            return newuser;
        }

        public Task<bool> UserExist(string userName)
        {
            throw new NotImplementedException();
        }


        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.Key;
                passwordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
