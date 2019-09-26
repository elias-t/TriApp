﻿using System;
using System.Collections.Generic;

namespace TriCalcAngular.Models
{
    public interface ITriathlonRepository : IDisposable
    {
        IEnumerable<FormatDTO> GetFormats();
        IEnumerable<RaceDTO> GetRaces();
        IEnumerable<ResultDTO> GetResultsByRaceId(int raceid);
        int GetResultsCountByRaceId(int raceid);
    }
}