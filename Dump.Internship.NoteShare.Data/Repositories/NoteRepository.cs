using System;
using System.Collections.Generic;
using System.Linq;

namespace Dump.Internship.NoteShare.Data.Repositories
{
    public class NoteRepository
    {
        public Note Get(int id)
        {
            using (var context = new NoteShareEntities())
            {
                return context.Notes
                    .Include("User")
                    .Include("Comments")
                    .Include("Comments.User")
                    .SingleOrDefault(note => note.Id == id);
            }
        }

        public IList<Note> GetAll()
        {
            using (var context = new NoteShareEntities())
            {
                return context.Notes
                    .Include("User")
                    .Include("Comments")
                    .Include("Comments.User")
                    .ToList();
            }
        }

        public void Create(Note note)
        {
            using (var context = new NoteShareEntities())
            {
                note.CreatedOn = DateTime.Now;
                //note.User = context.Users.First();

                context.Notes.Add(note);
                context.SaveChanges();
            }
        }

        public void Update(Note note)
        {
            using (var context = new NoteShareEntities())
            {
                var existingNote = context.Notes.SingleOrDefault(x => x.Id == note.Id);

                if (existingNote != null)
                {
                    existingNote.Title = note.Title;
                    existingNote.Text = note.Text;

                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new NoteShareEntities())
            {
                var note = context.Notes.SingleOrDefault(x => x.Id == id);

                if (note != null)
                {
                    context.Comments.RemoveRange(note.Comments);
                    context.Notes.Remove(note);

                    context.SaveChanges();
                }
            }
        }
    }
}
