using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.WebUI.Models
{
    public class EventListRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty.")]
        [StringLength(150, ErrorMessage = "You can enter a maximum of 150 character.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field cannot be empty.")]
        [StringLength(1500, ErrorMessage = "You can enter a maximum of 1500 character.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "This field cannot be empty.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field cannot be empty.")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
    }
}