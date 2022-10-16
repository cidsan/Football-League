using Match = Football_League.Data.Models.Match;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football_League.Data.Configuration
{
    public class HostConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(b => b.HostTeam)
                   .WithMany(b => b.HostMatches)
                   .HasForeignKey(b => b.HostTeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
