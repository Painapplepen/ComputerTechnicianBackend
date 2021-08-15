using ComputerTechnicianBackend.API.Contracts.Incoming.Abstractions;
using System;

namespace ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions
{
    public class ProductSearchCondition : PagedDTOBase
    {
        public string[] Name { get; set; }
        public string[] Processor { get; set; }
        public string[] VidioCard { get; set; }
        public long[] MemoryCapacity { get; set; }
        public string[] DriveConfiguration { get; set; }
        public long[] ScreenDiagonal { get; set; }
        public string[] ScreenResolution { get; set; }
        public long[] Cost { get; set; }
        public long[] Amount { get; set; }
        public bool[] InStock { get; set; }
    }
}
