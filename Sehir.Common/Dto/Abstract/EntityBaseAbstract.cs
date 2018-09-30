using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto.Abstract
{
   public abstract class EntityBaseAbstract
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }


    }
}
