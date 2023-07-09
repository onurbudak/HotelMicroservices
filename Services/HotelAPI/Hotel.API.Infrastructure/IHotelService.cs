using Hotel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.API.Infrastructure
{
    public interface IHotelService
    {
        List<Models.Hotel> GetList(Expression<Func<Models.Hotel, bool>> filter = null);
        Models.Hotel GetById(Expression<Func<Models.Hotel, bool>> filter);
        Models.Hotel Add(Models.Hotel hotel);
        Models.Hotel Update(Models.Hotel hotel);
        void Delete(Models.Hotel hotel);
    }
}
