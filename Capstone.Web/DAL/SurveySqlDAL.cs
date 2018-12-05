using Capstone.Web.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Capstone.Web.DAL
{
    public class SurveySqlDAL:ISurveyDAL
    {
        private string connectionString;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetFavorites()
        {
            List<ParkModel> surveys = new List<ParkModel>();
            string SQL_Get_Favorites = @"SELECT park.parkCode, park.parkName, park.state, park.acreage, park.elevationInFeet, park.milesOfTrail, park.numberOfCampsites, park.climate, park.yearFounded, "
                + "park.annualVisitorCount, park.inspirationalQuote, park.inspirationalQuoteSource, park.parkDescription, park.entryFee, park.numberOfAnimalSpecies, count(*) as numberOfSurveys from park "
                + "join survey_result on park.parkCode = survey_result.parkCode" 
                + " group by park.parkCode,park.parkName, park.state, park.acreage, park.elevationInFeet, park.milesOfTrail, park.numberOfCampsites, park.climate, park.yearFounded ,park.annualVisitorCount"
                + ", park.inspirationalQuote, park.inspirationalQuoteSource, park.parkDescription, park.entryFee, park.numberOfAnimalSpecies"
                + " ORDER BY numberOfSurveys desc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                surveys = conn.Query<ParkModel>(SQL_Get_Favorites).ToList();
            }
            return surveys;
        }

        public int NewSurvey(SurveyModel survey)
        {
            string SQL_New_Survey = @"INSERT INTO survey_result (ParkCode, EmailAddress, State, ActivityLevel) VALUES (@ParkCode, @EmailAddress, @State, @ActivityLevel)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                int rowsAffected = conn.Execute(SQL_New_Survey, survey);
                return rowsAffected;
            }
        }

    }
}
