using System.Windows;
using System.Windows.Controls;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChuNhaScreens.ContentControls
{
    /// <summary>
    /// Interaction logic for HomeScreenContentControl.xaml
    /// </summary>
    public partial class HomeScreenContentControl : UserControl
    {
        public HomeScreenContentControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void HouseUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*cập nhập nhà
             nếu tình trạng bị đổi => gọi procedure_updatehosuestate
             nếu loại nhà đổi => gọi procedure_changeHouseType*/
        }

        private void HouseAddButon_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_addNEwHouseForRent*/
        }

        private void HouseDeteleButon_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_deleteHouse*/
        }
    }
}
