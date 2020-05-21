using Anima.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anima.Api.TypeBuilders
{
    public sealed class GradeEntityConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.CodGrade);
            builder.Property(x => x.CodGrade)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.Curso)
                .HasMaxLength(180)
                .IsRequired();
            builder.Property(x => x.Turma)
                .HasMaxLength(180)
                .IsRequired();
            builder.Property(x => x.Disciplina)
                .HasMaxLength(180)
                .IsRequired();
        }
    }
}