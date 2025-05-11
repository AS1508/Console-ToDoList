using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDB.Objects
{
    public enum States { pending, inProgress, Done }
    public class Task
    {
        private int id;
        private string? name;
        private string? description;
        private States stateTask;
        private DateTime dataCreated = DateTime.Now;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Description { get => description; set => description = value; }
        public States StateTask { get => stateTask; set => stateTask = value; }
        public DateTime DataCreated { get => dataCreated; set => dataCreated = value; }

        public Task() { }
        public Task(string name, string descrip, States state)
        {
            //Id = deberia Setear algun tipo de id
            Name = name;
            Description = descrip;
            StateTask = (States)state;
            DataCreated = DateTime.Now;
        }

    }
}
