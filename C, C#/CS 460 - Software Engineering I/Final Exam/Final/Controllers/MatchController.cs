using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;
using System;

namespace Final.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IRepository<MatchResult> _matchResultRepository;
        private readonly IRepository<Country> _countryRepository;

        public MatchController(IRepository<MatchResult> matchResultRepository, IRepository<Country> countryRepository)
        {
            _matchResultRepository = matchResultRepository;
            _countryRepository = countryRepository;
        }

        // GET: api/match/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MatchResultDTO> GetMatchResult(int id)
        {
            MatchResult mr = _matchResultRepository.FindById(id);

            if (mr == null)
            {
                return NotFound();
            }

            MatchResultDTO result = new MatchResultDTO();
            result.FromMatchResult(mr);
            return Ok(result);
        }

        // POST: api/match
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MatchResultDTO> PostMatchResult([Bind("FullTime,HomeTeamId,AwayTeamId,HomeTeamGoals,AwayTeamGoals")] MatchResultDTO matchResult)
        {
            if(!_countryRepository.Exists(matchResult.HomeTeamId) ||
               !_countryRepository.Exists(matchResult.AwayTeamId))
            {
                return BadRequest(new { Error = "One of these teams does not exist" });
            }
            if (matchResult.HomeTeamId == matchResult.AwayTeamId)
            {
                return BadRequest(new { Error = "A team cannot play itself." });
            }
            if (matchResult.HomeTeamGoals < 0 || matchResult.AwayTeamGoals < 0)
            {
                return BadRequest(new { Error = "The number of goals scored cannot be negative." });
            }
            MatchResult mr = matchResult.ToMatchResult();
            try
            {
                mr = _matchResultRepository.AddOrUpdate(mr);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Something went wrong when adding this match result to the database" });
            }
            MatchResultDTO result = new MatchResultDTO();
            result.FromMatchResult(mr);
            return CreatedAtAction("GetMatchResult", "MatchResultDTO", result);
        }
    }
}
