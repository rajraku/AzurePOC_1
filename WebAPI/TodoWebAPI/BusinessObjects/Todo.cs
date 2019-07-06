using System;

namespace BusinessObjects
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
