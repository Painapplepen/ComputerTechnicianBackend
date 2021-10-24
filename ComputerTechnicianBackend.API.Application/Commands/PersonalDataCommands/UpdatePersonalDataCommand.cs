using ComputerTechnicianBackend.API.Application.Commands.Abstractions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComputerTechnicianBackend.API.Contracts.Outgoing.Abstractions;


namespace ComputerTechnicianBackend.API.Application.Commands.PersonalDataCommands
{
    public class UpdatePersonalDataCommand : PersonalDataCommandBase<Response>
    {
        public UpdatePersonalDataCommand(long id, PersonalDataDTO update) : base(id, update) { }
    }

    public class UpdatePersonalDataCommandHandler : IRequestHandler<UpdatePersonalDataCommand, Response>
    {
        private readonly IPersonalDataService personalDataService;
        private readonly ICreditCardService creditCardService;
        private readonly IPhoneService phoneService;
        private readonly ICityService cityService;

        public UpdatePersonalDataCommandHandler(IPersonalDataService personalDataService)
        {
            this.personalDataService = personalDataService;
        }

        public async Task<Response> Handle(UpdatePersonalDataCommand request, CancellationToken cancellationToken)
        {
            var personalData = await personalDataService.GetAsync(request.Id, cancellationToken);

            if (personalData == null)
            {
                return Response.Error;
            }

            var personalDataToUpdate = await MaptoPersonalData(request.Entity, personalData);

            var updatedPersonalData = await personalDataService.UpdateAsync(personalDataToUpdate);

            if (updatedPersonalData == null)
            {
                return Response.Error;
            }

            return Response.Successful;
        }

        private async Task<long> UpdateCreditCard(PersonalDataDTO personalData, long id, CancellationToken cancellationToken = default)
        {
            var creditCard = await creditCardService.GetAsync(id, cancellationToken);

            creditCard.CardNumber = personalData.CardNumber;
            creditCard.EpirationDate = personalData.EpirationDate;

            var insertedCreditCard = await creditCardService.UpdateAsync(creditCard);

            return insertedCreditCard.Id;
        }

        private async Task<long> UpdatePhone(string phoneNumber, long id, CancellationToken cancellationToken = default)
        {
            var phone = await phoneService.GetAsync(id, cancellationToken);

            phone.PhoneNumber = phoneNumber;

            var insertedPhone = await phoneService.UpdateAsync(phone);

            return insertedPhone.Id;
        }

        private async Task<long> UpdateCity(string cityName, long id, CancellationToken cancellationToken = default)
        {
            var city = await cityService.GetAsync(id, cancellationToken);

            city.Name = cityName;

            var InsertedCity = await cityService.InsertAsync(city);

            return InsertedCity.Id;
        }

        private async Task<PersonalData> MaptoPersonalData(PersonalDataDTO personalDataDTO, PersonalData personalData)
        {
            var creditCardId = await UpdateCreditCard(personalDataDTO, personalData.CreditCardId.Value);
            var phoneId = await UpdatePhone(personalDataDTO.Phone, personalData.PhoneId.Value);
            var cityId = await UpdateCity(personalDataDTO.City, personalData.CityId.Value);

            return new PersonalData
            {
                Name = personalData.Name,
                SecondName = personalData.SecondName,
                DateOfBirth = personalData.DateOfBirth,
                CityId = cityId,
                PhoneId = phoneId,
                CreditCardId = creditCardId
            };
        }
    }
}
