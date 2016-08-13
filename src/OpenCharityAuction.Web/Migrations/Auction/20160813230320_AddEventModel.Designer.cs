using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenCharityAuction.Web.Data;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20160813230320_AddEventModel")]
    partial class AddEventModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenCharityAuction.Entities.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventName");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });
        }
    }
}
