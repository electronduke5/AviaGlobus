using System;
using System.ComponentModel.DataAnnotations;

namespace AviaGlobus.Models
{
    public class Flight
    {
        [Key]
        public int ID_Flight { get; set; }

        public decimal? Ticket_Cost { get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival_Date { get; set; }

        public string Departure_Time { get; set; }
        
        public string Arrival_Time { get; set; }

        public string Departure_Point { get; set; }
        
        public string? Transfer_Point { get; set; }
        
        public string Arrival_Point { get; set; }

        public int Places_Left { get; set; }

        public int Status_ID { get; set; }
        
        public int Plane_Type_ID { get; set; }

        public int Flight_Type_ID { get; set; }
    }
    public enum SortStateFlight
    {
        IdAsc,
        IdDesc,
        DepartureDateAsc,
        DepartureDateDesc,
        DeparturePointAsc,
        DeparturePointDesc,
        ArrivalPointAsc,
        ArrivalPointDesc
    }
}