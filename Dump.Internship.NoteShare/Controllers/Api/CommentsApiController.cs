using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace Dump.Internship.NoteShare.Controllers.Api
{
    public class CommentsApiController : ApiController
    {
        private readonly CommentRepository commentRepository;
        public CommentsApiController()
        {
            commentRepository = new CommentRepository();
        }


        [System.Web.Http.HttpPost]
        public ActionResult Add(object o)
        {
            var userRepo = new UserRepository();
            Comment comment = new Comment();
            var str = o.ToString();
            JObject obj = JObject.Parse(str);

            var userId = (int)obj.SelectToken("UserId");

            comment.Author = UserMapper.Map(userRepo.Get(userId));
            comment.Text = (string)obj.SelectToken("Text");
            comment.NoteId = (int)obj.SelectToken("NoteId");

            comment.CreatedOn = DateTime.Now;

            commentRepository.Create(CommentMapper.Map(comment));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}