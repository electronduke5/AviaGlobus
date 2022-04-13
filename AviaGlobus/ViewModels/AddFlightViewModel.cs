using AviaGlobus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AviaGlobus.ViewModels
{
    public class AddFlightViewModel
    {
        public int ID { get; set; }

        //[Required(ErrorMessage = "Это обязательное поле!")]
        [Range (minimum:1000, maximum: int.MaxValue, ErrorMessage = "Цена должна быть более 1000!")]
        public decimal? Ticket_Cost { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        //[Range(typeof(DateTime), "27/01/2022", "31/12/2024", ErrorMessage = "Проверьте дату!")]
        [DataType(DataType.Date)]
        public DateTime Departure_Date { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "27/01/2022", "31/12/2023", ErrorMessage = "Проверьте дату!")]
        public DateTime Arrival_Date { get; set; }

        //[Required(ErrorMessage = "Это обязательное поле!")]
        public string Departure_Time { get; set; }
        
        //[Required(ErrorMessage = "Это обязательное поле!")]
        public string Arrival_Time { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[А-Яа-яёЁ-]+$", ErrorMessage = "Только русские символы!")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Проверьте количество символов!")]
        public string Departure_Point { get; set; }

        [RegularExpression(@"^[А-Яа-яёЁ-]+$", ErrorMessage = "Только русские символы!")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Проверьте количество символов!")]
        public string? Transfer_Point { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[А-Яа-яёЁ-]+$", ErrorMessage = "Только русские символы!")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Проверьте количество символов!")]
        public string Arrival_Point { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        public int Places_Left { get; set; }

        public int Status_ID { get; set; }

        public int Plane_Type_ID { get; set; }

        public int Flight_Type_ID { get; set; }

        public IEnumerable<FlightType> FlightTypes { get; set; }
        public IEnumerable<PlaneType> PlaneTypes { get; set; }
        public IEnumerable<Status> Statuses { get; set; }

        public User LoggedUser { get; set; }
    }
}
