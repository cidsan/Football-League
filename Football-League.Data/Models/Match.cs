﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int HostTeamId { get; set; }

        public int GuestTeamId { get; set; }

        public string Result { get; set; } 

        public Team HostTeam { get; set; }

        public Team GuestTeam { get; set; }

        public string Winner { get; set; }
    }
}
