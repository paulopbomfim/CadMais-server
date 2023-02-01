using CadMais.Data.Mappings;
using CadMais.Models;
using Microsoft.EntityFrameworkCore;

namespace CadMais.Data;

public class CadMaisDataContext : DbContext
{
  public DbSet<User> User { get; set;}
  public DbSet<Address> Address { get; set;}

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlServer("Server=localhost,1433;TrustServerCertificate=True;Database=CadMais;User ID=sa;Password=Password12!");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration( new UserMap() );
    modelBuilder.ApplyConfiguration( new AddressMap() );

  }
}