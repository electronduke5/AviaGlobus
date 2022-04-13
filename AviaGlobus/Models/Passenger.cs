using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviaGlobus.Models
{
    public class Passenger
    {
        [Key]
        public int ID_Passenger { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string? Patronymic { get; set; }
        [Required]
        public string Passport_Series { get; set; }
        [Required]
        public string Passport_Number { get; set; }
        
        public int Passport_Type_ID { get; set; }

        [ForeignKey("Passport_Type_ID")]
        public PassportType PassportType { get; set; }

        public int Flight_ID { get; set; }
        
        [ForeignKey("Flight_ID")]
        public Flight Flight { get; set; }
    }   
}