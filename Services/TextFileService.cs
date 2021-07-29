using Newtonsoft.Json;
using RazorToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorToDoList.Services
{
    public class TextFileService
    {
        private const string DATA_URL = "Todos.json";
        public List<TodoModel> GetItemsFromFile()
        {
            if (!System.IO.File.Exists(DATA_URL))
            {
                System.IO.File.WriteAllText(DATA_URL, "[]");
            }

            List<TodoModel> items = new();

            //string readTodos = System.IO.File.ReadAllText(DATA_URL);
            //return JsonConvert.DeserializeObject<List<TodoModel>>(readTodos);

            System.IO.File.ReadAllLines(DATA_URL);

            string[] lines = System.IO.File.ReadAllLines(DATA_URL);

            foreach (string line in lines)
            {
                string[] parameters = line.Split(";");
                TodoModel item = new()
                {
                    Id = parameters[0],
                    Name = parameters[1],
                    Description = parameters[2],
                    IsFinished = bool.Parse(parameters[3])
                };
                items.Add(item);
            }

            return items;
        }

        public void WriteItemsToFile(List<TodoModel> items)
        {
            //string readTodos = JsonConvert.SerializeObject(items);
            //System.IO.File.WriteAllText(DATA_URL, readTodos);
            System.IO.File.WriteAllText(DATA_URL, "");
            foreach (TodoModel item in items)
            {
                System.IO.File.AppendAllText(DATA_URL, $"{item.Id};{item.Name};{item.Description};{item.IsFinished}\n");
            }

        }
    }
}
