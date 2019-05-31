﻿// <auto-generated />
using System;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PrimeraApiNetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Calendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Calendarios");
                });

            modelBuilder.Entity("DAL.Models.CalendarioUsuario", b =>
                {
                    b.Property<int>("CalendarioId");

                    b.Property<int>("UsuarioId");

                    b.Property<bool>("Propietario");

                    b.HasKey("CalendarioId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CalendariosUsuarios");
                });

            modelBuilder.Entity("DAL.Models.Planificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarioId");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("TipoPlanificacion")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CalendarioId");

                    b.ToTable("Planificaciones");
                });

            modelBuilder.Entity("DAL.Models.PlanificacionReceta", b =>
                {
                    b.Property<int>("RecetaId");

                    b.Property<int>("PlanificacionId");

                    b.HasKey("RecetaId", "PlanificacionId");

                    b.HasIndex("PlanificacionId");

                    b.ToTable("PlanificacionReceta");
                });

            modelBuilder.Entity("DAL.Models.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(10);

                    b.Property<int>("Puntuacion");

                    b.HasKey("Id");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("DAL.Models.RecetaUsuario", b =>
                {
                    b.Property<int>("RecetaId");

                    b.Property<int>("UsuarioId");

                    b.Property<bool>("Propietario");

                    b.HasKey("RecetaId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RecetasUsuarios");
                });

            modelBuilder.Entity("DAL.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<string>("Apellidos")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DAL.Models.CalendarioUsuario", b =>
                {
                    b.HasOne("DAL.Models.Calendario", "Calendario")
                        .WithMany("CalendariosUsuarios")
                        .HasForeignKey("CalendarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Usuario", "Usuario")
                        .WithMany("CalendariosUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Planificacion", b =>
                {
                    b.HasOne("DAL.Models.Calendario", "Calendario")
                        .WithMany("Planificaciones")
                        .HasForeignKey("CalendarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.PlanificacionReceta", b =>
                {
                    b.HasOne("DAL.Models.Planificacion", "Planificacion")
                        .WithMany("PlanificacionesRecetas")
                        .HasForeignKey("PlanificacionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Receta", "Receta")
                        .WithMany("PlanificacionesRecetas")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.RecetaUsuario", b =>
                {
                    b.HasOne("DAL.Models.Receta", "Receta")
                        .WithMany("RecetasUsuarios")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Usuario", "Usuario")
                        .WithMany("RecetasUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
