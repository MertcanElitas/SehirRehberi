using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Helpers
{
   public class ServiceIoc
    {
        public class Container
        {
            public static T Resolve<T>()
            {
                return HttpHelper.GetService<T>();
            }
        }
    }
}
