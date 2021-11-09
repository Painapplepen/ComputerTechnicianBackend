using ComputerTechnicianBackend.API.Application.Commands.Abstractions;
using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Enums;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.API.Application.Commands.AuthCommands
{
    public class RegisterUserCommand : UserCommandBase<bool>
    {
        public RegisterUserCommand(UserDTO user) : base(user) { }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserService userService;
        private readonly IBasketService basketService;

        public RegisterUserCommandHandler(IUserService userService, IBasketService basketService)
        {
            this.basketService = basketService;
            this.userService = userService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var checkingForExist = await userService.ExistAsync(request.Entity);

            if (checkingForExist)
            {
                return false;
            }

            var role = (long)RoleEnums.User;
            var newUser = MapToUser(request.Entity, role);
            var insertedUser = await userService.InsertAsync(newUser);

            if(insertedUser == null)
            {
                return false;
            }

            var getBasket = GetBasket(insertedUser.Id);
            var addedBasket = await basketService.InsertAsync(getBasket);

            if(addedBasket == null)
            {
                return false;
            }
            return true;
        }

        private User MapToUser(UserDTO user, long roleId)
        {
            return new User
            {
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                RoleId = roleId
            };
        }

        private Basket GetBasket(long userId)
        {
            return new Basket
            {
                UserId = userId,
                Amount = 0,
            };
        }
    }
}