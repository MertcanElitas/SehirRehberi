using Sehir.Common.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto
{
   public class CityDto:EntityBaseAbstract
    {

        public string Name { get; set; }
        public List<PhotoDto> PhotoDtos { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }



    }
}
