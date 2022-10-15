using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Match = Football_League.Data.Models.Match;

namespace Football_League.Data.Configuration
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(b => b.GuestTeam)
                   .WithMany(b => b.GuestMatches)
                   .HasForeignKey(b => b.GuestTeamId);
        }
    }
}
