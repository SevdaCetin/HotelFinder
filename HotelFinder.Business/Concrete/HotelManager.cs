using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using HotelFinder.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    
    public class HotelManager : IHotelService
    {
        private string deneme = null;

        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            deneme = hotel.Name;
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {

            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            if (city != null)
            {
                return await _hotelRepository.GetHotelByCity(city);
            }
            throw new Exception("City must not be null ");
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("ID can not be less than 0");

        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            if (name != null)
            {
                return await _hotelRepository.GetHotelByName(name);
            }
            throw new Exception("Name must not be null ");
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}
