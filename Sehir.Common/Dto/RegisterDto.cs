using Sehir.Common.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto
{
   public class RegisterDto:EntityBaseAbstract
    {
        public string  Username { get; set; }

        public string Password { get; set; }



    }
}
