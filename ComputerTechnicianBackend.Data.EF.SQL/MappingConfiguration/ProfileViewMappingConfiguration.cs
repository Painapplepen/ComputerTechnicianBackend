using ComputerTechnicianBackend.Data.Domain.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTechnicianBackend.Data.EF.SQL.MappingConfiguration
{
    public class ProfileViewMappingConfiguration : IEntityTypeConfiguration<PersonalDataView>
    {
        public void Configure(EntityTypeBuilder<PersonalDataView> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToView("View_PersonalDataView");
            builder.Property(v => v.Name).HasColumnName("Name");
            builder.Property(v => v.SecondName).HasColumnName("SecondName");
            builder.Property(v => v.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(v => v.City).HasColumnName("City");
            builder.Property(v => v.Phone).HasColumnName("Phone");
            builder.Property(v => v.CardNumber).HasColumnName("CardNumber");
            builder.Property(v => v.EpirationDate).HasColumnName("EpirationDate");
        }
    }
}
