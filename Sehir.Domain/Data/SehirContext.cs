using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sehir.Domain.Domains;
using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Domain.Data
{
   public class SehirContext:DbContext
    {
        public SehirContext(DbContextOptions<SehirContext> options):base(options) 
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Values> Values { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Photo> Photo { get; set; }
    }
}
