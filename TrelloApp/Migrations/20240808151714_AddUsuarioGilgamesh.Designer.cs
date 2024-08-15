﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrelloApp.Models;

#nullable disable

namespace TrelloApp.Migrations
{
    [DbContext(typeof(TrelloContext))]
    [Migration("20240808151714_AddUsuarioGilgamesh")]
    partial class AddUsuarioGilgamesh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrelloApp.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableroId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TableroId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("TrelloApp.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Empleado"
                        });
                });

            modelBuilder.Entity("TrelloApp.Models.RolesUsuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("RolesUsuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            RolId = 1
                        });
                });

            modelBuilder.Entity("TrelloApp.Models.Tablero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tableros");
                });

            modelBuilder.Entity("TrelloApp.Models.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("TrelloApp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Name = "Auron",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Hefestinho@gmail.com",
                            Name = "Hefesto",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Snapero@gmail.com",
                            Name = "Gilgamesh",
                            Password = "snap"
                        });
                });

            modelBuilder.Entity("TrelloApp.Models.Estado", b =>
                {
                    b.HasOne("TrelloApp.Models.Tablero", "Tablero")
                        .WithMany("Estado")
                        .HasForeignKey("TableroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tablero");
                });

            modelBuilder.Entity("TrelloApp.Models.RolesUsuarios", b =>
                {
                    b.HasOne("TrelloApp.Models.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrelloApp.Models.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TrelloApp.Models.Tablero", b =>
                {
                    b.HasOne("TrelloApp.Models.Usuario", "Usuario")
                        .WithMany("Tableros")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TrelloApp.Models.Tarjeta", b =>
                {
                    b.HasOne("TrelloApp.Models.Estado", "Estado")
                        .WithMany("Tarjeta")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TrelloApp.Models.Estado", b =>
                {
                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("TrelloApp.Models.Rol", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("TrelloApp.Models.Tablero", b =>
                {
                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TrelloApp.Models.Usuario", b =>
                {
                    b.Navigation("RolesUsuarios");

                    b.Navigation("Tableros");
                });
#pragma warning restore 612, 618
        }
    }
}
