using FoodieMania.DAL;
using FoodieMania.DAL.Entities;
using FoodieMania.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FoodieMania.Domain.Services
{
    public class FoodieService : IFoodieService
    {
        private readonly DataBaseContext _context;

        public FoodieService (DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Foodie>> GetFoodiesAsync()
        {
            try
            {
                var foodies = await _context.Foodies.ToListAsync();
                return foodies;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Foodie> GetFoodieByIdAsync(Guid id)
        {
            try
            {
                var foodie = await _context.Foodies.FirstOrDefaultAsync(c => c.Id == id);
                return foodie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Foodie> CreateFoodieAsync(Foodie foodie)
        {
            try
            {
                foodie.Id = Guid.NewGuid();
                foodie.CreatedDate = DateTime.Now;
                _context.Foodies.Add(foodie);

                await _context.SaveChangesAsync(); 

                return foodie;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Foodie> EditFoodieAsync(Foodie foodie)
        {
            try
            {
                foodie.ModifiedDate = DateTime.Now;

                _context.Foodies.Update(foodie);
                await _context.SaveChangesAsync();

                return foodie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Foodie> DeleteFoodieAsync(Guid id)
        {
            try
            {
                var foodie = await GetFoodieByIdAsync(id);

                if (foodie == null)
                {
                    return null;
                }

                _context.Foodies.Remove(foodie); 
                await _context.SaveChangesAsync(); 

                return foodie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    


    }
}
