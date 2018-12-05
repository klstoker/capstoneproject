using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Capstone.Web.Extensions;
using Microsoft.AspNetCore.Http;


namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString;
        IWeatherDAL weatherDAL;
        IParkDAL parkDAL;

        public HomeController(string connectionString, IParkDAL parkDAL, IWeatherDAL weatherDAL)
        {
            this.connectionString = connectionString;
            this.weatherDAL = weatherDAL;
            this.parkDAL = parkDAL;
        }

        public IActionResult Index()
        {

            List<ParkModel> parks = parkDAL.GetAllParks();
            return View(parks);
        }

        const string WEATHER_SESSION_ID = "WeatherChoice";

        public IActionResult Details(ParkModel park)
        {
            DetailMasterModel masterModel = new DetailMasterModel
            {
                MyPark = parkDAL.GetPark(park),
                FiveDayForecast = weatherDAL.GetFiveDayForecast(park)
            };


            string isCelsius = HttpContext.Session.GetString(WEATHER_SESSION_ID);
            
            if (isCelsius == null || isCelsius == "" || isCelsius == "false")
            {
                isCelsius = "false";
                masterModel.IsCelsius = false;
            }
            else
            {
                isCelsius = "true";
                masterModel.IsCelsius = true;
            }
            HttpContext.Session.SetString(WEATHER_SESSION_ID, isCelsius);

            return View(masterModel);
        }

        public IActionResult ToggleTemp(ParkModel model)
        {


            string isCelsius = HttpContext.Session.GetString(WEATHER_SESSION_ID);
            if (isCelsius == "false")
            {
                isCelsius = "true";

            }
            else
            {
                isCelsius = "false";
            }
            HttpContext.Session.SetString(WEATHER_SESSION_ID, isCelsius);

            return RedirectToAction("Details", model);

        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
