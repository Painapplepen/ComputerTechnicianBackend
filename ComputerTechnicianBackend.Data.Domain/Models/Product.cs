using System;
using System.Collections.Generic;

namespace ComputerTechnicianBackend.Data.Domain.Models
{
    public class Product : KeyedEntityBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Processor { get; set; }
        public string VidioCard { get; set; }
        public long MemoryCapacity { get; set; }
        public string DriveConfiguration { get; set; }
        public long ScreenDiagonal { get; set; }
        public string ScreenResolution { get; set; }
        public long Cost { get; set; }
        public ProductType ProductType { get; set; }
        public long ProductTypeId { get; set; }
    }
}
