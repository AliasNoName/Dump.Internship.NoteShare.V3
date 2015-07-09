using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Dump.Internship.NoteShare.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        public ActionResult Details(int id)
        {
            var model = GetModel(id);
            
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            var userData = UserMapper.Map(user);
            userRepository.Create(userData);

            return RedirectToRoute("NoteList");
        }


        public ActionResult Update(int id)
        {
            var user = userRepository.Get(id);

            if (user == null)
            {
                throw new HttpException(404, "User does not exist");
            }

            var userDto = UserMapper.Map(user);

            return View(userDto);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            var userData = UserMapper.Map(user);
            userRepository.Update(userData);

            return RedirectToRoute("NoteList");
        }


        public ActionResult Delete(int id)
        {
            userRepository.Delete(id);

            return RedirectToRoute("NoteList");
        }


        private UserModel GetModel(int userId)
        {
            var user = userRepository.Get(userId);
            var notes = userRepository.GetNotes(userId);
            var comments = userRepository.GetComments(userId);

            if (user == null)
            {
                throw new HttpException(404, "User does not exist");
            }

            var userDto = UserMapper.Map(user);
            var noteDtos = notes.Select(NoteMapper.Map).ToList();
            var commentDtos = comments.Select(CommentMapper.Map).ToList();

            return new UserModel(userDto, noteDtos, commentDtos);
        }
    }
}
