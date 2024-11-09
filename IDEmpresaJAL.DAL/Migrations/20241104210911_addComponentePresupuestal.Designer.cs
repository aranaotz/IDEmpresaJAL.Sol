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
    [Migration("20241104210911_addComponentePresupuestal")]
    partial class addComponentePresupuestal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CBanca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Banca")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("CBanca");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("DireccionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("EmpleadosMax")
                        .HasColumnType("int");

                    b.Property<int?>("EmpleadosMin")
                        .HasColumnType("int");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneEmpleados")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("CCategorias");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA_TipoSolicitantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoSolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoSolicitanteId");

                    b.ToTable("CCategoriasTipoSolicitante");
                });

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

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<Guid>("DireccionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nacional")
                        .HasColumnType("bit");

                    b.Property<bool>("Obligoatorio")
                        .HasColumnType("bit");

                    b.Property<int>("TipoCargaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.HasIndex("TipoCargaId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("CDocumentos");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentosRequisitos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<Guid>("DocumentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisito")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.ToTable("CDocumentosRequisitos");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentosTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CDocumentosTipo");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentosTipoCarga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MensajeDescripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MensajeValidacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TipoCarga")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ValidationExpression")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CDocumentosTipoCarga");
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

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CSistemas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("DescripcionImagen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MensajeVisible")
                        .HasColumnType("bit");

                    b.Property<string>("RutaImagen")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Session")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sistema")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TamanoImagen")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("CSistemas");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CTipoPrograma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("TipoPrograma")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CTipoPrograma");
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

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.RUsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RUsuarioRol");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TProgramas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anio")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.Property<string>("CLABE")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClavePresupuestaria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClaveProgramaPresupuestal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CodigoDenominacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DescripcionPartida")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("DireccionGeneralId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaFin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Numcuenta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ObjetivoGeneral")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<bool>("PermiteMultiplesConvocatorias")
                        .HasColumnType("bit");

                    b.Property<bool>("PermiteMultiplesProyectos")
                        .HasColumnType("bit");

                    b.Property<decimal>("Presupuesto")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoProgramaId")
                        .HasColumnType("int");

                    b.Property<bool>("VoBoArea")
                        .HasColumnType("bit");

                    b.Property<bool>("VoBoPlaneacion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BancaId");

                    b.HasIndex("DireccionGeneralId");

                    b.HasIndex("SistemaId");

                    b.HasIndex("TipoProgramaId");

                    b.ToTable("TProgramas");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TProgramasComponente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Componente")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("MontoDisponible")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Partida")
                        .IsRequired()
                        .HasMaxLength(46)
                        .HasColumnType("nvarchar(46)");

                    b.Property<Guid>("ProgramaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProgramaId");

                    b.ToTable("TProgramaComponentes");
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
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

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

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CDireccionGeneral", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA_TipoSolicitantes", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CCategoriasApoyoSIGA", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CTipoSolicitante", "TipoSolicitante")
                        .WithMany()
                        .HasForeignKey("TipoSolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("TipoSolicitante");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentos", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CDireccionGeneral", "DireccionGeneral")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CDocumentosTipoCarga", "TipoCarga")
                        .WithMany()
                        .HasForeignKey("TipoCargaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CDocumentosTipo", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DireccionGeneral");

                    b.Navigation("TipoCarga");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.CDocumentosRequisitos", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CDocumentos", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documento");
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

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.RUsuarioRol", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CRoles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.TUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TProgramas", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.CBanca", "Banca")
                        .WithMany()
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CDireccionGeneral", "DireccionGeneral")
                        .WithMany()
                        .HasForeignKey("DireccionGeneralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CSistemas", "Sistema")
                        .WithMany()
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDEmpresaJAL.Entity.Models.CTipoPrograma", "TipoPrograma")
                        .WithMany()
                        .HasForeignKey("TipoProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banca");

                    b.Navigation("DireccionGeneral");

                    b.Navigation("Sistema");

                    b.Navigation("TipoPrograma");
                });

            modelBuilder.Entity("IDEmpresaJAL.Entity.Models.TProgramasComponente", b =>
                {
                    b.HasOne("IDEmpresaJAL.Entity.Models.TProgramas", "Programa")
                        .WithMany()
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programa");
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
