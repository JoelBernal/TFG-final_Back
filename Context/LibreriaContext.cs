using Microsoft.EntityFrameworkCore;
using api_librerias_paco.Models;

namespace api_librerias_paco.Context
{

    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
           : base(options)
        {
        }
        public DbSet<Libros> Libro { get; set; } = null!;
        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Tiendas> Tiendas { get; set; } = null!;
        public DbSet<LibrosClientes> LibrosClientes { get; set; } = null!;
        public DbSet<Empleados> Empleados { get; set; } = null!;
        public DbSet<Carrito> Carrito { get; set; } = null!;
        public DbSet<Categorias> Categorias { get; set; } = null!;



         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(@"Server=tcp:apitfgfinal.database.windows.net,1433;Initial Catalog=BbddApiTfgFinal;Persist Security Info=False;User ID=TfgFinalJoelEnrique;Password=Mandangon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
         }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tiendas>()
            .HasMany(t => t.Empleados)
            .WithOne(e => e.Tienda)
            .HasForeignKey(e => e.TiendaId);

            modelBuilder.Entity<Libros>()
                .HasOne(l => l.Categorias)
                .WithMany(c => c.Libros)
                .HasForeignKey(l => l.CategoriaId);

            modelBuilder.Entity<LibrosClientes>()
           .HasKey(lc => new { lc.Id });

            //conexion tabla intermedia y libros
            modelBuilder.Entity<LibrosClientes>()
        .HasOne(lc => lc.Libro)
        .WithMany(l => l.LibrosClientes);
            //.HasForeignKey(lc => lc.Idlibro);

            //conexion tabla intermedia y clientes
            modelBuilder.Entity<LibrosClientes>()
           .HasOne(lc => lc.Cliente)
           .WithMany(c => c.LibrosClientes);
            // .HasForeignKey(lc => lc.IdCliente);


        }

    }
}