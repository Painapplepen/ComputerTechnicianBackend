using ComputerTechnicianBackend.API.Contracts.Incoming.Abstractions;

namespace ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions
{
    public class UserSearchCondition : PagedDTOBase
    {
        public string[] UserName { get; set; } 
        public string[] Email { get; set; }
        public string[] Role { get; set; }
        public long[] BasketSize { get; set; }  
    }
}
