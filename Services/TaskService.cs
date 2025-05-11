using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = System.Threading.Tasks.Task;
using System.Threading.Tasks.Dataflow;
using ToDoDB.Data;
using ToDoDB.Objects;
using objTask = ToDoDB.Objects.Task;

namespace ToDoDB.Services
{
    internal class TaskService : iTaskServices
    {
        private readonly iTaskRepository _task;
        public TaskService(iTaskRepository taskRepository) => _task = taskRepository;

        public async Task CreateNewTaskAsync(string name, string description, States state)
        {
            objTask t = new objTask(name, description, state);
            await _task.AddAsync(t);
            _task.SaveChangeAsync();

        }

        public async Task DeleteTaskAsync(int id)
        {
            objTask task = await _task.GetByIdAsync(id);
            if (task != null)
            {
                await _task.DeleteAsync(task);
                _task.SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<objTask>> GetAllAsync()
        {
            return await _task.GetAllAsync();
        }

        public objTask GetTarea(int id)
        {
            throw new NotImplementedException();
        }

        public async Task IsComplete(int id)
        {
            objTask temp = await _task.GetByIdAsync(id);

            if (temp.StateTask != States.Done)
            {
                _task.GetByIdAsync(id).Result.StateTask = States.Done;
                _task.Update(temp);
                _task.SaveChangeAsync();
            }       
        }
        public async Task IsInProgress(int id)
        {
            objTask temp = await _task.GetByIdAsync(id);

            if (temp.StateTask != States.inProgress)
            {
                _task.GetByIdAsync(id).Result.StateTask = States.inProgress;
                _task.Update(temp);
                _task.SaveChangeAsync();
            }
        }
        public async Task IsPending(int id)
        {
            objTask temp = await _task.GetByIdAsync(id);

            if (temp.StateTask != States.pending)
            {
                _task.GetByIdAsync(id).Result.StateTask = States.pending;
                _task.Update(temp);
                _task.SaveChangeAsync();
            }
        }
    }
}
