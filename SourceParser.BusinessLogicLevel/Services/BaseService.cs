using SourceParser.DataAccessLevel.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.BusinessLogicLevel.Services
{
    public class BaseService
    {
        protected readonly IBaseUnitOfWork _database;

        public BaseService(IBaseUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
    }
}
