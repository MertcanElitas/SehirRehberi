using Sehir.Common.Dto;
using Sehir.Core.Infrastructure.Uow;
using Sehir.Core.Services.Interfaces;
using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sehir.Core.Services
{
    public class ValueService : IValueService
    {
        public List<ValuesDto> GetAll()
        {
            var model = UnitOfWork.SehirContext.Values.Select(x=> new ValuesDto {

                Name=x.Name,
                CreatedDate=x.CreatedDate,
                IsDeleted=x.IsDeleted
               
            }).ToList();
            return model;
        }
    }
}
