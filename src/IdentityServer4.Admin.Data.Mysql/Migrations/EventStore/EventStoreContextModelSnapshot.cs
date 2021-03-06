﻿// <auto-generated />
using System;
using IdentityServer4.Admin.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityServer4.Admin.Data.Mysql.Migrations.EventStore
{
    [DbContext(typeof(EventStoreContext))]
    partial class EventStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IdentityServer4.Admin.Domain.Core.Events.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggregateId");

                    b.Property<string>("Data");

                    b.Property<string>("MessageType")
                        .HasColumnName("Action")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("CreationDate");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("StoredEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
