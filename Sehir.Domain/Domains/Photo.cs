using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Domain.Domains
{
   public class Photo:EntityBase
    {

        public string Url { get; set; }
        public string Description { get; set; }
      
        public bool IsMain { get; set; }
        public string PublicId { get; set; }


        public City City { get; set; }

        public int CityId { get; set; }


    }
}
