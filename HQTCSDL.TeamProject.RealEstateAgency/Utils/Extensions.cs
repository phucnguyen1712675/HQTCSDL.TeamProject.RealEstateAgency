using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.Utils
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col) => new ObservableCollection<T>(col);
    }
}
