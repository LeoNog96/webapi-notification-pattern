using Microsoft.EntityFrameworkCore;
using NotificationPattern.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Data.Context
{
    public partial class NotificationPatternContext : DbContext
    {
        public NotificationPatternContext()
        {

        }

        public NotificationPatternContext(DbContextOptions<NotificationPatternContext> options)
            : base(options)
        {

        }

        public virtual DbSet<EntityNotificationEntity> EntityNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=notification-pattern;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityNotificationEntity>(entity =>
            {
                entity.ToTable("entity_notifications");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
