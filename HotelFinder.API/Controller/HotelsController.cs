using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelFinder.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;

namespace HotelFinder.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels); //200+data
        }
        /// <summary>
        /// Get hotel by ıd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotels = await _hotelService.GetHotelById(id);
            if (hotels != null)
            {
                return Ok(hotels);//200+data
            }
            return NotFound();
        }
        /// <summary>
        /// Get Hotel By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotels = await _hotelService.GetHotelByName(name);
            if (hotels != null)
            {
                return Ok(hotels);//200+data
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{city}")]
        public async Task<IActionResult> GetHotelByCity(string city)
        {
            var hotels = await _hotelService.GetHotelByCity(city);
            if (hotels != null)
            {
                return Ok(hotels);//200+data
            }
            return NotFound();
        }
        /// <summary>
        /// Create an hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            var CreatedHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = CreatedHotel.ID }, CreatedHotel);//201+data
        }
        /// <summary>
        /// Update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.ID) != null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));
            }
            return BadRequest();
        }
        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound();
            
        }
    }
}
