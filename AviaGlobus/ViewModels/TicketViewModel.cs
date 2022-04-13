using AviaGlobus.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviaGlobus.ViewModels
{
    public class TicketViewModel
    {
        public IEnumerable<Flight> Flight { get; set; }
        public IEnumerable<Passenger> Passenger { get; set; }
        public IEnumerable<PassportType> PassportType{ get; set; }

        public Flight SelectFlight { get; set; }
            
        public int ID_Flyght { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Имя должно содержать только русские символы!")]
        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "Проверьте количесвто символов в фамилии!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Фамилия должна содержать только русские символы!")]
        [StringLength(maximumLength:30,MinimumLength = 1, ErrorMessage ="Проверьте количесвто символов в фамилии!")]
        public string Lastname{ get; set; }

        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Отчество должно содержать только русские символы!")]
        [StringLength(maximumLength: 30, ErrorMessage = "Отчество слишком длинное!")]
        public string Patronymic { get; set; }
        public int PassportType_ID { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [StringLength(maximumLength: 4, MinimumLength = 2, ErrorMessage = "Проверьте количество цифр!")]
        public string Passport_Series { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [StringLength(maximumLength: 7, MinimumLength = 6 , ErrorMessage = "Проверьте количество цифр!")]
        public string Passport_Number { get; set; }

        public int Flight_ID { get; set; }

        public User LoggedUser { get; set; }
    }
}