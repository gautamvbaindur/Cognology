using System;
using System.ComponentModel.DataAnnotations;

namespace Cognology.FlightApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCapacity { get; set; }
        public int AvailableSeats { get; set; }
        [Required]
        public string DepartureCity { get; set; }
        [Required]
        public string ArrivalCity { get; set; }
    }
}