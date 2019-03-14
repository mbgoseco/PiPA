﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiPA.Data;

namespace PiPA.Migrations
{
    [DbContext(typeof(PADbcontext))]
    [Migration("20190314191654_deploy")]
    partial class deploy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PiPA.Models.Lists", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ListName");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("ListsTable");
                });

            modelBuilder.Entity("PiPA.Models.Tasks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompletedDate");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("ListID");

                    b.Property<int?>("ListsID");

                    b.Property<DateTime>("PlannedDateComplete");

                    b.Property<string>("TaskName");

                    b.HasKey("ID");

                    b.HasIndex("ListsID");

                    b.ToTable("TasksTable");
                });

            modelBuilder.Entity("PiPA.Models.Tasks", b =>
                {
                    b.HasOne("PiPA.Models.Lists")
                        .WithMany("TaskList")
                        .HasForeignKey("ListsID");
                });
#pragma warning restore 612, 618
        }
    }
}
