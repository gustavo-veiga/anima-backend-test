using Anima.Api.EntityConfigs;
using Anima.Api.EntityConfigurations;
using Anima.Api.TypeBuilders;
using Anima.Model;
using Microsoft.EntityFrameworkCore;

namespace Anima.Api.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Grade> Grades { get; set; }
        
        public DbSet<Aluno> Alunos { get; set; }
        
        public DbSet<Matricula> Matriculas { get; set; }
        
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GradeEntityConfig());
            modelBuilder.ApplyConfiguration(new AlunoEntityConfig());
            modelBuilder.ApplyConfiguration(new MatriculaEntityConfig());
            modelBuilder.ApplyConfiguration(new ProfessorEntityConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}