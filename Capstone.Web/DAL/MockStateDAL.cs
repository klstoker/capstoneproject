using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class MockStateDAL : IStateDAL
    {
        public List<StateModel> GetStates()
        {
            List<StateModel> output = new List<StateModel>()
            {
                new StateModel(){Id = 50, Code = "Alabama" , Name = "AL" },
                new StateModel(){Id = 1, Code = "Alaska" , Name = "AK" },
                new StateModel(){Id = 2, Code = "Arizona" , Name = "AZ" },
    new StateModel(){Id = 3, Code = "Arkansas" , Name = "AR" },
    new StateModel(){Id = 4, Code = "California" , Name = "CA" },
    new StateModel(){Id = 5, Code = "Colorado" , Name = "CO" },
new StateModel(){Id = 6, Code = "Connecticut" , Name = "CT" },
new StateModel(){Id = 7, Code = "Delaware" , Name = "DE" },
new StateModel(){Id = 8, Code = "Florida" , Name = "FL" },
new StateModel(){Id = 9, Code = "Georgia" , Name = "GA" },
new StateModel(){Id = 10, Code = "Hawaii" , Name = "HI" },
new StateModel(){Id = 11, Code = "Idaho" , Name = "ID" },
new StateModel(){Id = 12, Code = "Illinois" , Name = "IL" },
new StateModel(){Id = 13, Code = "Indiana" , Name = "IN" },
new StateModel(){Id = 14, Code = "Iowa" , Name = "IA" },
new StateModel(){Id = 15, Code = "Kansas" , Name = "KS" },
new StateModel(){Id = 16, Code = "Kentucky" , Name = "KY" },
new StateModel(){Id = 17, Code = "Louisiana" , Name = "LA" },
new StateModel(){Id = 18, Code = "Maine" , Name = "ME" },
new StateModel(){Id = 19, Code = "Maryland" , Name = "MD" },
new StateModel(){Id = 20, Code = "Massachusetts" , Name = "MA" },
new StateModel(){Id = 21, Code = "Michigan" , Name = "MI" },
new StateModel(){Id = 22, Code = "Minnesota" , Name = "MN" },
new StateModel(){Id = 23, Code = "Mississippi" , Name = "MS" },
new StateModel(){Id = 24, Code = "Missouri" , Name = "MO" },
new StateModel(){Id = 25, Code = "Montana" , Name = "MT" },
new StateModel(){Id = 26, Code = "Nebraska" , Name = "NE" },
new StateModel(){Id = 27, Code = "Nevada" , Name = "NV" },
new StateModel(){Id = 28, Code = "New Hampshire" , Name = "NH" },
new StateModel(){Id = 29, Code = "New Jersey" , Name = "NJ" },
new StateModel(){Id = 30, Code = "New Mexico" , Name = "NM" },
new StateModel(){Id = 31, Code = "New York" , Name = "NY" },
new StateModel(){Id = 32, Code = "North Carolina" , Name = "NC" },
new StateModel(){Id = 33, Code = "North Dakota" , Name = "ND" },
new StateModel(){Id = 34, Code = "Ohio" , Name = "OH" },
new StateModel(){Id = 35, Code = "Oklahoma" , Name = "OK" },
new StateModel(){Id = 36, Code = "Oregon" , Name = "OR" },
new StateModel(){Id = 37, Code = "Pennsylvania" , Name = "PA" },
new StateModel(){Id = 38, Code = "Rhode Island" , Name = "RI" },
new StateModel(){Id = 39, Code = "South Carolina" , Name = "SC" },
new StateModel(){Id = 40, Code = "South Dakota" , Name = "SD" },
new StateModel(){Id = 41, Code = "Tennessee" , Name = "TN" },
new StateModel(){Id = 42, Code = "Texas" , Name = "TX" },
new StateModel(){Id = 43, Code = "Utah" , Name = "UT" },
new StateModel(){Id = 44, Code = "Vermont" , Name = "VT" },
new StateModel(){Id = 45, Code = "Virginia" , Name = "VA" },
new StateModel(){Id = 46, Code = "Washington" , Name = "WA" },
new StateModel(){Id = 47, Code = "West Virginia" , Name = "WV" },
new StateModel(){Id = 48, Code = "Wisconsin" , Name = "WI" },
new StateModel(){Id = 49, Code = "Wyoming" , Name = "WY" }

            };
            return output;
        }
    }
}
