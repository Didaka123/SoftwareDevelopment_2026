using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dido3009ToDoManager
{
    internal class TodoService
    {
        private readonly static List<TodoItem> todos = new List<TodoItem>();
        private static int nextId = 1;

        public List<TodoItem> GetAll()
        {
            return todos;
        }

        public TodoItem FindById(int id)
        {
            TodoItem targetTodo = null;
            foreach (TodoItem todoItem in todos)
            {
                if (todoItem.Id == id)
                {
                    return todoItem;
                }

            }
            return null;
        }


        public void Add(string title, string description, DateTime dueDate)
        {
            TodoItem todoItem = new TodoItem(nextId, title, description, dueDate);
            todos.Add(todoItem);
            nextId++;
        }

        public void Complete(int id)
        {
            TodoItem completedTask = FindById(id);

            if (completedTask == null)
                throw new ArgumentException("Няма задача с такова id.");

            completedTask.Completed();

            
        }

        public void Delete(int id)
        {
            TodoItem deleteTask = FindById(id);
            if (deleteTask == null)
            throw new ArgumentException("Няма задача с такова id.");
            
            todos.Remove(deleteTask);
        }
    } 
}
