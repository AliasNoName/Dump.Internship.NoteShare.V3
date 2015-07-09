using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dump.Internship.NoteShare.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteRepository noteRepository;

        public NoteController()
        {
            noteRepository = new NoteRepository();
        }

        public ActionResult List()
        {
            var noteData = noteRepository.GetAll();
            var noteDtos = noteData.Select(NoteMapper.Map).ToList();

            return View(noteDtos);
        }

        public ActionResult Details(int id)
        {
            var note = noteRepository.Get(id);

            if (note == null)
            {
                throw new HttpException(404, "Note does not exist");
            }

            var noteDto = NoteMapper.Map(note);

            return View(noteDto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            var noteData = NoteMapper.Map(note);
            noteRepository.Create(noteData);

            return RedirectToRoute("NoteList");
        }

        public ActionResult Edit(int id)
        {
            var note = noteRepository.Get(id);

            if (note == null)
            {
                throw new HttpException(404, "Note does not exist");
            }

            var noteDto = NoteMapper.Map(note);

            return View(noteDto);
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            var noteData = NoteMapper.Map(note);
            noteRepository.Update(noteData);

            return RedirectToRoute("NoteList");
        }

        public ActionResult Delete(int id)
        {
            noteRepository.Delete(id);

            return RedirectToRoute("NoteList");
        }
    }
}
