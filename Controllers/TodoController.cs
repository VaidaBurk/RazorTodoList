using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorToDoList.Models;
using RazorToDoList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorToDoList.Controllers
{
    public class TodoController : Controller
    {
        private JsonFileService _jsonFileService;
        public TodoController()
        {
            _jsonFileService = new JsonFileService();
        }
        public IActionResult Index()
        {
            return View("AddNewTodo");
        }

        public IActionResult AddNewTodo(TodoModel todoModel)
        {
            //if(!System.IO.File.Exists("Todos.json")) 
            //{
            //    System.IO.File.WriteAllText("Todos.json", "[]");
            //}
            //string readTodos = System.IO.File.ReadAllText("Todos.json");
            //List<TodoModel> receivedTodos = JsonConvert.DeserializeObject<List<TodoModel>>(readTodos);
            
            List<TodoModel> receivedTodos = _jsonFileService.GetItemsFromFile();
            
            if (receivedTodos == null)
            {
                receivedTodos = new();
            }
            receivedTodos.Add(todoModel);

            //readTodos = JsonConvert.SerializeObject(receivedTodos);
            //System.IO.File.WriteAllText("Todos.json", readTodos);

            _jsonFileService.WriteItemsToFile(receivedTodos);

            ModelState.Clear();
            return RedirectToAction("ShowAllTodos");
        }
        public IActionResult ShowAllTodos()
        {
            //string readTodo = System.IO.File.ReadAllText("Todos.json");
            //List<TodoModel> receivedTodos = JsonConvert.DeserializeObject<List<TodoModel>>(readTodo);

            List<TodoModel> receivedTodos = _jsonFileService.GetItemsFromFile();

            return View("ShowAllTodos", receivedTodos);
        }
        public IActionResult FinishTodo(string id)
        {
            //string readTodos = System.IO.File.ReadAllText("Todos.json");
            //List<TodoModel> receivedTodos = JsonConvert.DeserializeObject<List<TodoModel>>(readTodos);

            List<TodoModel> receivedTodos = _jsonFileService.GetItemsFromFile();

            TodoModel selectedTodo = receivedTodos.FirstOrDefault(i => i.Id == id);
            selectedTodo.IsFinished = !selectedTodo.IsFinished;

            //readTodos = JsonConvert.SerializeObject(receivedTodos);
            //System.IO.File.WriteAllText("Todos.json", readTodos);

            _jsonFileService.WriteItemsToFile(receivedTodos);

            return Ok();
        }
    }
}
