﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
       List<ParkModel> GetAllParks();
               
        ParkModel GetPark(ParkModel inputPark);
        
    }
}
