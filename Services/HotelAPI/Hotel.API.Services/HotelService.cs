using Hotel.API.Infrastructure;
using Hotel.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _hotelDbContext;

        public HotelService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public Models.Hotel Add(Models.Hotel hotel)
        {
            _hotelDbContext.Entry(hotel).State = EntityState.Added;
            _hotelDbContext.SaveChanges();
            return hotel;
        }

        public void Delete(Models.Hotel hotel)
        {
            _hotelDbContext.Entry(hotel).State = EntityState.Deleted;
            _hotelDbContext.SaveChanges();
        }

        public Models.Hotel GetById(Expression<Func<Models.Hotel, bool>> filter)
        {
            return _hotelDbContext.Set<Models.Hotel>().FirstOrDefault(filter);       
        }

        public List<Models.Hotel> GetList(Expression<Func<Models.Hotel, bool>> filter = null)
        {
            if (filter == null)
                return _hotelDbContext.Set<Models.Hotel>().ToList();
            else
                return _hotelDbContext.Set<Models.Hotel>().Where(filter).ToList();
        }

        public Models.Hotel Update(Models.Hotel hotel)
        {
            _hotelDbContext.Entry(hotel).State = EntityState.Modified;
            _hotelDbContext.SaveChanges();
            return hotel;
        }
    }
}
