using System;
using System.Collections.Generic;

namespace server.Models
{
    public partial class AthleteDTO
    {
        public AthleteDTO()
        {
            Results = new HashSet<ResultDTO>();
        }

        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public ICollection<ResultDTO> Results { get; set; }
    }
}
