﻿using SourceParser.DAL.Entities;
using SourceParser.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DAL.Repositories
{
    public class Co_AuthorRepository : BaseRepository<Co_Author>, ICo_AuthorRepository
    {
        public Co_AuthorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
