using HotelContact.API.Infrastructure;
using HotelContact.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelContact.API.Services
{
    public class HotelContactService : IHotelContactService
    {
        private readonly HotelContactDbContext _hotelContactDbContext;

        public HotelContactService(HotelContactDbContext hotelContactDbContext)
        {
            _hotelContactDbContext = hotelContactDbContext;
        }
        public Models.HotelContact Add(Models.HotelContact hotelContact)
        {
            _hotelContactDbContext.Entry(hotelContact).State = EntityState.Added;
            _hotelContactDbContext.SaveChanges();
            return hotelContact;
        }

        public void Delete(Models.HotelContact hotelContact)
        {
            _hotelContactDbContext.Entry(hotelContact).State = EntityState.Deleted;
            _hotelContactDbContext.SaveChanges();
        }

        public Models.HotelContact GetById(Expression<Func<Models.HotelContact, bool>> filter)
        {
            return _hotelContactDbContext.Set<Models.HotelContact>().FirstOrDefault(filter);
        }

        public List<Models.HotelContact> GetList(Expression<Func<Models.HotelContact, bool>> filter = null)
        {
            if (filter == null)
                return _hotelContactDbContext.Set<Models.HotelContact>().ToList();
            else
                return _hotelContactDbContext.Set<Models.HotelContact>().Where(filter).ToList();
        }

        public Models.HotelContact Update(Models.HotelContact hotelContact)
        {
            _hotelContactDbContext.Entry(hotelContact).State = EntityState.Modified;
            _hotelContactDbContext.SaveChanges();
            return hotelContact;
        }
    }
}
