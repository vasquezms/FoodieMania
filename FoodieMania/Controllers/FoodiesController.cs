using FoodieMania.DAL.Entities;
using FoodieMania.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class FoodiesController : Controller
    {
        private readonly IFoodieService _foodieService;

        public FoodiesController(IFoodieService foodieService)
        {
            _foodieService = foodieService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Foodie>>> GetCountriesAsync()
        {
            var foodies = await _foodieService.GetFoodiesAsync();

            if (foodies == null || !foodies.Any()) return NotFound();

            return Ok(foodies);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] 
        public async Task<ActionResult<Foodie>> GetFoodieByIdAsync(Guid id)
        {
            var foodies = await _foodieService.GetFoodieByIdAsync(id);

            if (foodies == null) return NotFound();

            return Ok(foodies); 
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Foodie>> CreateFoodieAsync(Foodie foodie)
        {
            try
            {
                var newFoodie = await _foodieService.CreateFoodieAsync(foodie);
                if (newFoodie == null) return NotFound();
                return Ok(newFoodie);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", foodie.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Foodie>> EditFoodieAsync(Foodie foodie)
        {
            try
            {
                var editedFoodie = await _foodieService.EditFoodieAsync(foodie);
                if (editedFoodie == null) return NotFound();
                return Ok(editedFoodie);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", foodie.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Foodie>> DeleteFoodieAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedFoodie = await _foodieService.DeleteFoodieAsync(id);

            if (deletedFoodie == null) return NotFound();

            return Ok("Borrado satisfactoriamente");

        }
    }
}