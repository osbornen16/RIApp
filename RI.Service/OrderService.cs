using RelativelyIrrelevantApp.Models;
using RI.Data;
using RI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Service
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public OrderDetail GetOrderById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Order.Single(e => e.Id == id && e.PersonId == _userId);
                return new OrderDetail
                {
                    Id = entity.Id,
                    ItemCount = entity.ItemCount,
                    OrderDate = entity.OrderDate,
                    OrderTotal = entity.OrderTotal,
                    PersonId = entity.PersonId
                };
            }
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity = new Order()
            {
                PersonId = _userId,
                ItemCount = model.ItemCount,
                OrderDate = DateTimeOffset.UtcNow,
                OrderTotal = model.OrderTotal
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Order.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateOrder(OrderEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Order.Single(e => e.Id == model.Id && e.PersonId == _userId);
                entity.ItemCount = model.ItemCount;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOrder(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Order.Single(e => e.Id == id && e.PersonId == _userId);
                ctx.Order.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
