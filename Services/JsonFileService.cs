using Newtonsoft.Json;
using RazorToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorToDoList.Services
{
    public class JsonFileService
    {
        private const string DATA_URL = "Todos.json";
        public List<TodoModel> GetItemsFromFile()
        {
            if (!System.IO.File.Exists(DATA_URL))
            {
                System.IO.File.WriteAllText(DATA_URL, "[]");
            }

            string readTodos = System.IO.File.ReadAllText(DATA_URL);
            return JsonConvert.DeserializeObject<List<TodoModel>>(readTodos);
        }

        public void WriteItemsToFile(List<TodoModel> items)
        {
            string readTodos = JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText(DATA_URL, readTodos);
        }
    }
}
