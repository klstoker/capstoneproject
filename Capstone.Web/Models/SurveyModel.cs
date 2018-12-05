using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public List<SelectListItem> ParkChoices = new List<SelectListItem>();

        public List<SelectListItem> ActivityLevelChoices = new List<SelectListItem>();

        public List<SelectListItem> StateChoices = new List<SelectListItem>();
           
    }
}
