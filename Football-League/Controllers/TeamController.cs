using Football_League.Data.Models;
using Football_League.Services.TeamService;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam (int id)
        {
            return Ok(await _teamService.GetAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams()
        {
            return Ok(await _teamService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            return Ok(await _teamService.CreateAsync(team));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteAsync(id);
            return Ok();
        }
    }
}
