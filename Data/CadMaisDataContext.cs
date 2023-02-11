using CadMais.Data.Mappings;
using CadMais.Models;
using Microsoft.EntityFrameworkCore;

namespace CadMais.Data;

public class CadMaisDataContext : DbContext
{
  public DbSet<User> User { get; set;}
  public DbSet<Address> Address { get; set;}

  public CadMaisDataContext(DbContextOptions<CadMaisDataContext> options) : base(options)
  {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration( new UserMap() );
    modelBuilder.ApplyConfiguration( new AddressMap() );

  }
}