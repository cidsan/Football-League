using Football_League.Data.ApplicationExceptions;
using Football_League.Data.Models;
using Football_League.Data.Util;
using Football_League.Repository.MatchRepository;
using Football_League.Services.TeamService;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Services.MatchService
{
    public class MatchService : IMatchService
    {
        private readonly ITeamService _teamService;
        private readonly IMatchRepository _matchRepository;

        public MatchService(ITeamService teamService, IMatchRepository matchRepository)
        {
            _teamService = teamService;
            _matchRepository = matchRepository;
        }

        public async Task<Match> CreateAsync(Match match)
        {
            var hostTeam = await _teamService.GetAsync(match.HostTeamId);
            var guestTeam = await _teamService.GetAsync(match.GuestTeamId);

            ValidateTeam(hostTeam, guestTeam);

            var matchToBeAdded = new Match()
            {
                HostTeamId = hostTeam.Id,
                GuestTeamId = guestTeam.Id,
                Winner = match.HostTeamId == match.WinnerId ? hostTeam.Name : guestTeam.Name
            };

            await _matchRepository.CreateAsync(matchToBeAdded);

            return matchToBeAdded;
        }

        public async Task DeleteAsync(int id)
        {
            var matchToBeDeleted = await _matchRepository.GetAsync(id);

            RemovePoints(matchToBeDeleted);

            await _teamService.UpdateAsync(matchToBeDeleted.HostTeam);
            await _teamService.UpdateAsync(matchToBeDeleted.GuestTeam);
            await _matchRepository.DeleteAsync(matchToBeDeleted);
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _matchRepository.GetAllAsync();
        }

        public async Task<Match> GetAsync(int id)
        {
            var match = await _matchRepository.GetAsync(id);

            if (match == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.MatchNotFound);
            }

            return match;
        }

        public async Task<Match> StartMatchAsync(Match match)
        {
            var matchPlayed = await _matchRepository.GetAsync(match.Id);

            CalculateMatchScore(matchPlayed);

            await _teamService.UpdateAsync(matchPlayed.HostTeam);
            await _teamService.UpdateAsync(matchPlayed.GuestTeam);
            await _matchRepository.UpdateAsync(matchPlayed);

            return matchPlayed;
        }

        private void ValidateTeam(Team hostTeam, Team guestTeam)
        {
            if (hostTeam == null || guestTeam == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.TeamNotFound);
            }
        }

        private void CalculateMatchScore(Match match)
        {
            if (match.HostTeamId == match.WinnerId && !match.isDraw)
            {
                match.HostTeam.Points += 3;
            }
            else if (match.GuestTeamId == match.WinnerId && !match.isDraw)
            {
                match.GuestTeam.Points += 3;
            }
            else if (match.isDraw)
            {
                match.HostTeam.Points += 1;
                match.GuestTeam.Points += 1;
            }
        }

        private void RemovePoints(Match match)
        {
            if (match.HostTeamId == match.WinnerId && !match.isDraw)
            {
                match.HostTeam.Points -= 3;
            }
            else if (match.GuestTeamId == match.WinnerId && !match.isDraw)
            {
                match.GuestTeam.Points -= 3;
            }
            else if (match.isDraw)
            {
                match.HostTeam.Points -= 1;
                match.GuestTeam.Points -= 1;
            }
        }
    }
}
