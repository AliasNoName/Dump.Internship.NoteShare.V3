using System;
using System.Collections.Generic;

namespace Dump.Internship.NoteShare.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public User Author { get; set; }
        public IList<Comment> Comments { get; set; } 
    }
}