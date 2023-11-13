using WeatherAppFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace WeatherAppFinal.Controllers
{
    public class WeatherController : Controller
    {
        //private field to hold reference to the service instance
        private readonly IWeatherService _weatherService;

        //Create a constructor and inject IWeatherService
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        //When a HTTP GET request is received at path "/"
        [Route("/")]
        public IActionResult Index()    // an action method, "Views/Weather/Index"
        {
            //invoke service method
            var cities = _weatherService.GetWeatherDetails();

            //send cities collection to "Views/Weather/Index" view
            return View(cities);
        }


        [Route("weather/{cityCode?}")] 
        public IActionResult City(string? cityCode)   // an action method, "Views/Weather/City"
        {
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/City" view
                return View();
            }

            //invoke service method (get matching city object based on the city code)
            CityWeather? city = _weatherService.GetWeatherByCityCode(cityCode);

            //send matching city object to "Views/Weather/City" view
            return View(city);     // the model property points to the object that is supplied from the controller, if don't supply any object from this, then the model property refers to null
            // if try calling any of the properties then it will be runtime null reference exception
        }
    }
}
