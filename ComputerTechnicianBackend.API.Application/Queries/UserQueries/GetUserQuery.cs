using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace ComputerTechnicianBackend.API.Application.Queries.UserQueries
{
    public class GetUserQuery : IRequest<UserDTO>
    {
        public long Id { get; }

        public GetUserQuery(long id)
        {
            Id = id;
        }
    }

    public class GetBookQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IUserService userService;
        public GetBookQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return null;
            }

            return MapToUserDTO(user);
        }

        public UserDTO MapToUserDTO(User user)
        {
            return new UserDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
            };
        }
    }
}
