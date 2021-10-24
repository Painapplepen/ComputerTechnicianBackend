using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Views;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Queries.PersonalDataQueries
{
    public class GetPersonalDataQuery : IRequest<PersonalDataDTO>
    {
        public long Id { get; }

        public GetPersonalDataQuery(long id)
        {
            Id = id;
        }
    }

    public class GetPersonalDataQueryHandler : IRequestHandler<GetPersonalDataQuery, PersonalDataDTO>
    {
        private readonly IPersonalDataViewService personalDataService;
        public GetPersonalDataQueryHandler(IPersonalDataViewService personalDataService)
        {
            this.personalDataService = personalDataService;
        }

        public async Task<PersonalDataDTO> Handle(GetPersonalDataQuery request, CancellationToken cancellationToken)
        {
            var personalData = await personalDataService.GetAsync(request.Id, cancellationToken);

            if (personalData == null)
            {
                return null;
            }

            return MapToPersonalDataDTO(personalData);
        }

        public PersonalDataDTO MapToPersonalDataDTO(PersonalDataView personalData)
        {
            return new PersonalDataDTO()
            {
                Name = personalData.Name,
                SecondName = personalData.SecondName,
                DateOfBirth = personalData.DateOfBirth,
                City = personalData.City,
                Phone = personalData.Phone,
                CardNumber = personalData.CardNumber
            };
        }
    }
}
