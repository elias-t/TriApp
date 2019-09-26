using System;
using System.Collections.Generic;

namespace TriCalcAngular.Models
{
    public partial class ResultDTO
    {
        public decimal ResultId { get; set; }
        public decimal ResultRaceId { get; set; }
        public decimal ResultAthleteId { get; set; }
        public TimeSpan? TimeSwim { get; set; }
        public TimeSpan? TimeT1 { get; set; }
        public TimeSpan? TimeBike { get; set; }
        public TimeSpan? TimeT2 { get; set; }
        public TimeSpan? TimeRun { get; set; }
        public TimeSpan? TimeTotal { get; set; }
        public AthleteDTO ResultAthlete { get; set; }
        public RaceDTO ResultRace { get; set; }
        
    }
}
