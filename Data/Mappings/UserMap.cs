using CadMais.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadMais.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users");

    builder.HasKey( x => x.Id );

    builder.Property( x => x.Id )
      .ValueGeneratedOnAdd()
      .UseIdentityColumn();

    builder.Property( x => x.Name )
      .IsRequired()
      .HasColumnType("NVARCHAR")
      .HasMaxLength(128);

    builder.Property( x => x.Email )
      .IsRequired()
      .HasColumnType("NVARCHAR")
      .HasMaxLength(128);

    builder.Property( x => x.Password )
      .IsRequired()
      .HasColumnType("NVARCHAR")
      .HasMaxLength(256);
    
    builder.Property( x => x.Phone )
      .IsRequired()
      .HasColumnType("VARCHAR")
      .HasMaxLength(15);
    
    builder.Property( x => x.CPF )
      .IsRequired()
      .HasColumnType("VARCHAR")
      .HasMaxLength(11);

    builder.Property( x => x.CreatedAt )
      .IsRequired()
      .HasColumnType("SMALLDATETIME")
      .HasDefaultValueSql("GETDATE()");

    builder.Property( x => x.UpdatedAt )
      .IsRequired()
      .HasColumnType("SMALLDATETIME")
      .HasDefaultValueSql("GETDATE()");

    builder.HasMany( x => x.Address );
  }
}