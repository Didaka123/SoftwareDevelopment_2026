using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dido3009ToDoManager
{
    internal class Program
    {

            
            static TodoService service = new TodoService();

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("======= TODO MANAGER ========");
                    Console.WriteLine("1. Добави задача");
                    Console.WriteLine("2. Покажи задачи");
                    Console.WriteLine("3. Маркирай задача като изпълнена");
                    Console.WriteLine("4. Изтрий задача");
                    Console.WriteLine("5. Изход");

                    Console.WriteLine();
                    Console.Write("Избор: ");
                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1": { AddTodo(); break; }
                            case "2": { ListAllTodos(); break; }
                            case "3": { CompleteTodo(); break; }
                            case "4": { DeleteTodo(); break; }
                            case "5": { Console.WriteLine("Край на програмата"); Console.ReadLine(); return; }
                            default: { Console.WriteLine("Невалиден избор."); break; }
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
            }

            private static void DeleteTodo()
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("=====  Изтрий задача =======\n");
                ListAllTodos();

                Console.Write("Избери Id: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Невалидно id.");
                    Console.Write("Избери Id: ");
                }

                service.Delete(id);

                
                Console.WriteLine("Задачата е изтрита.");

            }

            private static void CompleteTodo()
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("=====  Маркирай задача като завършена =======\n");
                ListAllTodos();

                Console.Write("Избери Id: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Невалидно id.");
                    Console.Write("Избери Id: ");
                }

                service.Complete(id);

                Console.WriteLine("Задачата е завършена.");


            }

            private static void ListAllTodos()
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("===== Всички задачи  =======");

                var todos = service.GetAll();
                if (todos.Count == 0)
                {
                    Console.WriteLine("Няма въведени задачи");
                }
                else
                {
                    foreach (TodoItem todoItem in todos)
                    {
                        Console.WriteLine($"{todoItem}");
                    }
                }
            }

            

            private static void AddTodo()
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("=====  Добавяне на задача =======");

                Console.Write("Заглавие:");
                string title = Console.ReadLine();

                Console.Write("Описание:");
                string description = Console.ReadLine();

                Console.Write("Краен срок:");
                DateTime dueDate;
                while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                {
                    Console.WriteLine("Невалидна дата.Въведи отово!");
                    Console.Write("Краен срок: ");
                }
                service.Add(title, description, dueDate);
                Console.WriteLine("Задачата е добавена.");

            }
            //    public int Id { get; set; }
            //    public string Title
            //    {
            //        get
            //        {
            //            return Title;
            //        }
            //        set
            //        {
            //            if (string.IsNullOrEmpty(Title))
            //                throw new ArgumentNullException("Заглавието е задължително");
            //        }
            //    }

            //    public string Description { get; set; }
            //    public DateTime DueDate { get; set; }
            //    public bool IsCompleted { get; set; }

            //    public ToDoItem(int id, string title, string description, DateTime dueDate)
            //    {
            //        if (id <= 0)
            //           throw new ArgumentOutOfRangeException("Id трябва да е положително число");

            //        if(string.IsNullOrEmpty(title))
            //           throw new ArgumentNullException("Заглавието е задължително");

            //        Id = id;
            //        Title = title;
            //        Description = description;
            //        DueDate = dueDate;
            //        IsCompleted = false;
            //    }
            //}




            //    private static List<ToDoItem> tasks = new List<ToDoItem>();
            //    private static int nextId = 1;
            //    static void Main(string[] args)
            //    {
            //        Console.WriteLine("promqna");
            //        while (true)
            //        {
            //            Console.Clear();
            //            Console.WriteLine("===== УПРАВЛЕНИЕ НА ЗАДАЧИ =====");
            //            Console.WriteLine("1. Добави нова задача");
            //            Console.WriteLine("2. Покажи всички задачи");
            //            Console.WriteLine("3. Маркирай задача като изпълнена");
            //            Console.WriteLine("4. Изтрий задача");
            //            Console.WriteLine("5. Изход");
            //            Console.WriteLine("===============================");
            //            Console.Write("Избери опция: ");

            //            string choice = Console.ReadLine();

            //            switch (choice)
            //            {
            //                case "1":
            //                    AddTask();
            //                    break;

            //                case "2":
            //                    ShowTasks();
            //                    break;

            //                case "3":
            //                    CompleteTask();
            //                    break;

            //                case "4":
            //                    DeleteTask();
            //                    break;

            //                case "5":
            //                    Console.WriteLine("Програмата приключва...");
            //                    return;

            //                default:
            //                    Console.WriteLine("Невалидна опция!");
            //                    Pause();
            //                    break;
            //            }
            //        }
            //    }

            //    static void AddTask()
            //    {
            //        Console.Clear();
            //        Console.WriteLine("===== ДОБАВЯНЕ НА ЗАДАЧА =====");

            //        Console.Write("Заглавие: ");
            //        string title = Console.ReadLine();

            //        Console.Write("Описание: ");
            //        string description = Console.ReadLine();

            //        DateTime dueDate;

            //        while (true)
            //        {
            //            Console.Write("Краен срок (дд.ММ.гггг): ");

            //            if (DateTime.TryParse(Console.ReadLine(), out dueDate))
            //            {
            //                break;
            //            }

            //            Console.WriteLine("Невалидна дата! Опитайте отново.");
            //        }

            //    try
            //    {
            //        ToDoItem task = new ToDoItem(nextId, title, description, dueDate);
            //        tasks.Add(task);
            //        nextId++;
            //    }
            //    catch (ArgumentOutOfRangeException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    catch (ArgumentNullException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //        Console.WriteLine("\nЗадачата беше добавена успешно!");
            //        Pause();
            //    }

            //    static void ShowTasks()
            //    {
            //        Console.Clear();
            //        Console.WriteLine("===== ВСИЧКИ ЗАДАЧИ =====");

            //        if (tasks.Count == 0)
            //        {
            //            Console.WriteLine("Няма въведени задачи.");
            //            Pause();
            //            return;
            //        }

            //        for (int i = 0; i < tasks.Count; i++)
            //        {
            //            ToDoItem task = tasks[i];

            //            Console.WriteLine($"\nЗадача #{i + 1}");
            //            Console.WriteLine($"Заглавие: {task.Title}");
            //            Console.WriteLine($"Описание: {task.Description}");
            //            Console.WriteLine($"Краен срок: {task.DueDate:dd.MM.yyyy}");
            //            Console.WriteLine($"Статус: {(task.IsCompleted ? "Изпълнена" : "Неизпълнена")}");
            //            Console.ForegroundColor = ConsoleColor.White;

            //        }

            //        Pause();
            //    }

            //    static void CompleteTask()
            //    {
            //        Console.Clear();
            //        Console.WriteLine("===== МАРКИРАНЕ КАТО ИЗПЪЛНЕНА =====");

            //        if (tasks.Count == 0)
            //        {
            //            Console.WriteLine("Няма въведени задачи.");
            //            Pause();
            //            return;
            //        }

            //        ShowTaskTitles();

            //        Console.Write("Въведи номер на задачата: ");

            //        if (int.TryParse(Console.ReadLine(), out int number) &&
            //            number >= 1 && number <= tasks.Count)
            //        {
            //            tasks[number - 1].IsCompleted = true;
            //            Console.WriteLine("Задачата е маркирана като изпълнена.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Невалиден номер на задача.");
            //        }

            //        Pause();
            //    }

            //    static void DeleteTask()
            //    {
            //        Console.Clear();
            //        Console.WriteLine("===== ИЗТРИВАНЕ НА ЗАДАЧА =====");

            //        if (tasks.Count == 0)
            //        {
            //            Console.WriteLine("Няма въведени задачи.");
            //            Pause();
            //            return;
            //        }

            //        ShowTaskTitles();

            //        Console.Write("Въведи номер на задачата за изтриване: ");

            //        if (int.TryParse(Console.ReadLine(), out int number) &&
            //            number >= 1 && number <= tasks.Count)
            //        {
            //            tasks.RemoveAt(number - 1);
            //            Console.WriteLine("Задачата беше изтрита.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Невалиден номер на задача.");
            //        }

            //        Pause();
            //    }

            //    static void ShowTaskTitles()
            //    {
            //        for (int i = 0; i < tasks.Count; i++)
            //        {
            //            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
            //        }
            //    }

            //    static void Pause()
            //    {
            //        Console.WriteLine("\nНатиснете Enter за продължаване...");
            //        Console.ReadLine();
            //    }

        
    }
}

      
