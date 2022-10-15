using Football_League.Data.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Repository.TeamRepository
{
    public interface ITeamRepository
    {
        Task<Team> CreateAsync(Team team);

        Task<Team> UpdateAsync(Team team);

        Task DeleteAsync(Team team);

        Task<Team> GetAsync(int id);

        Task<IEnumerable<Team>> GetAllAsync();
    }
}
