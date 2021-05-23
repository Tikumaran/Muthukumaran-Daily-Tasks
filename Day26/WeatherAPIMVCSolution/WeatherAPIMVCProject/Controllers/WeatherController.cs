using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAPIMVCProject.Models;

namespace WeatherAPIMVCProject.Controllers
{
    public class WeatherController : Controller
    {
        private ILogger<WeatherController> _logger;
        private Weather obj;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }
        // GET: WeatherController
        public ActionResult Index()
        {
            return RedirectToAction("CityLogin");
        }
        // GET: WeatherController/CityDetails/City
        [HttpGet]
        public IActionResult CityLogin(string City)
        {
            try
            {
                if (City != null)
                {
                    Weather weather = new Weather();
                    weather.City = City;
                    return View(weather);
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        [HttpPost]
        public ActionResult CityLogin(Weather weather)
        {
            try
            {
                string city = weather.City;
                return RedirectToAction("Details", new { City = city });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        [HttpGet]
        
        // GET: WeatherController/Details/Madurai
        public async Task<ActionResult> Details(string City)
        {
            try
            {
                List<Weather> weather = new List<Weather>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:65112/api/Weathers/City?city=" + City))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        weather = JsonConvert.DeserializeObject<List<Weather>>(apiResponse);
                    }
                }
                return View(weather);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        [HttpGet]
        // GET: WeatherController/Details/5
        public async Task<ActionResult> DetailByID(int id)
        {
            try
            {
                Weather weather = new Weather();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:65112/api/Weathers/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        weather = JsonConvert.DeserializeObject<Weather>(apiResponse);
                    }
                }
                return View(weather);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        [HttpGet]
        // GET: WeatherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Weather weather)
        {
            try
            {
                var obj = new Weather();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(weather), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:65112/api/Weathers/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<Weather>(apiResponse);
                    }
                }
                string city = obj.City;
                return RedirectToAction("CityLogin", new { City = city });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }


        // GET: WeatherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
