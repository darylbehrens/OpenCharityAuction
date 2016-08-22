using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenCharityAuction.Web.Data;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20160822212113_AddedAdmissionTickets")]
    partial class AddedAdmissionTickets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AdmissionTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost")
                        .IsRequired();

                    b.Property<int>("EventId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("AdmissionTickets");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AdmissionTicket", b =>
                {
                    b.HasOne("OpenCharityAuction.Entities.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
