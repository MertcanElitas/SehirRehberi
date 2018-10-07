using Sehir.Common.Helpers;
using Sehir.Core.Infrastructure.Repository;
using Sehir.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Core.Services
{
    public  class Services
    {


       public static IValueService ValueService
        {
            get { return ServiceIoc.Container.Resolve<IValueService>(); }
        }

        public static IEntityRepository EntityRepository
        {
            get
            {
                return ServiceIoc.Container.Resolve<IEntityRepository>();
            }
        }


        public static IAuthRepository AuthRepository
        {
            get
            {
                return ServiceIoc.Container.Resolve<IAuthRepository>();

            }
        }


        public static IPhotoService PhotoService
        {
            get
            {
                return ServiceIoc.Container.Resolve<IPhotoService>();
            }
        }

    }
}
