using Cognology.FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognology.FlightApp.Repository
{
    public interface IFlightsRepository
    {
        IEnumerable<Flight> GetFlights();
    }
}
