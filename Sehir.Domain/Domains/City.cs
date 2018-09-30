using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Domain.Domains
{
    public class City:EntityBase
    {
        public City()
        {
            Photos = new List<Photo>();
        }
      
        public User User { get; set; }
        public int userId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }


        public List<Photo> Photos { get; set; }

    }
}
