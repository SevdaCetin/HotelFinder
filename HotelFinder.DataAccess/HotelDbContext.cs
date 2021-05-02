using Microsoft.EntityFrameworkCore;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=OWNERSRV;Database=HotelDb;uid=sa;pwd=LOgo1453");
        }
        public DbSet<Hotel> MyProperty { get; set; }
    }
}
