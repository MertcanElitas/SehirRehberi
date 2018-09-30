using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Domain.Domains.Abstract
{
   public abstract class EntityBase
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }


    }
}
