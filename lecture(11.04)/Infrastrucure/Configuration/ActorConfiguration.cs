using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastrucure.Configuration;
internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        // Привязываемся к таблице
        // Задаем какое свйоство будет являтся PrimaryKey
        builder.ToTable(nameof(Actor))
              .HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired();

        // datetime2
        builder.Property(a => a.DateOfBirth)
                .IsRequired();

        builder.Ignore(a => a.FullName);
    }
}
