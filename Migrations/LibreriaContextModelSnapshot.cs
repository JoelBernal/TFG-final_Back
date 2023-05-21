﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_librerias_paco.Context;

#nullable disable

namespace api_librerias_paco.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    partial class LibreriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api_librerias_paco.Models.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CantidadProductos")
                        .HasColumnType("int");

                    b.Property<bool?>("EstadoCarrito")
                        .HasColumnType("bit");

                    b.Property<string>("MetodosPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PrecioTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdadRecomendada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contrasenya")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Empleados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Residencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Libros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EnVenta")
                        .HasColumnType("bit");

                    b.Property<string>("FechaPublicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Paginas")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("api_librerias_paco.Models.LibrosClientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("Idlibro")
                        .HasColumnType("int");

                    b.Property<int?>("LibroId")
                        .HasColumnType("int");

                    b.Property<string>("NombreLibro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LibroId");

                    b.ToTable("LibrosClientes");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Tiendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Codigopostal")
                        .HasColumnType("int");

                    b.Property<string>("Comunidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioAtencion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibroId")
                        .HasColumnType("int");

                    b.Property<int?>("LibrosId")
                        .HasColumnType("int");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Trabajadores")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibrosId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("api_librerias_paco.Models.LibrosClientes", b =>
                {
                    b.HasOne("api_librerias_paco.Models.Clientes", "Cliente")
                        .WithMany("LibrosClientes")
                        .HasForeignKey("ClienteId");

                    b.HasOne("api_librerias_paco.Models.Libros", "Libro")
                        .WithMany("LibrosClientes")
                        .HasForeignKey("LibroId");

                    b.Navigation("Cliente");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Tiendas", b =>
                {
                    b.HasOne("api_librerias_paco.Models.Libros", "Libros")
                        .WithMany("Tiendas")
                        .HasForeignKey("LibrosId");

                    b.Navigation("Libros");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Clientes", b =>
                {
                    b.Navigation("LibrosClientes");
                });

            modelBuilder.Entity("api_librerias_paco.Models.Libros", b =>
                {
                    b.Navigation("LibrosClientes");

                    b.Navigation("Tiendas");
                });
#pragma warning restore 612, 618
        }
    }
}
