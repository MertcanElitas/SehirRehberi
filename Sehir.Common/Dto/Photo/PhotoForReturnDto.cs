using System;
using System.Collections.Generic;
using System.Text;

namespace Sehir.Common.Dto.Photo
{
    public class PhotoForReturnDto
    {

        public int Id { get; set; }
        public string url { get; set; }

        public string Description { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

    }
}
