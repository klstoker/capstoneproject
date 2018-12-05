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
    public class ParkSqlDALTests
    {
        private string configPath = System.IO.Path.Combine(Environment.CurrentDirectory, "App.config");
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
                    cmd = new SqlCommand("INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('CCNP', 'Camp Corey National Park', 'PA', 50000, 7575, 1000, 100, 'Rainforest', 2018, 1000000, 'Okayyyy', 'Corey Jansen', 'A glittery wonderland', 20, 500)", conn);
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
        public void GetParksTest()
        {
            ParkSqlDAL parkSql = new ParkSqlDAL(npGeek);
            List<ParkModel> myParks = parkSql.GetAllParks();
            Assert.IsNotNull(myParks);
            Assert.AreEqual(11, myParks.Count);
        }
            
        
        
        


        
    }





}
