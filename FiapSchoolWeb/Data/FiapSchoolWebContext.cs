using Microsoft.EntityFrameworkCore;
using FiapSchool.Infrastructure.Services;
using FiapSchoolWeb.Core.Models;

namespace FiapSchoolWeb.Data
{
    public class FiapSchoolWebContext : DbContext
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public FiapSchoolWebContext(DbContextOptions<FiapSchoolWebContext> options, DbConnectionFactory dbConnectionFactory) : base(options)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }
        public DbSet<AlunoTurmaModel> Aluno_Turma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurmaModel>()
                .HasKey(at => new { at.Aluno_Id, at.Turma_Id });
        }
    }
}
