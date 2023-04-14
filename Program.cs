using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> ListTasks { get; set; }

        static void Main(string[] args)
        {
            ListTasks = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if (menuSelected == 1)
                {
                    ShowMenuAdd();
                }
                else if (menuSelected == 2)
                {
                    ShowMenuRemove();
                }
                else if (menuSelected == 3)
                {
                    ShowMenuTaskList();
                }
            } while (menuSelected != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string readLine = Console.ReadLine();
            return Convert.ToInt32(readLine);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < ListTasks.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ListTasks[i]);
                }
                Console.WriteLine("----------------------------------------");

                string readLine = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(readLine) - 1;
                if (indexToRemove > -1)
                {
                    if (ListTasks.Count > 0)
                    {
                        string nameTask = ListTasks[indexToRemove];
                        ListTasks.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + nameTask + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string nameTask = Console.ReadLine();
                ListTasks.Add(nameTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (ListTasks == null || ListTasks.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < ListTasks.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ListTasks[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
