using Microsoft.AspNetCore.Identity;
using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Domain.Domains
{
  public  class User: EntityBase
    {
        public User()
        {
            Cities = new List<City>();
        }
        public string Username { get; set; }
        public byte[] Passwordsalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public List<City> Cities { get; set; }

    }
}
