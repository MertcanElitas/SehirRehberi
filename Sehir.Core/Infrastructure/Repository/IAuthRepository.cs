using Sehir.Common.Dto;
using Sehir.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sehir.Core.Infrastructure.Repository
{
   public interface IAuthRepository
    {

        Task<User> Register(RegisterDto user);
        Task<User> Login(string Username, string password);
        Task<bool> UserExist(string userName);

    }
}
