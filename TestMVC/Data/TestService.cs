using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestMVC.Interfaces;
using TestMVC.Models;

namespace TestMVC.Data
{
    
    public class TestService
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

         public TestModel ClickCounter()
         {
            
             var testModel = new TestModel();
             using (var conn = new SqlConnection(connStr))
             using (var cmd = conn.CreateCommand())
             {
                 conn.Open();
                 cmd.CommandText = "SELECT ID, ClickCount FROM ButtonClick";
                 int id = 0;
                 using (var reader = cmd.ExecuteReader())
                 {
                     if (!reader.Read())
                     {
                         id = Create();
                         testModel.ID = id;
                         testModel.ClickCount = 1;
                     }
                     else
                     {
                         testModel.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                         testModel.ClickCount = reader.GetInt32(reader.GetOrdinal("ClickCount"));
                         if (testModel.ClickCount < 10)
                         {

                             testModel.ClickCount += 1;
                             Update(testModel);
                         }
                         else return testModel;
                     }
                     
                        
                 }
             }
             return testModel;
         }
        public TestModel Get()
        {
            var testModel =  new TestModel();
                using (var conn = new SqlConnection(connStr))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT ClickCount FROM ButtonClick";
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {

                            return testModel;
                        }
                       

                       testModel.ClickCount = reader.GetInt32(reader.GetOrdinal("ClickCount"));
                       
                    }
                }
                return testModel;
        }

        public int Create()
        {
            var testModel = new TestModel();
            int newID = 0;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "Insert into ButtonClick ( ClickCount) values (1)";
                var commandResult = Convert.ToInt32(cmd.ExecuteScalar());
                if (commandResult != null)
                    newID = Convert.ToInt32(commandResult);
                else
                  newID = testModel.ID;
               
            }
            return newID;
        }
        public void Update(TestModel testModel)
        {
            int newID = 0;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = String.Format("Update ButtonClick set ClickCount = {0} where ID={1}", testModel.ClickCount, testModel.ID);
                var commandResult = cmd.ExecuteScalar();
                if (commandResult != null)
                    newID = Convert.ToInt32(commandResult);
                else
                    newID = testModel.ID;
         

            }

        }
    }
}