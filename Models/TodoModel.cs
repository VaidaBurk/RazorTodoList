using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorToDoList.Models
{
    public class TodoModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
    }
}
