using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace TriCalcAngular.Models
{
    public class TriathlonRepository : ITriathlonRepository
    {
        private readonly TriathlonContext _context;
        private readonly IMapper _mapper;

        public TriathlonRepository(TriathlonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<FormatDTO> GetFormats()
        {
            var results = _context.Formats;
            return _mapper.Map<IEnumerable<FormatDTO>>(results).ToList();
        }

        public IEnumerable<RaceDTO> GetRaces()
        {
            var mappedFormats = GetFormats();

            var races = _context.Races.Include(rs => rs.Results); //eager loading
            var mappedRaces = _mapper.Map<IEnumerable<RaceDTO>>(races).ToList();
            mappedRaces = (from r in mappedRaces
                           join f in mappedFormats
                           on r.RaceFormatId equals f.FormatId
                           select new RaceDTO
                           {
                               Name = r.Name,
                               RaceId = r.RaceId,
                               Year = r.Year,
                               RaceFormatName = f.Name,
                               RaceFormatId = r.RaceFormatId,
                               ResultsCount = r.ResultsCount
                           }).ToList();
            return mappedRaces;
        }

        public IEnumerable<ResultDTO> GetResultsByRaceId(int raceid)
        {
            var mappedRaces = GetRaces();
            var mappedAthletes = GetAthletes();

            var results = _context.Results.Where(r => r.Result_Race_Id == raceid);
            var mappedResults = _mapper.Map<IEnumerable<ResultDTO>>(results).ToList();
            mappedResults = (from r in mappedResults
                             join ra in mappedRaces
                             on r.ResultRaceId equals ra.RaceId
                             join at in mappedAthletes
                             on r.ResultAthleteId equals at.AthleteId
                             select new ResultDTO
                             {
                                 ResultId = r.ResultId,
                                 ResultRace = new RaceDTO() { Name = ra.Name, RaceFormatName = ra.RaceFormatName, Year = ra.Year},
                                 ResultAthlete = new AthleteDTO { FirstName = at.FirstName, LastName = at.LastName, DOB = at.DOB},
                                 TimeSwim = r.TimeSwim,
                                 TimeT1 = r.TimeT1,
                                 TimeBike = r.TimeBike, 
                                 TimeT2 = r.TimeT2,
                                 TimeRun = r.TimeRun,
                                 TimeTotal = r.TimeTotal
                             }).ToList();


            return mappedResults;
        }

        public int GetResultsCountByRaceId(int raceid)
        {
            return _context.Results.Where(r => r.Result_Race_Id == raceid).Count();
        }

        public IEnumerable<AthleteDTO> GetAthletes()
        {
            var results = _context.Athletes;
            return _mapper.Map<IEnumerable<AthleteDTO>>(results).ToList();
        }

        public int AddRace(RaceDTO raceDTO)
        {
            //var race = new Race() { Race_Format_id = raceDTO.RaceFormatId, Name = raceDTO.Name, Year = raceDTO.Year };
            var race = _mapper.Map<RaceDTO, Race>(raceDTO);
            _context.Races.Add(race);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Races ON");
                    int result = _context.SaveChanges();
                    //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Races OFF");
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    _context.Database.CloseConnection();
                }
            }
            
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
