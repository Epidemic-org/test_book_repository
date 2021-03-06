// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_book_repository_webapi.Models;

namespace test_book_repository_webapi.Migrations
{
    [DbContext(typeof(BookStoreTestContext))]
    partial class BookStoreTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test_book_repository_webapi.Models.AudioBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announcer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("AudioBook");
                });

            modelBuilder.Entity("test_book_repository_webapi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BookPublisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int?>("IdAudioBook")
                        .HasColumnType("int");

                    b.Property<int>("IdGanre")
                        .HasColumnType("int");

                    b.Property<byte[]>("IsShown")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("binary(2)")
                        .IsFixedLength(true);

                    b.Property<string>("SampleFile")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ShortDiscription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdAudioBook" }, "UQ__Book__9558E7F299CC00E2")
                        .IsUnique()
                        .HasFilter("[IdAudioBook] IS NOT NULL");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("test_book_repository_webapi.Models.Ganre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GanreName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ganre");
                });

            modelBuilder.Entity("test_book_repository_webapi.Models.Book", b =>
                {
                    b.HasOne("test_book_repository_webapi.Models.AudioBook", "IdAudioBookNavigation")
                        .WithOne("Book")
                        .HasForeignKey("test_book_repository_webapi.Models.Book", "IdAudioBook")
                        .HasConstraintName("FK__Book__IdAudioBoo__3D5E1FD2");

                    b.Navigation("IdAudioBookNavigation");
                });

            modelBuilder.Entity("test_book_repository_webapi.Models.AudioBook", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
