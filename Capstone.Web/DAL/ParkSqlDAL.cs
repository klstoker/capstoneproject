using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL:IParkDAL
    {
        private readonly string connectionString;

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parks = new List<ParkModel>();
            string SQL_Get_Parks = @"SELECT * from park";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                parks = conn.Query<ParkModel>(SQL_Get_Parks).ToList();
            }
            return parks;
        }

        public ParkModel GetPark (ParkModel inputPark)
        {
            ParkModel park = new ParkModel();
            string SQL_Get_Park = @"SELECT * from park where ParkCode = @ParkCode";
            Dictionary<string, object> dynamicParameterArgs = new Dictionary<string, object>();
            dynamicParameterArgs.Add("@ParkCode", inputPark.ParkCode);
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                park = conn.Query<ParkModel>(SQL_Get_Park, new DynamicParameters(dynamicParameterArgs)).ToList().FirstOrDefault();
            }
            return park;
        }
    }
}
