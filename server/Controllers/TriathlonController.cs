using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriathlonController : Controller
    {
        private readonly ITriathlonRepository _model;

        public TriathlonController(ITriathlonRepository model)
        {
            _model = model;
        }

        [HttpGet("GetFormats")]
        public IEnumerable<FormatDTO> GetFormats()
        {

            return _model.GetFormats();
        }

        [HttpGet("GetRaces")]
        public IEnumerable<RaceDTO> GetRaces()
        {
            return _model.GetRaces();
        }

        [HttpGet("GetAthletes")]
        public IEnumerable<AthleteDTO> GetAthletes()
        {
            return _model.GetAthletes();
        }


        [HttpGet("GetAthletesForRace/{raceid}")]
        public IEnumerable<AthleteDTO> GetAthletesForRace(int raceid)
        {
            return _model.GetAthletesForRace(raceid);
        }

        [HttpGet("GetDistinctRaces")]
        public IEnumerable<string> GetDistinctRaces()
        {
            return _model.GetDistinctRaces();
        }

        [HttpGet("GetResultsByRaceId/{raceid}")]
        public IEnumerable<ResultDTO> GetResultsByRaceId(int raceid)
        {
            return _model.GetResultsByRaceId(raceid);
        }

        [HttpGet("GetResultsCountByRaceId/{raceid}")]
        public int GetResultsCountByRaceId(int raceid)
        {
            return _model.GetResultsCountByRaceId(raceid);
        }

        [HttpPost("AddRace")]
        public ActionResult AddRace([FromBody] RaceDTO race)
        {
            try
            {
                _model.AddRace(race);
                return CreatedAtAction("New race added", race);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPost("UpdateRace")]
        public ActionResult UpdateRace([FromBody] RaceDTO race)
        {
            try
            {
                _model.UpdateRace(race);
                return CreatedAtAction("Existing race updated", race);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete("DeleteRace/{raceid}")]
        public ActionResult DeleteRace(int raceid)
        {
            try
            {
                _model.DeleteRace(raceid);
                return CreatedAtAction("Existing race updated", raceid);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPost("AddAthlete/{raceid}/{city?}/{team?}/{bib?}")]
        public ActionResult AddAthlete([FromBody] AthleteDTO athlete, int raceId, string city, string team, string bib)
        {
            try
            {
                var athleteId = athlete.AthleteId;
                if (athlete.AthleteId == 0)
                    athleteId = _model.AddAthlete(athlete);
                //add athlete to race, i.e. add result
                _model.AddAthleteToRace(athleteId, raceId, city, team, bib);
                return CreatedAtAction("New athlete added", athlete);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("UpdateResult")]
        public ActionResult UpdateResult([FromBody] ResultDTO result)
        {
            try
            {
                _model.UpdateResult(result);
                return CreatedAtAction("Existing result updated", result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete("DeleteResult/{resultid}")]
        public ActionResult DeleteResult(int resultid)
        {
            try
            {
                _model.DeleteResult(resultid);
                return CreatedAtAction("Existing result deleted", resultid);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}