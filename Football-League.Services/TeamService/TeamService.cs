using Football_League.Data.ApplicationExceptions;
using Football_League.Data.Models;
using Football_League.Data.Util;
using Football_League.Repository.TeamRepository;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> CreateAsync(Team team)
        {
            var teamToBeCreated = await _teamRepository.GetAsync(team.Id);

            if (teamToBeCreated != null)
            {
                throw new EntityNotFoundException(ExceptionMessages.TeamNotFound);
            }

            var newTeam = new Team
            {
                Name = team.Name,
                Points = 0,
                HostMatches = new List<Match>(),
                GuestMatches = new List<Match>()
            };

            return await _teamRepository.CreateAsync(newTeam);
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            return await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _teamRepository.GetAsync(id);

            if (team == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.TeamNotFound);
            }

            await _teamRepository.DeleteAsync(team);
        }

        public async Task<Team> GetAsync(int id)
        {
            var team = await _teamRepository.GetAsync(id);

            if (team == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.TeamNotFound);
            }

            return team;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _teamRepository.GetAllAsync();
        }
    }
}
