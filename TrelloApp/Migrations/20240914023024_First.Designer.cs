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
    [Migration("20240914023024_First")]
    partial class First
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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TableroId");

                    b.HasIndex("UsuarioId");

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

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrador",
                            created_at = new DateTime(2024, 9, 13, 21, 30, 24, 113, DateTimeKind.Local).AddTicks(1646)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Premium",
                            created_at = new DateTime(2024, 9, 13, 21, 30, 24, 113, DateTimeKind.Local).AddTicks(1662)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Estandar",
                            created_at = new DateTime(2024, 9, 13, 21, 30, 24, 113, DateTimeKind.Local).AddTicks(1663)
                        },
                        new
                        {
                            Id = 4,
                            Description = "Empleado",
                            created_at = new DateTime(2024, 9, 13, 21, 30, 24, 113, DateTimeKind.Local).AddTicks(1665)
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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("UsuarioId");

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

                    b.Property<DateTime?>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Name = "Admin",
                            Password = "administradortrelloapp"
                        });
                });

            modelBuilder.Entity("TrelloApp.Models.Estado", b =>
                {
                    b.HasOne("TrelloApp.Models.Tablero", "Tablero")
                        .WithMany("Estados")
                        .HasForeignKey("TableroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrelloApp.Models.Usuario", "Usuario")
                        .WithMany("Estados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tablero");

                    b.Navigation("Usuario");
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
                        .WithMany("Tarjetas")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrelloApp.Models.Usuario", "Usuario")
                        .WithMany("Tarjetas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TrelloApp.Models.Estado", b =>
                {
                    b.Navigation("Tarjetas");
                });

            modelBuilder.Entity("TrelloApp.Models.Rol", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("TrelloApp.Models.Tablero", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("TrelloApp.Models.Usuario", b =>
                {
                    b.Navigation("Estados");

                    b.Navigation("RolesUsuarios");

                    b.Navigation("Tableros");

                    b.Navigation("Tarjetas");
                });
#pragma warning restore 612, 618
        }
    }
}
