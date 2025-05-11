using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoDB.Objects;
using objTask = ToDoDB.Objects.Task;
using Task = System.Threading.Tasks.Task;

namespace ToDoDB.Services
{
    public interface iTaskServices
    {
        objTask GetTarea(int id);
        Task<IEnumerable<objTask>> GetAllAsync();
        Task CreateNewTaskAsync(string name, string description, States state);
        Task IsComplete(int id);
        Task IsInProgress(int id);
        Task IsPending(int id)
        Task DeleteTaskAsync(int id);
    }
}
