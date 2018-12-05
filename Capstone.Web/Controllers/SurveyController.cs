using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private string connectionString;
        ISurveyDAL surveyDAL;
        IParkDAL parkDAL;
        IStateDAL stateDAL;

        public SurveyController(string connectionString, ISurveyDAL surveyDAL, IParkDAL parkDAL, IStateDAL stateDAL)
        {
            this.connectionString = connectionString;
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
            this.stateDAL = stateDAL;
        }
        public IActionResult Index()
        {
            SurveyModel model = new SurveyModel();

           
            List<ParkModel> allParks = parkDAL.GetAllParks();


            for (int i = 0; i < allParks.Count; i++)
            {
                SelectListItem temp = new SelectListItem(allParks[i].ParkName, allParks[i].ParkCode);
                model.ParkChoices.Add(temp);
            }

            model.ActivityLevelChoices.Add(new SelectListItem("inactive", "inactive"));
            model.ActivityLevelChoices.Add(new SelectListItem("sedentary", "sedentary"));
            model.ActivityLevelChoices.Add(new SelectListItem("active", "active"));
            model.ActivityLevelChoices.Add(new SelectListItem("extremely active", "extremely active"));

           
            List<StateModel> allStates = stateDAL.GetStates();
            foreach(StateModel state in allStates)
            {
                model.StateChoices.Add(new SelectListItem(state.Code, state.Code));
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Results()
        {
            
            List<ParkModel> myFavoriteParks = surveyDAL.GetFavorites();

            return View(myFavoriteParks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Results(SurveyModel model)
        {
            if (ModelState.IsValid)
            {
                //insert survey data with DAL
                surveyDAL.NewSurvey(model);
            }
            else
            {
                return View("Index");
            }

            return RedirectToAction("Results");
        }
      
        

    }
}
