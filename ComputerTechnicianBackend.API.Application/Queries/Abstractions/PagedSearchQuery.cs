using ComputerTechnicianBackend.API.Contracts.Incoming.Abstractions;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Queries.Abstractions
{
    public class PagedSearchQuery<TFound, TSearchCondition> : IRequest<PagedResponse<TFound>>
        where TSearchCondition : PagedDTOBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PagedSearchQuery{TFound, TSearchCondition}" /> class.
        /// </summary>
        public PagedSearchQuery(TSearchCondition searchCondition)
        {
            SearchCondition = searchCondition;
        }

        /// <summary>
        ///     Gets or sets the parameters that will be used to execute the search query.
        /// </summary>
        public TSearchCondition SearchCondition { get; }
    }
}
