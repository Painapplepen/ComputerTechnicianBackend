using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerTechnicianBackend.Data.EF.SQL.Migrations
{
    public partial class AddingViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string script = @"CREATE VIEW View_UserView AS SELECT 
                                    [ComputerTechnician].[dbo].[Users].[Id], [ComputerTechnician].[dbo].[Users].[UserName],[ComputerTechnician].[dbo].[Users].[Email],
                                    [ComputerTechnician].[dbo].[Roles].[Name] as Role, [ComputerTechnician].[dbo].[Baskets].[Amount] as BasketSize
                                    FROM [ComputerTechnician].[dbo].[Users] INNER JOIN [ComputerTechnician].[dbo].[Roles] 
                                    ON [ComputerTechnician].[dbo].[Users].[RoleId] = [ComputerTechnician].[dbo].[Roles].[Id] 
                                    INNER JOIN [ComputerTechnician].[dbo].[Baskets] ON [ComputerTechnician].[dbo].[Users].[Id] = [ComputerTechnician].[dbo].[Baskets].[UserId]";

            migrationBuilder.Sql($"EXECUTE('{script}')");

            const string script2 = @"CREATE VIEW View_PersonalDataView AS SELECT 
                                    [ComputerTechnician].[dbo].[PersonalDatas].[Id], [ComputerTechnician].[dbo].[PersonalDatas].[Name],[ComputerTechnician].[dbo].[PersonalDatas].[SecondName],
                                    [ComputerTechnician].[dbo].[PersonalDatas].[DateOfBirth], [ComputerTechnician].[dbo].[Cities].[Name] as City,
                                    [ComputerTechnician].[dbo].[Phones].[PhoneNumber] as Phone,[ComputerTechnician].[dbo].[CreditCards].[CardNumber],
                                    [ComputerTechnician].[dbo].[CreditCards].[EpirationDate]
                                    FROM [ComputerTechnician].[dbo].[PersonalDatas] INNER JOIN [ComputerTechnician].[dbo].[Cities] 
                                    ON [ComputerTechnician].[dbo].[PersonalDatas].[CityId] = [ComputerTechnician].[dbo].[Cities].[Id] 
                                    INNER JOIN [ComputerTechnician].[dbo].[Phones] ON [ComputerTechnician].[dbo].[PersonalDatas].[PhoneId] = [ComputerTechnician].[dbo].[Phones].[Id]
                                    INNER JOIN [ComputerTechnician].[dbo].[CreditCards] ON [ComputerTechnician].[dbo].[PersonalDatas].[CreditCardId] = [ComputerTechnician].[dbo].[CreditCards].[Id]";

            migrationBuilder.Sql($"EXECUTE('{script2}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
