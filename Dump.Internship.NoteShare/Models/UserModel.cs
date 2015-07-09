using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dump.Internship.NoteShare.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public IList<Note> Notes { get; set; }
        public IList<Comment> Comments { get; set; }

        public UserModel(User User, IList<Note> Notes, IList<Comment> Comments)
        {
            this.User = User;
            this.Notes = Notes;
            this.Comments = Comments;
        }

    }
}