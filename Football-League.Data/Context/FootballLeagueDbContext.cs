using Football_League.Data.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Reflection;

namespace Football_League.Data.Context
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configurations = Assembly.GetExecutingAssembly().GetTypes()
                                 .Where(t => t.GetInterfaces()
                                 .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                                 .ToList();

            foreach (var configuration in configurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(configuration);

                builder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(builder);
        }
    }
}
