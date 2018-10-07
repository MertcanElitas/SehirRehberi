using AutoMapper;
using Sehir.Common.Dto;
using Sehir.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.Helper
{
    public class AutoMapperProfiles:Profile
    {
        //Mapper Helper City içinde List Photo var Dto içinde ise string PhotoUrl Mapleme için helper oluşturduk
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
        }


     

    }
}
