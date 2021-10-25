using Microsoft.AspNet.Identity;
using RI.Data;
using RI.Models;
using RI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RelativelyIrrelevantApp.Controllers
{
    [Authorize]
    public class PersonController : ApiController
    {
        private PersonService CreatePersonService()
        {
            var personId = Guid.Parse(User.Identity.GetUserId());
            var personService = new PersonService(personId);
            return personService;
        }
        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var people = personService.GetPeople();
            return Ok(people);
        }
        public IHttpActionResult Post(CreatePerson person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePersonService();

            if (!service.CreatePerson(person))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePersonService();

            if (!service.EditPerson(person))
                return InternalServerError();

            return Ok();
        }   
    }
}
