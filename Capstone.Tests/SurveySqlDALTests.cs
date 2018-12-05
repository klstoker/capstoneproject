using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using System.Transactions;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Tests
{
    [TestClass()]
    public class SurveySqlDALTests
    {
        private string configPath = @"Data Source=.\SQLEXPRESS;Initial Catalog=SSGeek;Integrated Security=true";
        private string npGeek;
        private TransactionScope myTransaction;


        [TestInitialize]
        public void Initialize()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = configPath;
            Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            npGeek = cfg.ConnectionStrings.ConnectionStrings["configPath"].ToString();

            myTransaction = new TransactionScope();
            try
            {
                using (SqlConnection conn = new SqlConnection(npGeek))
                {
                    SqlCommand cmd;
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES ('CCNP', 'jo@jomamma.com', 'PA', 'sedentary')", conn);
                    cmd.Parameters.AddWithValue("@parkCode", Convert.ToString("CCNP"));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [TestCleanup]
        public void CleanUp()
        {
            myTransaction.Dispose();
        }
        [TestMethod]
        public void GetSurveysTest()
        {
            SurveySqlDAL surveySql = new SurveySqlDAL(npGeek);
            List<ParkModel> mySurveys = surveySql.GetFavorites();
            Assert.IsNotNull(mySurveys);
            Assert.AreEqual(11, mySurveys.Count);
        }
            
        
        
        


        
    }





}
