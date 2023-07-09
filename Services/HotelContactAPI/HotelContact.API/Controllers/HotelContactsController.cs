using HotelContact.API.Infrastructure;
using HotelContact.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelContactsController : ControllerBase
    {
        private readonly IHotelContactService _hotelContactService;

        public HotelContactsController(IHotelContactService hotelContactService)
        {
            _hotelContactService = hotelContactService;
        }

        [HttpGet("{id}")]
        public HotelContactDto Get(Guid id)
        {
            var result = _hotelContactService.GetById(q => q.UUID == id);
            if (result != null)
            {
                return new HotelContactDto
                {
                    Content = result.Content,
                    UUID = result.UUID,
                    Email = result.Email,
                    Location = result.Location,
                    Phone = result.Phone,
                };
            }
            else
            {
                return new HotelContactDto();
            }
        }

        [HttpGet("List")]
        public List<HotelContactDto> GetList()
        {
            List<HotelContactDto> hotelContactList = new List<HotelContactDto>();
            var result = _hotelContactService.GetList();
            foreach (var item in result)
            {
                if (item != null)
                {
                    hotelContactList.Add(new HotelContactDto
                    {
                        UUID = item.UUID,
                        Content = item.Content,
                        Email = item.Email,
                        Location = item.Location,
                        Phone = item.Phone,
                    });
                }
            }
            return hotelContactList;
        }

        [HttpPost("Add")]
        public Models.HotelContact Add(Models.HotelContact hotel)
        {
            return _hotelContactService.Add(hotel);
        }

        [HttpPost("Update")]
        public Models.HotelContact Update(Models.HotelContact hotel)
        {
            return _hotelContactService.Update(hotel);
        }

        [HttpPost("Delete")]
        public void Delete(Models.HotelContact hotel)
        {
            _hotelContactService.Delete(hotel);
        }
    }
}
