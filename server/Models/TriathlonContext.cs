using Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public partial class TriathlonContext : DbContext
    {
        public TriathlonContext()
        {
        }

        public TriathlonContext(DbContextOptions<TriathlonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Result> Results { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.HasKey(e => e.Athlete_id);

                entity.Property(e => e.Athlete_id)
                    .HasColumnName("Athlete_id")
                    .HasColumnType("int");

                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.HasKey(e => e.Format_id);

                entity.Property(e => e.Format_id)
                    .HasColumnName("Format_id")
                    .HasColumnType("int");

                entity.Property(e => e.Distance_Swim)
                    .HasColumnName("Distance_Swim")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Distance_Bike)
                    .HasColumnName("Distance_Bike")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Distance_Run)
                    .HasColumnName("Distance_Run")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Race_id);

                entity.Property(e => e.Race_id)
                    .HasColumnName("Race_id")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Race_Format_id)
                    .HasColumnName("Race_Format_id")
                    .HasColumnType("int");

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.Race_Format_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Races_Races");

                entity.Property(e => e.Year).HasColumnType("int");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Result_Id);

                entity.Property(e => e.Result_Id)
                    .HasColumnName("Result_Id")
                    .HasColumnType("int");

                entity.Property(e => e.Result_Athlete_Id)
                    .HasColumnName("Result_Athlete_Id")
                    .HasColumnType("int");

                entity.Property(e => e.Result_Race_Id)
                    .HasColumnName("Result_Race_Id")
                    .HasColumnType("int");

                entity.Property(e => e.Time_Bike).HasColumnName("Time_Bike");

                entity.Property(e => e.Time_Run).HasColumnName("Time_Run");

                entity.Property(e => e.Time_Swim).HasColumnName("Time_Swim");

                entity.Property(e => e.Time_T1).HasColumnName("Time_T1");

                entity.Property(e => e.Time_T2).HasColumnName("Time_T2");

                entity.HasOne(d => d.Athlete)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Result_Athlete_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Athletes");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Result_Race_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Formats");
            });
        }
    }
}
