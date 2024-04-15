using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastrucure.Configuration;
internal class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        // Привязываемся к таблице
        // Задаем какое свйоство будет являтся PrimaryKey
        builder.ToTable(nameof(Theater))
              .HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Address)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.OpenningDate)
            .IsRequired();

        builder.HasMany(a => a.Plays)
            .WithOne()
            .HasForeignKey(a => a.TheaterId);
    }
}
