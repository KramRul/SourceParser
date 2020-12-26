using Microsoft.EntityFrameworkCore;
using SourceParser.DataAccessLevel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.DataAccessLevel.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository()
        {
        }

        public async Task<List<T>> GetAll()
        {
            var result = new List<T>();
            using (var context = new ApplicationContext())
            {
                result = await context.Set<T>().ToListAsync();
            }
            return result;
        }

        public async Task<T> Get(Guid id)
        {
            using (var context = new ApplicationContext())
            {
                var result = await context.Set<T>().FindAsync(id);
                return result;
            }
        }

        public async Task Create(T item)
        {
            using (var context = new ApplicationContext())
            {
                await context.Set<T>().AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Create(List<T> items)
        {
            using (var context = new ApplicationContext())
            {
                await context.Set<T>().AddRangeAsync(items);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T item)
        {
            using (var context = new ApplicationContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.Set<T>().Update(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(List<T> items)
        {
            using (var context = new ApplicationContext())
            {
                context.Set<T>().UpdateRange(items);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T item)
        {
            using (var context = new ApplicationContext())
            {
                context.Set<T>().Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> Count()
        {
            using (var context = new ApplicationContext())
            {
                var result = await context.Set<T>().CountAsync();
                return result;
            }
        }
    }
}
