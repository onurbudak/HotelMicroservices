using HotelOfficial.API.Infrastructure;
using HotelOfficial.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelOfficial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelOfficialsController : ControllerBase
    {
        private readonly IHotelOfficialService _hotelOfficialService;

        public HotelOfficialsController(IHotelOfficialService hotelOfficialService)
        {
            _hotelOfficialService = hotelOfficialService;
        }

        [HttpGet("{id}")]
        public HotelOfficialDto Get(Guid id)
        {
            var result = _hotelOfficialService.GetById(q => q.UUID == id);
            if (result != null)
            {
                return new HotelOfficialDto
                {
                    UUID = result.UUID,
                    Name = result.Name,     
                    SurName = result.SurName,
                    Title = result.Title
                };
            }
            else
            {
                return new HotelOfficialDto();
            }
        }
        [HttpGet("List")]
        public List<HotelOfficialDto> GetList()
        {
            List<HotelOfficialDto> hotelContactList = new List<HotelOfficialDto>();
            var result = _hotelOfficialService.GetList();
            foreach (var item in result)
            {
                if (item != null)
                {
                    hotelContactList.Add(new HotelOfficialDto
                    {
                        UUID = item.UUID,
                        Name = item.Name,
                        SurName = item.SurName,
                        Title = item.Title
                    });
                }
            }
            return hotelContactList;
        }

        [HttpPost("Add")]
        public Models.HotelOfficial Add(Models.HotelOfficial hotelOfficial)
        {
            return _hotelOfficialService.Add(hotelOfficial);
        }

        [HttpPost("Update")]
        public Models.HotelOfficial Update(Models.HotelOfficial hotelOfficial)
        {
            return _hotelOfficialService.Update(hotelOfficial);
        }

        [HttpPost("Delete")]
        public void Delete(Models.HotelOfficial hotelOfficial)
        {
            _hotelOfficialService.Delete(hotelOfficial);
        }
    }
}
