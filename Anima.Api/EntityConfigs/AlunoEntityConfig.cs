using Anima.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anima.Api.TypeBuilders
{
    public class AlunoEntityConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Ra);
            builder.Property(x => x.Ra)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .IsRequired();
            builder.HasIndex(x => x.Cpf)
                .IsUnique();
            builder.Property(x => x.Nome)
                .HasMaxLength(180)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(180)
                .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Login)
                .HasMaxLength(40)
                .IsRequired();
            builder.HasIndex(x => x.Login)
                .IsUnique();
            builder.Property(x => x.Senha)
                .HasMaxLength(180)
                .IsRequired();
        }
    }
}