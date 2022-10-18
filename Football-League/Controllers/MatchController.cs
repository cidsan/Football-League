using Football_League.Data.Models;
using Football_League.Services.MatchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            return Ok(await _matchService.GetAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetAllMatches()
        {
            return Ok(await _matchService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch(Match match)
        {
            return Ok(await _matchService.CreateAsync(match));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Match>> StartMatch(Match match)
        {
            return Ok(await _matchService.StartMatchAsync(match));
        }
    }
}
