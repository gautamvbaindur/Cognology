using Cognology.FlightApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cognology.FlightApp.Controllers
{
    [RoutePrefix("api/flights")]
    public class FlightsController : ApiController
    {
        private IFlightsRepository _flightsRepository;

        public FlightsController(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;      
        }

        [HttpGet]
        [Route("availability")]
        public IHttpActionResult CheckAvailability(string from,
          string to, int pax)
        {

            var flights = _flightsRepository.GetFlights();
            if (flights == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No flights found"),
                    ReasonPhrase = "No flights found"
                };
                throw new HttpResponseException(resp);
            }
            flights = flights.Where(f => f.StartTime > Convert.ToDateTime(from));

            flights = flights.Where(f => f.EndTime <= Convert.ToDateTime(to));

            flights = flights.Where(x => x.PassengerCapacity >= pax);
            return Ok(flights);
        }
    }
}
