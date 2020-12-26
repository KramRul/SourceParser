using SourceParser.DataAccessLevel.Entities.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Interfaces
{
    public interface IStyleRepository : IBaseRepository<Style>
    {
        Task<List<Text>> GetAllTexts();
        Task Update(Style item, string id);
    }
}
