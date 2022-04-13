namespace AviaGlobus.ViewModels
{
    public class FilterUserViewModel
    {
        public int? SelectId { get; private set; }

        public string SelectLastname { get; private set; }

        public string SelectLogin { get; private set; }

        public FilterUserViewModel (int? id, string lastname, string login)
        {
            SelectId = id;
            SelectLastname = lastname;
            SelectLogin = login;
        }
    }
}