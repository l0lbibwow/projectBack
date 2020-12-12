using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Data.Repo;
using WebAPI.Interfaces;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly ICityRepository repo;
    public CityController(ICityRepository repo)
    {
      this.repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
      var cities = await repo.GetCitiesAsync();
      return Ok(cities);
    }

    //Post api/city/post
    [HttpPost("post")]
    public async Task<IActionResult> AddCity(City city)
    {
      repo.AddCity(city);
      await repo.SaveAsync();
      return StatusCode(201);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DelteCity(int id)
    {
      repo.DeleteCity(id);
      await repo.SaveAsync();
      return Ok(id);
    }
  }
}
