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

namespace ComputerTechnicianBackend.API.Application.Commands.PersonalDataCommands
{
    public class AddPersonalDataCommand : PersonalDataCommandBase<long>
    {
        public AddPersonalDataCommand(PersonalDataDTO personalData) : base(personalData) { }
    }

    public class AddPersonalDataCommandHandler : IRequestHandler<AddPersonalDataCommand, long>
    {
        private readonly IPersonalDataService personalDataService;
        private readonly ICreditCardService creditCardService;
        private readonly IPhoneService phoneService;
        private readonly ICityService cityService;

        public AddPersonalDataCommandHandler(IPersonalDataService personalDataService, 
            ICreditCardService creditCardService, IPhoneService phoneService, ICityService cityService)
        {
            this.personalDataService = personalDataService;
        }

        public async Task<long> Handle(AddPersonalDataCommand request, CancellationToken cancellationToken)
        {
            var author = await MapToPersonalData(request.Entity);

            var insertedAuthor = await personalDataService.InsertAsync(author);

            return insertedAuthor.Id;
        }

        private async Task<long> InsertCreditCard(PersonalDataDTO personalData)
        {
            var newCreditCard = new CreditCard
            {
                CardNumber = personalData.CardNumber,
                EpirationDate = personalData.EpirationDate,

            };

            var insertedCreditCard = await creditCardService.InsertAsync(newCreditCard);

            return insertedCreditCard.Id;
        }

        private async Task<long> InsertPhone(string phone)
        {
            var newPhone =  new Phone
            {
                PhoneNumber = phone
            };

            var insertedPhone = await phoneService.InsertAsync(newPhone);

            return insertedPhone.Id;
        }

        private async Task<long> InsertCity(string city)
        {
            var newCity = new City
            {
                Name = city
            };

            var InsertedCity = await cityService.InsertAsync(newCity);

            return InsertedCity.Id;
        }

        private async Task<PersonalData> MapToPersonalData(PersonalDataDTO personalData)
        {
            var creditCardId = await InsertCreditCard(personalData);
            var phoneId = await InsertPhone(personalData.Phone);
            var cityId = await InsertCity(personalData.City);

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
