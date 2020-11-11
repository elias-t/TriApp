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


namespace server.Models
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
                               ResultsCount = r.ResultsCount,
                               DistanceSwim = f.DistanceSwim,
                               DistanceBike = f.DistanceBike,
                               DistanceRun = f.DistanceRun,
                           }).ToList();
            return mappedRaces;
        }

        public IEnumerable<string> GetDistinctRaces()
        {
            var races = _context.Races.Select(r => r.Name).Distinct();
            return races;
        }

        public IEnumerable<ResultDTO> GetResultsByRaceId(int raceid)
        {
            var mappedRaces = GetRaces();
            var mappedAthletes = GetAthletes();
            var mappedFormats = GetFormats();
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
                                 ResultRace = new RaceDTO() { Name = ra.Name, RaceFormatName = ra.RaceFormatName, Year = ra.Year,
                                     DistanceSwim = ra.DistanceSwim, DistanceBike = ra.DistanceBike, DistanceRun = ra.DistanceRun },
                                 ResultAthlete = new AthleteDTO { FirstName = at.FirstName, LastName = at.LastName, DOB = at.DOB},
                                 TimeSwimStr = string.Format("{0:hh\\:mm\\:ss}", r.TimeSwim),
                                 TimeT1Str = string.Format("{0:hh\\:mm\\:ss}", r.TimeT1),
                                 TimeBikeStr = string.Format("{0:hh\\:mm\\:ss}", r.TimeBike), 
                                 TimeT2Str = string.Format("{0:hh\\:mm\\:ss}", r.TimeT2),
                                 TimeRunStr = string.Format("{0:hh\\:mm\\:ss}", r.TimeRun),
                                 TimeTotalStr = string.Format("{0:hh\\:mm\\:ss}", r.TimeTotal),
                                 City = r.City,
                                 Team = r.Team, 
                                 Bib = r.Bib,
                             }).OrderBy(rlts => rlts.TimeTotal).ToList();


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

        public IEnumerable<AthleteDTO> GetAthletesForRace(int raceid)
        {
            var results = (from at in _context.Athletes
                           join re in _context.Results
                           on at.Athlete_id equals re.Result_Athlete_Id
                           select new { at.Athlete_id, at.FirstName, at.LastName, at.DOB, re.Result_Athlete_Id } into att
                           where att.Result_Athlete_Id != raceid
                           group att by new { att.Athlete_id, att.FirstName, att.LastName, att.DOB} into g
                           select new Athlete
                           {
                                   Athlete_id = g.Key.Athlete_id,
                                   FirstName = g.Key.FirstName,
                                   LastName = g.Key.LastName,
                                   DOB = g.Key.DOB,
                           }).ToList();
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

        public int UpdateRace(RaceDTO raceDTO)
        {
            var currentRace = _context.Races.SingleOrDefault(r => r.Race_id == raceDTO.RaceId);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    currentRace.Name = raceDTO.Name;
                    currentRace.Race_Format_id = raceDTO.RaceFormatId;
                    currentRace.Year = raceDTO.Year;
                    int result = _context.SaveChanges();
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

        public int DeleteRace(int raceid)
        {
            var currentRace = _context.Races.SingleOrDefault(r => r.Race_id == raceid);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Races.Remove(currentRace);
                    int result = _context.SaveChanges();
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

        public int AddAthlete(AthleteDTO athleteDTO)
        {
            var athlete = _mapper.Map<AthleteDTO, Athlete>(athleteDTO);
            _context.Athletes.Add(athlete);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int result = _context.SaveChanges();
                    transaction.Commit();
                    int newAthleteId = (int)athlete.Athlete_id;
                    return newAthleteId;
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

        public int AddAthleteToRace(int athleteId, int raceId, string city, string team, string bib)
        {
            var res = new Result() { Result_Race_Id = raceId, Result_Athlete_Id = athleteId, City = city, Bib = (bib == null) ? (int?)null : int.Parse(bib), Team = team };

            _context.Results.Add(res);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int result = _context.SaveChanges();
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

        public int UpdateResult(ResultDTO resultDTO)
        {
            var currentResult = _context.Results.SingleOrDefault(r => r.Result_Id == resultDTO.ResultId);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //edit first name, last name on separate query
                    currentResult.Time_Swim = TimeSpan.Parse(resultDTO.TimeSwimStr);
                    currentResult.Time_T1 = TimeSpan.Parse(resultDTO.TimeT1Str);
                    currentResult.Time_Bike = TimeSpan.Parse(resultDTO.TimeBikeStr);
                    currentResult.Time_T2 = TimeSpan.Parse(resultDTO.TimeT2Str);
                    currentResult.Time_Run = TimeSpan.Parse(resultDTO.TimeRunStr);
                    currentResult.Time_Total = TimeSpan.Parse(resultDTO.TimeTotalStr);
                    int result = _context.SaveChanges();
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

        public int DeleteResult(int resultid)
        {
            var currentResult = _context.Results.SingleOrDefault(r => r.Result_Id == resultid);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Results.Remove(currentResult);
                    int result = _context.SaveChanges();
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
