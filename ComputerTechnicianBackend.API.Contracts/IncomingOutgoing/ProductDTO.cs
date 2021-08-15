using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Contracts.IncomingOutgoing
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Processor { get; set; }
        public string VidioCard { get; set; }
        public long MemoryCapacity { get; set; }
        public string DriveConfiguration { get; set; }
        public long ScreenDiagonal { get; set; }
        public string ScreenResolution { get; set; }
        public long Cost { get; set; }
        public long Amount { get; set; }
        public bool InStock { get; set; }
        public long ProductTypeId { get; set; }
    }
}
