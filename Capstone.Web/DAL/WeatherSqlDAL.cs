using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL:IWeatherDAL
    {
        private readonly string connectionString;

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<WeatherModel> GetFiveDayForecast(ParkModel park)
        {
            List<WeatherModel> output = new List<WeatherModel>();
            string SQL_GetFiveDayForecast = @" SELECT Top 5 * FROM weather WHERE parkCode = @ParkCode order by fiveDayForecastValue;";
            Dictionary<string, object> dynamicParameterArgs = new Dictionary<string, object>();
            dynamicParameterArgs.Add("@ParkCode", park.ParkCode);

            using(SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                output = myConnection.Query<WeatherModel>(SQL_GetFiveDayForecast, new DynamicParameters(dynamicParameterArgs)).ToList();
            }

            return output;

        }

    }
}
