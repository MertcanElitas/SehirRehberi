using Sehir.Common.Dto;
using Sehir.Common.Dto.Photo;
using Sehir.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Core.Infrastructure.Repository
{
   public interface IPhotoService
    {

        int AddPhoto(PhotoForCreationDto photoDto);


    }
}
