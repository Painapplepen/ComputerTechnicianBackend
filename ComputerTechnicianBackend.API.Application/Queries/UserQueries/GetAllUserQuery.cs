using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Domain.Views;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.UserQueries
{
    public class GetAllUserQuery : IRequest<IReadOnlyCollection<FoundUserDTO>>
    {
        public GetAllUserQuery() { }
    }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IReadOnlyCollection<FoundUserDTO>>
    {
        private readonly IUserViewService userService;

        public GetAllUserQueryHandler(IUserViewService userService)
        {
            this.userService = userService;
        }

        public async Task<IReadOnlyCollection<FoundUserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await userService.GetAllAsync(cancellationToken);

            return suppliers.Select(MapToFoundUserDTO).ToArray();
        }

        private FoundUserDTO MapToFoundUserDTO(UserView user)
        {
            return new FoundUserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role  = user.Role,
                BasketSize = user.BasketSize
            };
        }
    }
}
