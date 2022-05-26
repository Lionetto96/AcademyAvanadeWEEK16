using AgenziaConsulenzaAMM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);
            builder
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(20);
            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Role)
                .IsRequired();

            builder.HasData(new User
            {
               
                Id = 1,
                Username = "martina.tiso",
                Password = "Academy2022",
                Role = Role.Administrator


            });

            builder.HasData(new User
            {
                Id = 2,
                Username = "alessia.lionetto",
                Password = "novembre2022",
                Role = Role.Administrator


            });

            builder.HasData(new User
            {
                Id = 3,
                Username = "maria.de.stefano",
                Password = "forGirls2022",
                Role = Role.Administrator


            });

            builder.HasData(new User
            {
                Id = 4,
                Username = "diego.angelino",
                Password = "Pippo123",
                Role = Role.User


            });
        
        }
    }
}
