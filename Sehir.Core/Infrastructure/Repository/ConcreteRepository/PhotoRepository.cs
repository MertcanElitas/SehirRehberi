using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sehir.Common.Dto;
using Sehir.Common.Dto.Photo;
using Sehir.Core.Infrastructure.Uow;
using Sehir.Domain.Domains;

namespace Sehir.Core.Infrastructure.Repository.ConcreteRepository
{
    public class PhotoRepository : IPhotoService
    {
        public int AddPhoto(PhotoForCreationDto photoDto)
        {
          
            var photo = new Photo()
            {
                Url = photoDto.Url,
                PublicId = photoDto.PublicId,
                CreatedDate = photoDto.DateAdded,
                Description = photoDto.Description,
                IsDeleted = false,
                
                City = new City
                {
                    Description = photoDto.city.Description,
                    Name = photoDto.city.Name,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    userId = photoDto.city.UserId,

                },

            };

            if (!photoDto.city.PhotoDtos.Any(x => x.IsMain))
                photo.IsMain = true;

            UnitOfWork.SehirContext.Photo.Add(photo);
            var LastPhoto = UnitOfWork.SehirContext.Photo.Last();
            int result = UnitOfWork.SehirContext.SaveChanges();

            if (result>0)
            {
                return LastPhoto.Id;
            }
            return default(int);


        }
    }
}
