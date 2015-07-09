using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dump.Internship.NoteShare.Data.Repositories;
using Dump.Internship.NoteShare.Mappers;
using Dump.Internship.NoteShare.Models;

namespace Dump.Internship.NoteShare.Controllers.Api
{
    public class UserApiController : ApiController
    {
        private readonly UserRepository userRepository;
        public UserApiController()
        {
            userRepository = new UserRepository();
        }

        [System.Web.Http.HttpGet]
        public List<User> List()
        {
            var userData = userRepository.GetAll();
            var userDtos = userData.Select(UserMapper.Map).ToList();

            return userDtos;
        }
    }
}