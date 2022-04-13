using AviaGlobus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviaGlobus.ViewModels
{
    public class FlightsViewModel
    {
        public IEnumerable<Flight> Flight { get; set; }
        public IEnumerable<FlightType> FlightTypes{ get; set; }
        public IEnumerable<PlaneType> PlaneTypes{ get; set; }
        public IEnumerable<Status> Statuses{ get; set; }

        public SortFlightViewModel SortFlightViewModel { get; set; }
        public FilterFlightViewModel FilterFlightViewModel { get; set; }

        public User Admin { get; set; }
    }
}
