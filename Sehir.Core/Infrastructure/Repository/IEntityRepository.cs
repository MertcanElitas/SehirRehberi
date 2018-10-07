using Sehir.Common.Dto;
using Sehir.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Core.Infrastructure.Repository
{
   public interface IEntityRepository
    {

        void Add<T>(T Entity) where T:class;
        void Delete<T>(T Entity)where T:class;
        bool SaveAll();


        List<CityDto> GetCities();
        List<PhotoDto> GetPhotosByCity(int id);
        CityDto GetById(int cityid);
        PhotoDto GetPhoto(int id);
        

    }
}
