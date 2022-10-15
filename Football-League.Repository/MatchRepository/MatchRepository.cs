using Football_League.Data.Context;
using Football_League.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Repository.MatchRepository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly FootballLeagueDbContext _context;

        public MatchRepository(FootballLeagueDbContext context)
        {
            _context = context;
        }

        public async Task<Match> CreateAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<Match> UpdateAsync(Match match)
        {
            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return match;
        }

        public async Task DeleteAsync(Match match)
        {
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
        }


        public async Task<Match> GetAsync(int id)
        {
            return await _context.Matches.Include(match => match.HostTeam)
                                         .Include(match => match.GuestTeam)
                                         .FirstOrDefaultAsync(match => match.Id == id);
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _context.Matches.Include(match => match.HostTeam)
                                         .Include(match => match.GuestTeam)
                                         .ToListAsync();
        }
    }
}
