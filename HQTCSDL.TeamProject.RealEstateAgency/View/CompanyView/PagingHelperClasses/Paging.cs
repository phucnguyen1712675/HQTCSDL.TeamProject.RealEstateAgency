using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.PagingHelperClasses
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int RowsPerPage { get; set; }

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages; set
            {
                _totalPages = value;

                Pages = new ObservableCollection<PageInfo>();

                for (int i = 1; i <= _totalPages; i++)
                {
                    Pages.Add(new PageInfo()
                    {
                        Page = i,
                        TotalPages = _totalPages
                    });
                }
            }
        }

        public Paging()
        {
            this.RowsPerPage = 1;
        }

        public ObservableCollection<PageInfo> Pages { get; set; }
    }
}
