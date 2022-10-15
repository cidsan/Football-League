using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Models
{
    public class Team
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public string Rank { get; set; }

        public ICollection<Match> HostMatches { get; set; }

        public ICollection<Match> GuestMatches { get; set; }
    }
}
