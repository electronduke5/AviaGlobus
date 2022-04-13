using AviaGlobus.Models;

namespace AviaGlobus.ViewModels
{
    public class SortFlightViewModel
    {
        public SortStateFlight IdSort { get; private set; }

        public SortStateFlight DepartureDateSort { get; private set; }
        
        public SortStateFlight DeparturePointSort { get; private set; }

        public SortStateFlight ArrivalPointSort { get; private set; }

        public SortFlightViewModel(SortStateFlight sortOrder)
        {
            IdSort = sortOrder == SortStateFlight.IdAsc ?
               SortStateFlight.IdDesc : SortStateFlight.IdAsc;

            DepartureDateSort = sortOrder == SortStateFlight.DepartureDateAsc ?
                SortStateFlight.DepartureDateDesc : SortStateFlight.DepartureDateAsc;

            DeparturePointSort = sortOrder == SortStateFlight.DeparturePointAsc?
                SortStateFlight.DeparturePointDesc : SortStateFlight.DeparturePointAsc;

            ArrivalPointSort = sortOrder == SortStateFlight.ArrivalPointAsc?
                SortStateFlight.ArrivalPointDesc : SortStateFlight.ArrivalPointAsc;
        }
    }
}