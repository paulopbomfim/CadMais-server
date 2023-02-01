using CadMais.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadMais.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
  public void Configure(EntityTypeBuilder<Address> builder)
  {
    builder.ToTable("Addresses");

    builder.HasKey( x => x.Id );

    builder.Property( x => x.Id )
      .ValueGeneratedOnAdd()
      .UseIdentityColumn();

    builder.Property( x => x.Location )
      .IsRequired()
      .HasColumnType("NVARCHAR")
      .HasMaxLength(256);

  }
}