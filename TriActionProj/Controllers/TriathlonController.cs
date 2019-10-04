using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //// GET: api/Results/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetResults([FromRoute] decimal id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var results = await _context.Results.FindAsync(id);

        //    if (results == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(results);
        //}



        //// PUT: api/Results/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutResults([FromRoute] decimal id, [FromBody] Results results)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != results.ResultId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(results).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ResultsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Results
        //[HttpPost]
        //public async Task<IActionResult> PostResults([FromBody] Results results)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Results.Add(results);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ResultsExists(results.ResultId))
        //        {
        //            return new StatusCodeResult(StatusCodes.Status409Conflict);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetResults", new { id = results.ResultId }, results);
        //}

        //// DELETE: api/Results/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteResults([FromRoute] decimal id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var results = await _context.Results.FindAsync(id);
        //    if (results == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Results.Remove(results);
        //    await _context.SaveChangesAsync();

        //    return Ok(results);
        //}

        //private bool ResultsExists(decimal id)
        //{
        //    return _context.Results.Any(e => e.ResultId == id);
        //}
    }
}