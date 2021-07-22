using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test_book_repository_webapi.Models
{
    public partial class BookStoreTestContext : DbContext
    {
        public BookStoreTestContext()
        {
        }

        public BookStoreTestContext(DbContextOptions<BookStoreTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioBook> AudioBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Ganre> Ganres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookStoreTest;Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AudioBook>(entity =>
            {
                entity.ToTable("AudioBook");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Announcer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.IdAudioBook, "UQ__Book__9558E7F299CC00E2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookPublisher)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.IsShown)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.SampleFile)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ShortDiscription).IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAudioBookNavigation)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.IdAudioBook)
                    .HasConstraintName("FK__Book__IdAudioBoo__3D5E1FD2");
            });

            modelBuilder.Entity<Ganre>(entity =>
            {
                entity.ToTable("Ganre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GanreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
