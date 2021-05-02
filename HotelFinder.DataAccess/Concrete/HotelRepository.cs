using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using(var hotelDbContext= new HotelDbContext())
            {
                await hotelDbContext.AddAsync(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedHotel = await GetHotelById(id);
                hotelDbContext.Remove(deletedHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            using(var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.MyProperty.ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.MyProperty.FirstOrDefaultAsync(x => x.City.ToLower() == city.ToLower());
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.MyProperty.FindAsync(id);
            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using(var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.MyProperty.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using(var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
