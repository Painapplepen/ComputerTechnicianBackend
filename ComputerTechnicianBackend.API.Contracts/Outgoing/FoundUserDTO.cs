namespace ComputerTechnicianBackend.API.Contracts.Outgoing
{
    public class FoundUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public long BasketSize { get; set; }
    }
}
