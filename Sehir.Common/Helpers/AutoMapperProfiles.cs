using AutoMapper;
using Sehir.Common.Dto;
using Sehir.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sehir.Common.Helpers
{
    public class AutoMapperProfiles:Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ForMember(dest => dest.PhotoUrl, opt =>
            {

                opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url);
                
            });
        }


    }
}
