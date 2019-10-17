using System;
using System.Collections.Generic;

namespace TriCalcAngular.Models
{
    public interface ITriathlonRepository : IDisposable
    {
        IEnumerable<FormatDTO> GetFormats();
        IEnumerable<RaceDTO> GetRaces();
        IEnumerable<ResultDTO> GetResultsByRaceId(int raceid);
        int GetResultsCountByRaceId(int raceid);
        int AddRace(RaceDTO race);

        int UpdateRace(RaceDTO race);

        int DeleteRace(int raceid);
        IEnumerable<string> GetDistinctRaces();
        int AddAthlete(AthleteDTO athlete);
    }
}
