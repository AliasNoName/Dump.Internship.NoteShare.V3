using System.Linq;
using data = Dump.Internship.NoteShare.Data;
using model = Dump.Internship.NoteShare.Models;

namespace Dump.Internship.NoteShare.Mappers
{
    public class NoteMapper
    {
        public static model::Note Map(data::Note note)
        {
            return new model.Note
            {
                Id = note.Id,
                CreatedOn = note.CreatedOn,
                Text = note.Text,
                Title = note.Title,
                Author = UserMapper.Map(note.User),
                Comments = note.Comments.Select(CommentMapper.Map).ToList()
            };
        }

        public static data::Note Map(model::Note note)
        {
            return new data.Note
            {
                Id = note.Id,
                Text = note.Text,
                Title = note.Title,
                CreatedOn = note.CreatedOn,
                UserId = note.Author.Id
            };
        }
    }
}