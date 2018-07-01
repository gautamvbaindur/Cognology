using Cognology.FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Cognology.FlightApp.Repository
{
    public class FlightsRepository : IFlightsRepository
    {
        private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Cognology\Cognology.FlightApp\Cognology.FlightApp\App_Data\Cognology.mdf;Integrated Security=True";

        public IEnumerable<Flight> GetFlights()
        {
            var list = new List<Flight>();
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = connString;
                    connection.Open();
                    var command = new SqlCommand($"Select * from flights", connection);
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        list.Add(new Flight { Id = Convert.ToInt32(result[0]), PassengerCapacity = Convert.ToInt32(result[4]) , FlightNumber = Convert.ToString(result[1]), StartTime = Convert.ToDateTime(result[2]), EndTime = Convert.ToDateTime(result[3]) });
                    }
                    connection.Close();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}