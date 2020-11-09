using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class FormatDTO
    {
        public FormatDTO()
        {
            Races = new HashSet<RaceDTO>();
            Results = new HashSet<ResultDTO>();
        }

        public int FormatId { get; set; }
        public string Name { get; set; }

        public decimal DistanceSwim { get; set; }
        public decimal DistanceBike { get; set; }
        public decimal DistanceRun { get; set; }


        public ICollection<RaceDTO> Races { get; set; }
        public ICollection<ResultDTO> Results { get; set; }
    }
}
