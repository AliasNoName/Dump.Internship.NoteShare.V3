using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Dump.Internship.NoteShare.Data.Repositories
{
    public class UserRepository
    {
        public User Get(int id)
        {
            using (var context = new NoteShareEntities())
            {
                return context.Users
                    .SingleOrDefault(user => user.Id == id);
            }
        }

        public IList<User> GetAll()
        {
            using (var context = new NoteShareEntities())
            {
                return context.Users.ToList();
            }
        }

        public IList<Note> GetNotes(int id)
        {
            using (var context = new NoteShareEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.Notes
                    .Include(n => n.User)
                    .Include(n => n.Comments)
                    .Include(n => n.Comments.Select(c => c.User))
                    .Where(note => note.UserId == id)
                    .ToList();
            }
            
        }

        public IList<Comment> GetComments(int id)
        {
            using (var context = new NoteShareEntities())
            {
                return context.Comments
                    .Include(c => c.User)
                    .Where(comment => comment.NoteId == id)
                    .ToList();
            }
        }

        public void Create(User user)
        {
            using (var context = new NoteShareEntities())
            {
                user.CreatedOn = DateTime.Now;

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var context = new NoteShareEntities())
            {
                var existingUser = context.Users.SingleOrDefault(x => x.Id == user.Id);

                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.IsPremiumUser = user.IsPremiumUser;

                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new NoteShareEntities())
            {
                var user = context.Users.SingleOrDefault(x => x.Id == id);

                if (user != null)
                {
                    context.Users.Remove(user);

                    context.SaveChanges();
                }
            }
        }
    }
}