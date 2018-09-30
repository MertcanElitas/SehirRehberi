using Sehir.Domain.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sehir.Domain.Domains
{
   public class Values:EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

    }
}
