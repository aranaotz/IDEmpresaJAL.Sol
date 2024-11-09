﻿// <auto-generated />
using System;
using IDEmpresaJAL.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IDEmpresaJAL.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240915193434_addUsuariosSeguridad")]
    partial class addUsuariosSeguridad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDireccionGeneral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("EncargadoCargo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EncargadoCorreo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDireccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreEncargado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TieneProgramas")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CDireccionGeneral");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CRecurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContenedorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recurso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlControlador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContenedorId");

                    b.ToTable("CRecurso");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CRecursoContenedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Contenedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CRecursoContenedor");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CRoles");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CTipoSolicitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoSolicitante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CTipoSolicitante");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.RRolRecurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RecursoId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecursoId");

                    b.HasIndex("RolId");

                    b.ToTable("RRolRecurso");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TUsuario");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioGenerales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("DireccionGeneralId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DireccionGeneralId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TUsuarioGenerales");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioSeguridad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TUsuarioSeguridad");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioSeguridadSolicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FechaCaducidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Funcion")
                        .HasColumnType("int");

                    b.Property<string>("Request")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Usada")
                        .HasColumnType("bit");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TUsuarioSeguridadSolicitud");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CRecurso", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CRecursoContenedor", "Contenedor")
                        .WithMany()
                        .HasForeignKey("ContenedorId");

                    b.Navigation("Contenedor");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.RRolRecurso", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CRecurso", "Recurso")
                        .WithMany()
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CRoles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioGenerales", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CDireccionGeneral", "DireccionGeneral")
                        .WithMany()
                        .HasForeignKey("DireccionGeneralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.TUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DireccionGeneral");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioSeguridad", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.TUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TUsuarioSeguridadSolicitud", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.TUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
