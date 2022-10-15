using Football_League.Data.Context;
using Football_League.Data.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Repository.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballLeagueDbContext _context;

        public TeamRepository(FootballLeagueDbContext context)
        {
            _context = context;
        }
        public async Task<Team> CreateAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task DeleteAsync(Team team)
        {
            _context.Remove(team);
            await _context.SaveChangesAsync();
        }

        public async Task<Team> GetAsync(int id)
        {
            return await _context.Teams.Include(team => team.HostMatches)
                                       .Include(team => team.HostMatches)
                                       .FirstOrDefaultAsync(team => team.Id == id);
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }
    }
}
