using Microsoft.EntityFrameworkCore;
using Entities;

namespace TriCalcAngular.Models
{
    public partial class TriathlonResultsContext : DbContext
    {
        public TriathlonResultsContext()
        {
        }

        public TriathlonResultsContext(DbContextOptions<TriathlonResultsContext> options)
            : base(options)
        {
        }

        public TriathlonResultsContext(string connString)
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Format> Events { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning /*To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.*/
//                optionsBuilder.UseSqlServer("Server=SAU019860\\SCOTCOURTSDB;Database=TriathlonResults;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.HasKey(e => e.Athlete_id);

                entity.Property(e => e.Athlete_id)
                    .HasColumnName("Athlete_id")
                    .HasColumnType("numeric(18, 0)");

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
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Race_id);

                entity.Property(e => e.Race_id)
                    .HasColumnName("Race_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Race_Format_id)
                    .HasColumnName("Race_Format_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.Race_Format_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Races_Races");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Result_Id);

                entity.Property(e => e.Result_Id)
                    .HasColumnName("Result_Id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Result_Athlete_Id)
                    .HasColumnName("Result_Athlete_Id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Result_Race_Id)
                    .HasColumnName("Result_Race_Id")
                    .HasColumnType("numeric(18, 0)");

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
                    .HasConstraintName("FK_Results_Races");
            });
        }
    }
}
