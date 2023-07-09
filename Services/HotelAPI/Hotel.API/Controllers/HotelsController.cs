using Hotel.API.Infrastructure;
using Hotel.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{id}")]
        public HotelDto Get(Guid id)
        {
            var result = _hotelService.GetById(q => q.UUID == id);
            if (result != null)
            {
                return new HotelDto
                {
                    UUID = result.UUID,
                    Name = result.Name,
                };
            }
            else
            {
                return new HotelDto();
            }
        }

        [HttpGet("List")]
        public List<HotelDto> GetList()
        {
            List<HotelDto> hotelDtoList = new List<HotelDto>();    
            var result = _hotelService.GetList();
            foreach (var item in result)
            {
                if (item != null)
                {
                    hotelDtoList.Add(new HotelDto
                    {
                        UUID = item.UUID,
                        Name = item.Name,
                    });
                }
            }
            return hotelDtoList;
        }

        [HttpPost("Add")]
        public Models.Hotel Add(Models.Hotel hotel)
        {
            return _hotelService.Add(hotel);
        }

        [HttpPost("Update")]
        public Models.Hotel Update(Models.Hotel hotel)
        {
            return _hotelService.Update(hotel);
        }

        [HttpPost("Delete")]
        public void Delete(Models.Hotel hotel)
        {
            _hotelService.Delete(hotel);
        }
    }
}
