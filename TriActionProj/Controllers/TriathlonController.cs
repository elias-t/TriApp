using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriCalcAngular.Models;

namespace TriCalcAngular.Controllers
{
    //[Route("api/[controller]")]
    public class TriathlonController : Controller
    {
        //npm install --save-dev webpack
        //npm install --save-dev webpack-dev-middleware

        private readonly ITriathlonRepository _model;

        public TriathlonController(ITriathlonRepository model)
        {
            _model = model;
        }

        // GET: api/Results
        [Route("api/Triathlon/GetFormats")]
        [HttpGet("[action]")]
        public IEnumerable<FormatDTO> GetFormats()
        {

            return _model.GetFormats();
        }

        [Route("api/Triathlon/GetRaces")]
        [HttpGet("[action]")]
        public IEnumerable<RaceDTO> GetRaces()
        {
            return _model.GetRaces();
        }

        [Route("api/Triathlon/GetAthletes")]
        [HttpGet("[action]")]

        public IEnumerable<AthleteDTO> GetAthletes()
        {
            return _model.GetAthletes();
        }

        [Route("api/Triathlon/GetAthletesForRace/{raceid}")]
        [HttpGet("[action]")]
        public IEnumerable<AthleteDTO> GetAthletesForRace(int raceid)
        {
            return _model.GetAthletesForRace(raceid);
        }

        [Route("api/Triathlon/GetDistinctRaces")]
        [HttpGet("[action]")]
        public IEnumerable<string> GetDistinctRaces()
        {
            return _model.GetDistinctRaces();
        }

        //[Route("/api/Triathlon/GetResultsByRaceId/{raceid}")]
        [HttpGet("api/Triathlon/GetResultsByRaceId/{raceid}")]
        public IEnumerable<ResultDTO> GetResultsByRaceId(int raceid)
        {
            return _model.GetResultsByRaceId(raceid);
        }

        [HttpGet("api/Triathlon/GetResultsCountByRaceId/{raceid}")]
        public int GetResultsCountByRaceId(int raceid)
        {
            return _model.GetResultsCountByRaceId(raceid);
        }
        
        [HttpPost("api/Triathlon/AddRace")]
        public ActionResult AddRace([FromBody]RaceDTO race)
        {
            try
            {
                _model.AddRace(race);
                return CreatedAtAction("New race added" , race);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpPost("api/Triathlon/UpdateRace")]
        public ActionResult UpdateRace([FromBody]RaceDTO race)
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

        [HttpDelete("api/Triathlon/DeleteRace/{raceid}")]
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

        [HttpPost("api/Triathlon/AddAthlete/{raceid}/{city?}/{team?}/{bib?}")]
        public ActionResult AddAthlete([FromBody]AthleteDTO athlete, int raceId, string city, string team, string bib)
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

        [HttpPost("api/Triathlon/UpdateResult")]
        public ActionResult UpdateResult([FromBody]ResultDTO result)
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

        [HttpDelete("api/Triathlon/DeleteResult/{resultid}")]
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