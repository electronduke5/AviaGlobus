using System.ComponentModel.DataAnnotations;

namespace AviaGlobus.Models
{
    public class Status
    {
        [Key]
        public int ID_Status { get; set; }

        public string Title { get; set; }
    }
}