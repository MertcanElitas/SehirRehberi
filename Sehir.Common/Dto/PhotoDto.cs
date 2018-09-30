using Sehir.Common.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto
{
   public class PhotoDto:EntityBaseAbstract
    {

        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }


        public CityDto City { get; set; }

        public int CityId { get; set; }

    }
}
