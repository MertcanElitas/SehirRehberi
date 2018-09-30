using Sehir.Common.Dto;
using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Core.Services.Interfaces
{
    public interface IValueService
    {

        List<ValuesDto> GetAll();
 
    }
}
