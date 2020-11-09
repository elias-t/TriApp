using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class ResultDTO
    {
        public int ResultId { get; set; }
        public int ResultRaceId { get; set; }
        public int ResultAthleteId { get; set; }
        public TimeSpan? TimeSwim { get; set; }
        public TimeSpan? TimeT1 { get; set; }
        public TimeSpan? TimeBike { get; set; }
        public TimeSpan? TimeT2 { get; set; }
        public TimeSpan? TimeRun { get; set; }
        public TimeSpan? TimeTotal { get; set; }

        public string TimeSwimStr { get; set; }
        public string TimeT1Str { get; set; }
        public string TimeBikeStr { get; set; }
        public string TimeT2Str { get; set; }
        public string TimeRunStr { get; set; }
        public string TimeTotalStr { get; set; }

        public AthleteDTO ResultAthlete { get; set; }
        public RaceDTO ResultRace { get; set; }
        public string City { get; set; }
        public string Team { get; set; }
        public int Bib { get; set; }
    }
}
