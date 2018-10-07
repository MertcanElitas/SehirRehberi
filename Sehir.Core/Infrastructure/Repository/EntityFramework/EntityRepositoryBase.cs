using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sehir.Common.Dto;
using Sehir.Core.Infrastructure.Uow;
using Sehir.Domain.Domains;

namespace Sehir.Core.Infrastructure.Repository.EntityFramework
{
    public class EntityRepositoryBase : IEntityRepository
    {
        


        public void Add<T>(T Entity) where T:class
        {
            

           UnitOfWork.SehirContext.Add(Entity);
        }

        public CityDto GetById(int cityid)
        {
           var model= UnitOfWork.SehirContext.City.Include(x=>x.Photos).FirstOrDefault(x => x.Id == cityid);
            var CityDto = new CityDto
            {
                Name = model.Name,
                CreatedDate = model.CreatedDate,
                Description = model.Description,

                PhotoDtos = model.Photos.Select(a => new PhotoDto
                {
                    Url = a.Url,

                    CreatedDate = a.CreatedDate,
                    IsMain = a.IsMain,
                    PublicId = a.PublicId,
                    Description = a.Description,
                    City = new CityDto
                    {
                        Name = model.Name,
                        Description = model.Description,
                        PhotoUrl = a.Url

                    },
                    CityId = a.CityId,
                }).ToList(),
                
            };
            
            


            return CityDto;
        }

        public List<CityDto> GetCities()
        {
            var model = UnitOfWork.SehirContext.City.Include(x=>x.Photos).Select(x=> new CityDto {


                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                
                PhotoDtos = x.Photos.Select(a => new PhotoDto()
                {

                    Url = a.Url,
                    CreatedDate = a.CreatedDate,
                    IsMain = a.IsMain,
                    PublicId = a.PublicId,
                    Description = a.Description,
                    CityId = a.CityId,


                }).ToList(),




            }).ToList();
            return model;
        }

        public PhotoDto GetPhoto(int id)
        {
            var model = UnitOfWork.SehirContext.Photo.Include(a => a.City).Select(x => new PhotoDto {

                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted,
                CityId = x.CityId,
                City = new CityDto
                {
                    Description = x.City.Description,
                    IsDeleted = x.City.IsDeleted,
                    CreatedDate = x.City.CreatedDate,
                    Name = x.City.Name,
                    UserId = x.City.userId
                },
                IsMain =x.IsMain,
                Url=x.Url,
                


            }).FirstOrDefault(x => x.Id == id);
            return model;
        }

        public List<PhotoDto> GetPhotosByCity(int id)
        {
            var model = UnitOfWork.SehirContext.Photo.Where(x => x.CityId == id).Select(x => new PhotoDto {

                Url = x.Url,
                CityId = x.CityId,
               Id=x.Id,
               IsMain=x.IsMain,
               Description=x.Description,
               IsDeleted=x.IsDeleted

                
            }).ToList();
            return model;
        }

        public bool SaveAll()
        {
            return UnitOfWork.SehirContext.SaveChanges() > 0;
        }

        public void Delete<T>(T Entity) where T:class
        {
            UnitOfWork.SehirContext.Remove(Entity);
        }
    }
}
