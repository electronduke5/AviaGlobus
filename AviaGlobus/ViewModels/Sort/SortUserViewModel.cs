using AviaGlobus.Models;

namespace AviaGlobus.ViewModels
{
    public class SortUserViewModel
    {
        public SortState IdSort { get; private set; }
        
        public SortState LastnameSort { get; private set; }

        public SortState LoginSort { get; private set; }

        public SortState Current { get; private set; }

        public SortUserViewModel(SortState sortOrder)
        {
            IdSort = sortOrder == SortState.IdAsc ?
               SortState.IdDesc : SortState.IdAsc;

            LastnameSort = sortOrder == SortState.LastnameAsc ?
               SortState.LastnameDesc: SortState.LastnameAsc;

            LoginSort = sortOrder == SortState.LoginAsc ?
                SortState.LoginDesc : SortState.LoginAsc;

            Current = sortOrder;
        }
    }
}