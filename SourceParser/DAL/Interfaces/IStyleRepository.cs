﻿using SourceParser.DAL.Entities.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Interfaces
{
    public interface IStyleRepository : IBaseRepository<Style>
    {
        Task<List<Text>> GetAllTexts();
    }
}
