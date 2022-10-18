using Match = Football_League.Data.Models.Match;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football_League.Data.Configuration
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)

        {
            builder.HasOne(b => b.GuestTeam)
                   .WithMany(b => b.GuestMatches)
                   .HasForeignKey(b => b.GuestTeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
