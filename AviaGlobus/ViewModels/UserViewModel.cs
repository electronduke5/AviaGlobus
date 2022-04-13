using AviaGlobus.Models;
using System.Collections.Generic;


namespace AviaGlobus.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public User Admin;

        public FilterUserViewModel FilterUserViewModel { get; set; }
        public SortUserViewModel SortUserViewModel{ get; set; }

    }
}
