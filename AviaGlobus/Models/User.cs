using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviaGlobus.Models
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string? Patronymic { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int Role_ID { get; set; }
        
        [ForeignKey("Role_ID")]
        public Role Role { get; set; }
    }

    public enum SortState
    {
        IdAsc,
        IdDesc,
        LastnameAsc,
        LastnameDesc,
        LoginAsc,
        LoginDesc
    }
}