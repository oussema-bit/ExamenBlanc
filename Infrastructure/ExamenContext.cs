using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Domain;
using Infrastructure.Configurations;

namespace Infrastructure
{

    public class ExamenContext:DbContext
    {
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Artiste> Artists { get; set; }

        public DbSet<Concert> Concertes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=OussamaTestDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>()
                .HasMany(f => f.Artists)
                .WithMany(a => a.Festivals)
                .UsingEntity<Concert>(
                    l=> l.HasOne<Artiste>().WithMany().HasForeignKey(c=>c.ArtisteFK),
                    r=>r.HasOne<Festival>().WithMany().HasForeignKey(c=>c.FestivalFK)
                );
            modelBuilder.ApplyConfiguration(new ConcertConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }

    }
}
