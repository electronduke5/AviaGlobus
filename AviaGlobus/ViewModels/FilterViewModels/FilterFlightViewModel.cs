namespace AviaGlobus.ViewModels
{
    public class FilterFlightViewModel
    {
        public int? SelectId { get; private set; }

        public string SelectDeparturePoint { get; private set; }

        public string SelectArrivalPoint { get; private set; }

        public FilterFlightViewModel(int? id, string departurePoint, string arrivalPoint)
        {
            SelectId = id;
            SelectDeparturePoint = departurePoint;
            SelectArrivalPoint = arrivalPoint;
        }
    }
}