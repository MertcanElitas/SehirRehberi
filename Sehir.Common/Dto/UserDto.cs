using Sehir.Common.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto
{
   public class UserDto:EntityBaseAbstract
    {

        public UserDto()
        {
            CityDtos = new List<CityDto>();
        }
        public List<CityDto> CityDtos { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
