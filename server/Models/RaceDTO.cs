using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class RaceDTO
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public int RaceFormatId { get; set; }
        public int Year { get; set; }
        public string RaceFormatName { get; set; }
        public int ResultsCount { get; set; }


        public decimal DistanceSwim { get; set; }
        public decimal DistanceBike { get; set; }
        public decimal DistanceRun { get; set; }
    }
}
