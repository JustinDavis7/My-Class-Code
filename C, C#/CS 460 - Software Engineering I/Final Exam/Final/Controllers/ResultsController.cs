using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;
using System;

namespace Final.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IRepository<MatchResult> _matchResultRepository;
        private readonly ICountryRepository _countryRepository;

        public ResultsController(IRepository<MatchResult> matchResultRepository, ICountryRepository countryRepository)
        {
            _matchResultRepository = matchResultRepository;
            _countryRepository = countryRepository;
        }

        // GET: api/results/ARG
        [HttpGet("{countryAbbreviation}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ResultsDTO> GetResults(string countryAbbreviation)
        {
            Country? c = _countryRepository.CountryExists(countryAbbreviation);

            if (c == null)
            {
                return NotFound();
            }

            ResultsDTO results = new ResultsDTO
            {
                Wins = _countryRepository.CurrentWins(c.Id),
                Losses = _countryRepository.CurrentLosses(c.Id),
                Draws = _countryRepository.CurrentDraws(c.Id)
            };

            return Ok(results);
        }
    }
}

