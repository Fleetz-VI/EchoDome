﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class Faction
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
