using HotelOfficial.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelOfficial.API.Services
{
    public class HotelOfficialService : IHotelOfficialService
    {
        private readonly HotelOfficialDbContext _hotelOfficialDbContext;

        public HotelOfficialService(HotelOfficialDbContext hotelOfficialDbContext)
        {
            _hotelOfficialDbContext = hotelOfficialDbContext;
        }

        public Models.HotelOfficial Add(Models.HotelOfficial hotelOfficial)
        {
            _hotelOfficialDbContext.Entry(hotelOfficial).State = EntityState.Added;
            _hotelOfficialDbContext.SaveChanges();
            return hotelOfficial;
        }

        public void Delete(Models.HotelOfficial hotelOfficial)
        {
            _hotelOfficialDbContext.Entry(hotelOfficial).State = EntityState.Deleted;
            _hotelOfficialDbContext.SaveChanges();
        }

        public Models.HotelOfficial GetById(Expression<Func<Models.HotelOfficial, bool>> filter)
        {
            return _hotelOfficialDbContext.Set<Models.HotelOfficial>().FirstOrDefault(filter);
        }

        public List<Models.HotelOfficial> GetList(Expression<Func<Models.HotelOfficial, bool>> filter = null)
        {
            if (filter == null)
                return _hotelOfficialDbContext.Set<Models.HotelOfficial>().ToList();
            else
                return _hotelOfficialDbContext.Set<Models.HotelOfficial>().Where(filter).ToList();

        }

        public Models.HotelOfficial Update(Models.HotelOfficial hotelOfficial)
        {
            _hotelOfficialDbContext.Entry(hotelOfficial).State = EntityState.Modified;
            _hotelOfficialDbContext.SaveChanges();
            return hotelOfficial; ;
        }
    }
}
