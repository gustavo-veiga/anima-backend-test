using Anima.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anima.Api.EntityConfigs
{
    public class MatriculaEntityConfig : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");
            builder.HasKey(x => new {x.CodGrade, x.Ra});
            builder.HasOne(x => x.Grade)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.CodGrade);
            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.Ra);
        }
    }
}