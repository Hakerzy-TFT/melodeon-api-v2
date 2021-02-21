using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace melodeon_api_v2.Models
{
    public partial class CerysContext : DbContext
    {
        public CerysContext()
        {
        }

        public CerysContext(DbContextOptions<CerysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Util> Utils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration");

                entity.Property(e => e.ConfigurationId).HasColumnName("configuration_id");

                entity.Property(e => e.ConfigurationLastLogin).HasColumnName("configuration_last_login");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.LogsId)
                    .HasName("PK__Logs__F37D07C68A2A43EE");

                entity.Property(e => e.LogsId).HasColumnName("logs_id");

                entity.Property(e => e.LogDate).HasColumnName("log_date");

                entity.Property(e => e.LogMsg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("log_msg");
            });

            modelBuilder.Entity<ServiceStatus>(entity =>
            {
                entity.ToTable("ServiceStatus");

                entity.Property(e => e.ServiceStatusId).HasColumnName("service_status_id");

                entity.Property(e => e.Api).HasColumnName("api");

                entity.Property(e => e.Db).HasColumnName("db");

                entity.Property(e => e.WebApp).HasColumnName("webApp");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserConfigurationId).HasColumnName("user_configuration_id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserUsername)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_username");

                entity.HasOne(d => d.UserConfiguration)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserConfigurationId)
                    .HasConstraintName("FK__Users__user_conf__114A936A");
            });

            modelBuilder.Entity<Util>(entity =>
            {
                entity.Property(e => e.UtilId).HasColumnName("util_id");

                entity.Property(e => e.UtilBody)
                    .IsUnicode(false)
                    .HasColumnName("util_body");

                entity.Property(e => e.UtilName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("util_name");

                entity.Property(e => e.UtilType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("util_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
