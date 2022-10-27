﻿namespace ToDoLibrary.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AssignedTo { get; set; }
        public bool IsComplete { get; set; }
    }
}
