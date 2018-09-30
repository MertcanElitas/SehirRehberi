using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sehir.Common.Helpers;
using Sehir.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Core.Infrastructure.Uow
{
  public  class UnitOfWork
    {
        protected UnitOfWork()
        {

        }

       
        public static SehirContext SehirContext
        {
            get
            {
               
                    return HttpHelper.GetService<SehirContext>();
              
               
            }
        }


        

    }
}
