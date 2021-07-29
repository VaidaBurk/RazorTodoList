using RazorToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorToDoList.Services
{
    public class TodoService
    {
        private JsonFileService _jsonFileService;
        public TodoService()
        {
            _jsonFileService = new JsonFileService();
        }
        public void FinishTodo(TodoModel todoItem, string id)
        {
            //string readTodos = System.IO.File.ReadAllText("Todos.json");
            //List<TodoModel> receivedTodos = JsonConvert.DeserializeObject<List<TodoModel>>(readTodos);

            List<TodoModel> receivedTodos = _jsonFileService.GetItemsFromFile();

            TodoModel selectedTodo = receivedTodos.FirstOrDefault(i => i.Id == id);
            selectedTodo.IsFinished = !selectedTodo.IsFinished;

            //readTodos = JsonConvert.SerializeObject(receivedTodos);
            //System.IO.File.WriteAllText("Todos.json", readTodos);

            _jsonFileService.WriteItemsToFile(receivedTodos);
        }
    }
}
