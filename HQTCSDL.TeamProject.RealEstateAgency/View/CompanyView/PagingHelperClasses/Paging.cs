using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.PagingHelperClasses
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int RowsPerPage { get; set; } = 1;

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages; set
            {
                _totalPages = value;
                Pages = new List<PageInfo>();
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
        public List<PageInfo> Pages { get; set; }
    }
}
