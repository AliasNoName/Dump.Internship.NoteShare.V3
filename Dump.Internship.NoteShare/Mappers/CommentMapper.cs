using data = Dump.Internship.NoteShare.Data;
using model = Dump.Internship.NoteShare.Models;

namespace Dump.Internship.NoteShare.Mappers
{
    public class CommentMapper
    {
        public static model::Comment Map(data::Comment comment)
        {
            return new model.Comment
            {
                Text = comment.Text,
                CreatedOn = comment.CreatedOn,
                Author = UserMapper.Map(comment.User)
            };
        }

        public static data::Comment Map(model::Comment comment)
        {
            return new data.Comment
            {
                Text = comment.Text,
                CreatedOn = comment.CreatedOn,
                NoteId = comment.NoteId,
                UserId = comment.Author.Id
            };
        }
    }
}