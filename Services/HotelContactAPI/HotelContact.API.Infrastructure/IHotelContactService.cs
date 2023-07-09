using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelContact.API.Infrastructure
{
    public interface IHotelContactService
    {
        List<Models.HotelContact> GetList(Expression<Func<Models.HotelContact, bool>> filter = null);
        Models.HotelContact GetById(Expression<Func<Models.HotelContact, bool>> filter);
        Models.HotelContact Add(Models.HotelContact hotelContact);
        Models.HotelContact Update(Models.HotelContact hotelContact);
        void Delete(Models.HotelContact hotelContact);
    }
}
