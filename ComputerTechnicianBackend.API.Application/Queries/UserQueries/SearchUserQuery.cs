using ComputerTechnicianBackend.API.Application.Commands.Abstractions;
using ComputerTechnicianBackend.API.Application.Queries.Abstractions;
using ComputerTechnicianBackend.API.Contracts.Incoming.SearchConditions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;
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
    public class SearchUserQuery : PagedSearchQuery<FoundUserDTO, UserSearchCondition>
    {
        public SearchUserQuery(UserSearchCondition searchCondition) : base(searchCondition)
        { }
    }

    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, PagedResponse<FoundUserDTO>>
    {
        private readonly IUserViewService userService;

        public SearchUserQueryHandler(IUserViewService userService)
        {
            this.userService = userService;
        }

        public async Task<PagedResponse<FoundUserDTO>> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            UserSearchCondition searchCondition = new UserSearchCondition()
            {
                UserName = GetFilterValues(request.SearchCondition.UserName),
                Email = GetFilterValues(request.SearchCondition.Email),
                Role = GetFilterValues(request.SearchCondition.Role),
                BasketSize = request.SearchCondition.BasketSize,
                Page = request.SearchCondition.Page,
                PageSize = request.SearchCondition.PageSize,
                SortDirection = request.SearchCondition.SortDirection,
                SortProperty = request.SearchCondition.SortProperty
            };

            var sortProperty = GetSortProperty(searchCondition.SortProperty);
            IReadOnlyCollection<UserView> foundUser = await userService.FindAsync(searchCondition, sortProperty);
            FoundUserDTO[] mappedUser = foundUser.Select(MapToFoundUserDTO).ToArray();
            var totalCount = await userService.CountAsync(searchCondition);

            return new PagedResponse<FoundUserDTO>
            {
                Items = mappedUser,
                TotalCount = totalCount
            };
        }

        private FoundUserDTO MapToFoundUserDTO(UserView user)
        {
            return new FoundUserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role,
                BasketSize = user.BasketSize,
            };
        }

        private string[] GetFilterValues(ICollection<string> values)
        {
            return values == null
                       ? Array.Empty<string>()
                       : values.Select(v => v.Trim()).Distinct().ToArray();
        }

        protected string GetSortProperty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return nameof(User.Id);
            }
            else if (propertyName.Equals("UserName", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(UserView.UserName);
            }
            else if (propertyName.Equals("Email", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(UserView.Email);
            }
            else if (propertyName.Equals("Role", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(UserView.Role);
            }
            else if (propertyName.Equals("BasketSize", StringComparison.InvariantCultureIgnoreCase))
            {
                return nameof(UserView.BasketSize);
            }

            return propertyName;
        }
    }
}
