using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using objTask = ToDoDB.Objects.Task;

namespace ToDoDB.Data
{
    internal interface iTaskRepository
    {
        Task<objTask> GetByIdAsync(int id);
        Task<IEnumerable<objTask>> GetAllAsync();
        Task AddAsync(objTask task);
        Task DeleteAsync(objTask task);
        void Update(objTask task);
        Task SaveChangeAsync();

    }
}
