using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using ToDoDB.Contexts;
using ToDoDB.Objects;

using Task = System.Threading.Tasks.Task;
using objTask = ToDoDB.Objects.Task;

namespace ToDoDB.Data
{
    internal class TaskRepository : iTaskRepository
    {

        private readonly TDBContext _dbContext;
        public TaskRepository(TDBContext dbContext) => _dbContext = dbContext;

        public async Task AddAsync(objTask task)
        {
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(objTask task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<objTask>> GetAllAsync() => await _dbContext.Tasks.ToListAsync();

        public async Task<objTask> GetByIdAsync(int id) => await _dbContext.Tasks.FindAsync(id);
        public async Task SaveChangeAsync() => await _dbContext.SaveChangesAsync();

        public void Update(objTask task) => _dbContext.Tasks.Update(task);
    }
}
