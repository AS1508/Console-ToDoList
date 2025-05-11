using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDB.Services;

namespace ToDoDB.UI
{
    public class ConsoleUI
    {
        public static async Task TaskViewer(iTaskServices iTaskServices)
        {
            Console.Clear();
            Console.WriteLine("=== Tabla de Kavan ===");
            Console.WriteLine($"{"ID",-5}{"Nombre",-20}");
            Console.WriteLine(new string('-', 25));

            var tasks = await iTaskServices.GetAllAsync();
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id,-5}{task.Name,-20}{task.StateTask,-10}");
            }
        }
        public static async Task<int> Menu(iTaskServices iTaskServices)
        {
            await TaskViewer(iTaskServices);
            const int MAX_OP = 6;
            int op = -1;

            do
            {
                Console.WriteLine(new string('=', 25));
                Console.WriteLine(
                    "1. Crear nueva tarea\n" +
                    "2. Eliminar tarea\n" +
                    "3. Marcar tarea como completada\n" +
                    "4. Mostrar tareas completadas\n" +
                    "5. Mostrar tareas pendientes\n" +
                    "6. Mostrar tareas en progreso\n" +
                    "0. Salir"
                );
                Console.Write("Seleccione una opción ingresando el número correspondiente:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out op) && op >= 0 && op <= MAX_OP)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Presione cualquier tecla para intentar de nuevo...");
                    Console.ReadKey();
                }

            } while (true);

            return op;
        }
    }
}


