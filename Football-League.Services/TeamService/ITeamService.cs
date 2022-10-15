using Football_League.Data.Models;

using System.Threading.Tasks;

namespace Football_League.Services.TeamService
{
    public  interface ITeamService
    {
        Task<Team> CreateAsync(Team team);

        Task<Team> UpdateAsync(Team team);

        Task DeleteAsync(int id);

        Task<Team> GetAsync(Team team);
    }
}
