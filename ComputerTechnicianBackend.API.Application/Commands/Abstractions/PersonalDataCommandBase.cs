using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using MediatR;

namespace ComputerTechnicianBackend.API.Application.Commands.Abstractions
{
    public class PersonalDataCommandBase<TResponse> : IRequest<TResponse>
    {
        public PersonalDataDTO Entity { get; set; }
        public long Id { get; set; }

        protected PersonalDataCommandBase(long id, PersonalDataDTO entity)
        {
            Id = id;
            Entity = entity;
        }

        protected PersonalDataCommandBase(PersonalDataDTO entity)
        {
            Entity = entity;
        }
    }
}
