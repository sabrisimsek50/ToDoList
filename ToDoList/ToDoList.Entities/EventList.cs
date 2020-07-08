using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public class EventList
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public TimeSpan Time { get; set; }
    }
}
