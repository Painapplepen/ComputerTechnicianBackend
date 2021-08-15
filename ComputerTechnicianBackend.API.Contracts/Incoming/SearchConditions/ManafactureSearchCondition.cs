using ComputerTechnicianBackend.API.Contracts.Incoming.Abstractions;

namespace ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions
{
    public class ManafactureSearchCondition : PagedDTOBase
    {
        public string[] Address { get; set; }
        public string[] City { get; set; }
        public string[] Country { get; set; }
        public string[] Name { get; set; }
    }
}
