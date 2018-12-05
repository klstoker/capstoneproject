using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class StateDAL: IStateDAL
    {
        private readonly string connectionString;

        public StateDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<StateModel> GetStates()
        {
            List<StateModel> output = new List<StateModel>();
            string SQL_GetAllStates = @"SELECT * from states";

            using(SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                output = myConnection.Query<StateModel>(SQL_GetAllStates).ToList();
            }


            return output;
        }
    }
}
