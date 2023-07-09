using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelOfficial.API.Infrastructure
{
    public interface IHotelOfficialService
    {
        List<Models.HotelOfficial> GetList(Expression<Func<Models.HotelOfficial, bool>> filter = null);
        Models.HotelOfficial GetById(Expression<Func<Models.HotelOfficial, bool>> filter);
        Models.HotelOfficial Add(Models.HotelOfficial hotel);
        Models.HotelOfficial Update(Models.HotelOfficial hotel);
        void Delete(Models.HotelOfficial hotel);
    }
}
