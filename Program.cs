using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;
using ToDoDB.Contexts;
using ToDoDB.Data;
using ToDoDB.Objects;
using ToDoDB.Services;
using objTask = ToDoDB.Objects.Task;
using ToDoDB.UI;
using Task = System.Threading.Tasks.Task;

namespace ToDoDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureService(services);
            using var ServiceProvider = services.BuildServiceProvider();
            var taskServices = ServiceProvider.GetRequiredService<iTaskServices>();

            await RunApp(taskServices);
        }

        private static void ConfigureService(ServiceCollection services)
        {
            services.AddDbContext<TDBContext>();
            services.AddScoped<iTaskRepository, TaskRepository>();
            services.AddScoped<iTaskServices, TaskService>();
        }

        private static async Task RunApp(iTaskServices taskServices)
        {
            var op = await ConsoleUI.Menu(taskServices);
            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        await CreateTask(taskServices);
                        break;
                    case 2:
                        await DeleteTask(taskServices);
                        break;
                    case 3:
                        await MarkTaskAsCompleted(taskServices);
                        break;
                    case 4:
                        await MarkTaskAsInProgress(taskServices);
                        break;
                    case 5:
                        await MarkTaskAsPending(taskServices);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                op = await ConsoleUI.Menu(taskServices);
            }
        }

        
        private static async Task CreateTask(iTaskServices taskServices)
        {
            Console.WriteLine("Ingrese el nombre de la tarea:");
            string name = Console.ReadLine();
            Console.WriteLine("Ingrese la descripción de la tarea:");
            string description = Console.ReadLine();
            Console.WriteLine("Ingrese el estado de la tarea (0: Pendiente, 1: En Progreso, 2: Completada):");
            if (int.TryParse(Console.ReadLine(), out int stateInt) && Enum.IsDefined(typeof(States), stateInt))
            {
                States state = (States)stateInt;
                await taskServices.CreateNewTaskAsync(name, description, state);
                Console.WriteLine("Tarea creada exitosamente.");
            }
            else
            {
                Console.WriteLine("Estado inválido.");
            }
            Console.ReadKey();
        }

        private static async Task DeleteTask(iTaskServices taskServices)
        {
            Console.WriteLine("ID de la tarea a eliminar:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Confirmacion(s/n):");
                if (Console.ReadLine().ToLower() == "s")
                {
                    await taskServices.DeleteTaskAsync(id);
                    Console.WriteLine("Tarea eliminada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.ReadKey();
        }

        private static async Task MarkTaskAsCompleted(iTaskServices taskServices)
        {
            Console.WriteLine("ID de la tarea a marcar como completada:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                await taskServices.IsComplete(id);
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.ReadKey();
        }
        private static async Task MarkTaskAsInProgress(iTaskServices taskServices)
        {
            Console.WriteLine("ID de la tarea a marcar como en progreso:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                await taskServices.IsInProgress(id);
                Console.WriteLine("Tarea marcada como en progreso.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.ReadKey();
        }
        private static async Task MarkTaskAsPending(iTaskServices taskServices)
        {
            Console.WriteLine("ID de la tarea a marcar como pendiente:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                await taskServices.IsPending(id);
                Console.WriteLine("Tarea marcada como pendiente.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.ReadKey();
        }



    }
}
