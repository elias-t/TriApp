using System;
using System.Collections.Generic;

namespace TriCalcAngular.Models
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

        public ICollection<RaceDTO> Races { get; set; }
        public ICollection<ResultDTO> Results { get; set; }
    }
}
