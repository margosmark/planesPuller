using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using planesPuller;

namespace planesPuller.Migrations
{
    [DbContext(typeof(planeContext))]
    partial class planeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("planesPuller.planeInfo", b =>
                {
                    b.Property<int>("planeInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("aircraftId");

                    b.Property<bool>("alert");

                    b.Property<int?>("altitude");

                    b.Property<string>("callSign");

                    b.Property<bool>("emergency");

                    b.Property<string>("flightId");

                    b.Property<string>("generatedDate");

                    b.Property<string>("generatedTime");

                    b.Property<int?>("groundSpeed");

                    b.Property<string>("hexIdent");

                    b.Property<bool>("isOnGround");

                    b.Property<float?>("lat");

                    b.Property<string>("loggedDate");

                    b.Property<string>("loggedTime");

                    b.Property<float?>("lon");

                    b.Property<int>("messageType");

                    b.Property<string>("sessionId");

                    b.Property<bool>("spi");

                    b.Property<string>("squawk");

                    b.Property<int?>("track");

                    b.Property<int>("transmissiontype");

                    b.Property<int?>("verticalRate");

                    b.HasKey("planeInfoId");
                });
        }
    }
}
