﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}