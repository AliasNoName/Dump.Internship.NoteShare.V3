using data = Dump.Internship.NoteShare.Data;
using System.Linq;
using model = Dump.Internship.NoteShare.Models;

namespace Dump.Internship.NoteShare.Mappers
{
    public class UserMapper
    {
        public static model::User Map(data::User user)
        {
            return new model.User
            {
                Id = user.Id,
                CreatedOn = user.CreatedOn,
                FullName = user.FullName,
                IsPremiumUser = user.IsPremiumUser
            };
        }

        public static data::User Map(model::User user)
        {
            return new data.User
            {
                Id = user.Id,
                CreatedOn = user.CreatedOn,
                FullName = user.FullName,
                IsPremiumUser = user.IsPremiumUser
            };
        }
    }
}