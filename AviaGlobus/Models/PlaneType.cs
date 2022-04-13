using System.ComponentModel.DataAnnotations;

namespace AviaGlobus.Models
{
    public class PlaneType
    {
        [Key]
        public int ID_Type{ get; set; }

        public string Title { get; set; }
    }
}