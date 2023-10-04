using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Data.Map
{
    public class UserAuthMap : IEntityTypeConfiguration<UserAuthModel>
    {
        public void Configure(EntityTypeBuilder<UserAuthModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Role).HasMaxLength(155);
        }
    }
}