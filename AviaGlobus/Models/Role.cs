using System.ComponentModel.DataAnnotations;

namespace AviaGlobus.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
    }
}