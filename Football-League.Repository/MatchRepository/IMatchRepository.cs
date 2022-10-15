using Football_League.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Repository.MatchRepository
{
    public interface IMatchRepository
    {
        Task<Match> CreateAsync(Match match);

        Task<Match> UpdateAsync(Match match);

        Task DeleteAsync(Match match);

        Task<Match> GetAsync(int id);

        Task<IEnumerable<Match>> GetAllAsync();
    }
}
