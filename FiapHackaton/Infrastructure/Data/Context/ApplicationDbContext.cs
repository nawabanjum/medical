using FiapHackaton.Domain.Entities;
using FiapHackaton.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FiapHackaton.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile>  UserProfiles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração das chaves primárias compostas
            //modelBuilder.Entity<AppointmentModel>()
            //    .HasKey(a => new { a.Id, a.PatientId, a.DoctorId });

            //// Configuração das chaves estrangeiras
            //modelBuilder.Entity<AppointmentModel>();
            //            //.HasOne(a => a.PatientId)
            //            //.WithMany(p => p.Appointments)
            //            // .HasForeignKey(a => a.PatientId);

            //modelBuilder.Entity<AppointmentModel>();
            //.HasOne(a => a.DoctorId)
            //.WithMany(d => d.Appointments)
            //.HasForeignKey(a => a.DoctorId);
        }
    }
}
