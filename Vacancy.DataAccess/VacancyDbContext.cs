using Microsoft.EntityFrameworkCore;
using Vacancy.DataAccess.Entities;

namespace Vacancy.DataAccess
{
    public class VacancyDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeStatus> ResumeStatuses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillInResume> SkillsInResumes { get; set; }
        public DbSet<SkillInVacancy> SkillsInVacancies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Entities.Vacancy> Vacancies { get; set; }
        public DbSet<VacancyStatus> VacancyStatuses { get; set; }


        public VacancyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(x => x.Id);
            modelBuilder.Entity<Admin>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Company>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Resume>().HasKey(x => x.Id);
            modelBuilder.Entity<Resume>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<Resume>().HasOne(x => x.ResumeStatus)
                .WithMany(x => x.Resumes)
                .HasForeignKey(x => x.ResumeStatusId);
            modelBuilder.Entity<Resume>().HasOne(x => x.User)
                .WithMany(x => x.Resumes)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ResumeStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<ResumeStatus>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Skill>().HasKey(x => x.Id);
            modelBuilder.Entity<Skill>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<SkillInResume>().HasKey(x => x.Id);
            modelBuilder.Entity<SkillInResume>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<SkillInResume>().HasOne(x => x.Skill)
                .WithMany(x => x.SkillInResumes)
                .HasForeignKey(x => x.SkillId);
            modelBuilder.Entity<SkillInResume>().HasOne(x => x.Resume)
                .WithMany(x => x.SkillsInResume)
                .HasForeignKey(x => x.ResumeId);

            modelBuilder.Entity<SkillInVacancy>().HasKey(x => x.Id);
            modelBuilder.Entity<SkillInVacancy>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<SkillInVacancy>().HasOne(x => x.Skill)
                .WithMany(x => x.SkillInVacancies)
                .HasForeignKey(x => x.SkillId);
            modelBuilder.Entity<SkillInVacancy>().HasOne(x => x.Vacancy)
                .WithMany(x => x.SkillsInVacancy)
                .HasForeignKey(x => x.VacancyId);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<User>().HasOne(x => x.UserType)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserTypeId);

            modelBuilder.Entity<UserType>().HasKey(x => x.Id);
            modelBuilder.Entity<UserType>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<Entities.Vacancy>().HasKey(x => x.Id);
            modelBuilder.Entity<Entities.Vacancy>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<Entities.Vacancy>().HasOne(x => x.Company)
                .WithMany(x => x.Vacancies)
                .HasForeignKey(x => x.CompanyId);
            modelBuilder.Entity<Entities.Vacancy>().HasOne(x => x.VacancyStatus)
                .WithMany(x => x.Vacancies)
                .HasForeignKey(x => x.VacancyStatusId);

            modelBuilder.Entity<VacancyStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<VacancyStatus>().HasIndex(x => x.ExternalId).IsUnique();
        }
    }
}
