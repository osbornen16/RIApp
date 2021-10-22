
using RI.Data;
using RI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Service
{
    public class PersonService
    {
        private readonly Guid _userId;
        public PersonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePerson(CreatePerson model)
        {
            var entity =
                new Person()
                {
                    PersonId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    State = model.State,
                    StreetAddress = model.StreetAddress,
                    City = model.City
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.People.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PersonListItem> GetPeople()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .People
                    .Where(e => e.PersonId == _userId)
                    .Select(
                        e =>
                        new PersonListItem
                        {
                            PersonId = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            State = e.State,
                            StreetAddress = e.StreetAddress,
                            City = e.City
                        }
                        );
                return query.ToArray();

            }
        }

        public PersonDetails GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .People
                    .Single(e => e.Id == id && e.PersonId == _userId);
                return
                    new PersonDetails
                    {
                        PersonId = entity.PersonId,
                        FirstName = entity.FirstName,
                        LastName =  entity.LastName,
                        State = entity.State,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City
                    };
            }
        }
        public bool EditPerson(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .People
                    .Single(e => e.FirstName == model.FirstName);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.State = model.State;
                entity.StreetAddress = model.StreetAddress;
                            entity.City = model.City;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
