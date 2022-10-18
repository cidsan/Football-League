using Football_League.Data.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Services.MatchService
{
    public interface IMatchService
    {
        Task<Match> CreateAsync(Match match);

        Task<Match> StartMatchAsync(Match match);

        Task DeleteAsync(int id);

        Task<Match> GetAsync(int id);

        Task<IEnumerable<Match>> GetAllAsync();
    }
}
