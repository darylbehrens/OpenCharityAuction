using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenCharityAuction.Web.Data;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20160912233852_AddAtendee")]
    partial class AddAtendee
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

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<int>("EventId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("AdmissionTickets");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdmissionTicketId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("MealId");

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AttendeeAdmissionTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdmissionTicketId");

                    b.Property<int>("BidderId");

                    b.HasKey("Id");

                    b.HasIndex("AdmissionTicketId");

                    b.HasIndex("BidderId");

                    b.ToTable("BidderAdmissionTickets");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AttendeeMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BidderId");

                    b.Property<int>("MealId");

                    b.HasKey("Id");

                    b.HasIndex("BidderId");

                    b.HasIndex("MealId");

                    b.ToTable("BidderMeals");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.BidderGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PrimaryPhone");

                    b.Property<string>("SecondaryPhone");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Bidders");
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

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<int>("EventId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AdmissionTicket", b =>
                {
                    b.HasOne("OpenCharityAuction.Entities.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AttendeeAdmissionTicket", b =>
                {
                    b.HasOne("OpenCharityAuction.Entities.Models.AdmissionTicket", "AdmissionTicket")
                        .WithMany()
                        .HasForeignKey("AdmissionTicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenCharityAuction.Entities.Models.BidderGroup", "Bidder")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.AttendeeMeal", b =>
                {
                    b.HasOne("OpenCharityAuction.Entities.Models.BidderGroup", "Bidder")
                        .WithMany()
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenCharityAuction.Entities.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.Meal", b =>
                {
                    b.HasOne("OpenCharityAuction.Entities.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
