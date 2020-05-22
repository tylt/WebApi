using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using Dapper;
using System.Data.SqlClient;
using Hangfire;

namespace WebApi.Service
{
    public class DoctorService
    {
        private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [AutomaticRetry(Attempts = 3)]
        public static void PopulateList()
        {
            DoctorSingletonTest obj = DoctorSingletonTest.GetInstance();
            obj.DoctorList = GetDoctors();
        }

        private static List<DoctorSingletonTest> GetDoctors()
        {
            List<DoctorSingletonTest> responseList = new List<DoctorSingletonTest>();
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    con.Open();

                    responseList = con.Query<DoctorSingletonTest>("Select DISTINCT Employee_Id Id, " +
                        " Employee_Name FullName, Employee_Email Email  " +
                        " from JS.Contract", 
                        null, 
                        commandType: System.Data.CommandType.Text)
                        .AsEnumerable().ToList();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return responseList;
        }
    }
}