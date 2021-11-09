using ComputerTechnicianBackend.Data.Domain.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTechnicianBackend.Data.EF.SQL.MappingConfiguration
{
    public class UserViewMappingConfiguration : IEntityTypeConfiguration<UserView>
    {
        public void Configure(EntityTypeBuilder<UserView> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToView("View_UserView");
            builder.Property(v => v.UserName).HasColumnName("UserName");
            builder.Property(v => v.Email).HasColumnName("Email");
            builder.Property(v => v.Role).HasColumnName("Role");
            builder.Property(v => v.BasketSize).HasColumnName("BasketSize");
        }
    }
}
