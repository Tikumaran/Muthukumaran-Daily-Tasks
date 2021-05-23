using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherWebAPIProject.Models;

namespace WeatherWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly WeatherContext _context;
        private ILogger<WeathersController> _logger;

        public WeathersController(WeatherContext context,ILogger<WeathersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeathers()
        {
            return await _context.Weathers.ToListAsync();
        }

        // GET: api/Weathers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeatherById(int id)
        {
            try
            {
                var weather = await _context.Weathers.FindAsync(id);

                if (weather == null)
                {
                    return NotFound();
                }
                return weather;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return NoContent();
        }
        // GET: api/Weathers/Madurai
       [HttpGet]
       [Route("City")]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeatherByCity(string city)
        {
            try
            {
                List<Weather> weather = await _context.Weathers.Where(i => i.City == city).ToListAsync();
                if (weather == null)
                {
                    return NotFound();
                }
                return weather;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return NoContent();
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.Weather_ID)
            {
                return BadRequest();
            }
            _context.Entry(weather).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weathers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            try
            {
                _context.Weathers.Add(weather);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetWeatherByCity", new { city = weather.City }, weather);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return NotFound();
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            try
            {
                var weather = await _context.Weathers.FindAsync(id);
                if (weather == null)
                {
                    return NotFound();
                }
                _context.Weathers.Remove(weather);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            
            return NoContent();
        }

        private bool WeatherExists(int id)
        {
            return _context.Weathers.Any(e => e.Weather_ID == id);
        }
    }
}
