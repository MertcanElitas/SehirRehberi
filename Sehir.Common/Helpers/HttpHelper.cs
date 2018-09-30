using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sehir.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sehir.Common.Helpers
{
    public class HttpHelper
    {
        public static IHttpContextAccessor _httpContextAccessor;
        public static IConfiguration _configuration;

        public static void Configure(IHttpContextAccessor httpcontextaccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpcontextaccessor;
            _configuration = configuration;
        }


        public HttpContext GetContext
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

       


        public static T GetService<T>()
        {
            return (T)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(T));
        }


    }
    //public class ConfigurationManager
    //{

    //    public static Dictionary<string, string> _AppSetting;

    //    public static Dictionary<string, string> AppSetting
    //    {
    //        get
    //        {
    //            var allsettings = HttpHelper._configuration.GetSection("AppConfing").GetChildren();
    //            _AppSetting = allsettings.Select(x => new { x.Key, x.Value }).ToDictionary(x => x.Key, x => x.Value);
    //            return _AppSetting;
    //            }
           
    //    }

    //}

}
