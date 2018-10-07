using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sehir.Common.Dto;
using Sehir.Core.Infrastructure.Uow;
using Sehir.Domain.Domains;

namespace Sehir.Core.Infrastructure.Repository.ConcreteRepository
{
    public class AuthRepository : IAuthRepository
    {
        public async Task<User> Login(string Username, string password)
        {

            var user = await UnitOfWork.SehirContext.User.FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password,user.PasswordHash,user.Passwordsalt))
            {
                return null;
            }
            return user;
        }



        public bool VerifyPasswordHash(string password,byte[] passwordhash,byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {
                var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordhash[i])
                    {
                        return false;
                    }
                   
                }
                return true;
            }
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

        public async Task<bool> UserExist(string userName)
        {
            var model =await UnitOfWork.SehirContext.User.FirstOrDefaultAsync(x => x.Username == userName);

            if (model!=null)
            {
                return true;
            }
            return false;
        }


        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
