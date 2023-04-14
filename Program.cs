List<string> ListTasks = new List<string>();


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
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

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        // Show current taks
        ShowListTask();

        string readLine = Console.ReadLine();
        // Remove one position
        int indexToRemove = Convert.ToInt32(readLine) - 1;
        if (indexToRemove > (ListTasks.Count - 1) || indexToRemove < 0)
        {
            Console.WriteLine("Número de tarea no valido");
        }
        else
        {
            if (indexToRemove > -1 && ListTasks.Count > 0)
            {
                string nameTask = ListTasks[indexToRemove];
                ListTasks.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {nameTask} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea.");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string nameTask = Console.ReadLine();
        if (string.IsNullOrEmpty(nameTask))
        {
            Console.WriteLine("Debe registrar una tarea con formato valido.");
        }
        else
        {
            ListTasks.Add(nameTask);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al registrar la tarea.");
    }
}

void ShowMenuTaskList()
{
    if (ListTasks?.Count > 0)
    {
        ShowListTask();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}
void ShowListTask()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    ListTasks.ForEach(task => Console.WriteLine($"{++indexTask} . {task}"));
    Console.WriteLine("----------------------------------------");
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
