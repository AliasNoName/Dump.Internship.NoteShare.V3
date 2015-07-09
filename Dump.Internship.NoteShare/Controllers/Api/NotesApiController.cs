using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dump.Internship.NoteShare.Controllers.Api
{
    public class NotesApiController : ApiController
    {
        private readonly NoteRepository noteRepository;

        public NotesApiController()
        {
            noteRepository = new NoteRepository();
        }

        [System.Web.Http.HttpGet]
        public List<Note> List()
        {
            var noteData = noteRepository.GetAll();
            var noteDtos = noteData.Select(NoteMapper.Map).ToList();

            return noteDtos;
        }

        [System.Web.Http.HttpGet]
        public Note Details(int id)
        {
            var note = noteRepository.Get(id);

            if (note == null)
            {
                throw new HttpException(404, "Note does not exist");
            }

            var noteDto = NoteMapper.Map(note);

            return noteDto;
        }

        [System.Web.Http.HttpPost]
        public void Add(object o)
        {
            var userRepo = new UserRepository();
            Note note = new Note();
            var str = o.ToString();
            JObject obj = JObject.Parse(str);

            var userId = (int)obj.SelectToken("UserId");

            note.Author = UserMapper.Map(userRepo.Get(userId));
            note.Text = (string)obj.SelectToken("Text");
            note.Title = (string)obj.SelectToken("Title");
            
            //note.CreatedOn = DateTime.Now;

            noteRepository.Create(NoteMapper.Map(note));
        }

    }
}
