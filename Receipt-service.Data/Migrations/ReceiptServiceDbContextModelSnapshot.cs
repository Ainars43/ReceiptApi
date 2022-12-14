// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Receipt_service.Data;

namespace Receipt_service.Data.Migrations
{
    [DbContext(typeof(ReceiptServiceDbContext))]
    partial class ReceiptServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Receipt_service.Core.Models.Item", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ProductName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("ReceiptId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ReceiptId");

                b.ToTable("Items");
            });

            modelBuilder.Entity("Receipt_service.Core.Models.Receipt", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("CreatedOn")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Receipts");
            });

            modelBuilder.Entity("Receipt_service.Core.Models.Item", b =>
            {
                b.HasOne("Receipt_service.Core.Models.Receipt", null)
                    .WithMany("ReceiptItems")
                    .HasForeignKey("ReceiptId");
            });

            modelBuilder.Entity("Receipt_service.Core.Models.Receipt", b =>
            {
                b.Navigation("ReceiptItems");
            });
#pragma warning restore 612, 618
        }
    }
}