using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ContozooAPI.Model
{
    public partial class animalsContext : DbContext
    {
        public animalsContext()
        {
        }

        public animalsContext(DbContextOptions<animalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContozooAnimal> ContozooAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:contozoodbserver.database.windows.net,1433;Initial Catalog=ContosoAnimals;Persist Security Info=False;User ID=grainne;Password=Harpcity7!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ContozooAnimal>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__Contozoo__A21A73274933D9AA");

                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.ActiveHours)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Animal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
