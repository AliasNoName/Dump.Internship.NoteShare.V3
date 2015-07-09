using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;
using System.Web.Mvc;

namespace Dump.Internship.NoteShare.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository commentRepository;

        public CommentController()
        {
            commentRepository = new CommentRepository();
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            var commentData = CommentMapper.Map(comment);

            commentRepository.Create(commentData);

            return RedirectToRoute("NoteDetails", new { id = comment.NoteId });
        }
    }
}
