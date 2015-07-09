using System;

namespace Dump.Internship.NoteShare.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public int NoteId { get; set; }

        public User Author { get; set; }
    }
}