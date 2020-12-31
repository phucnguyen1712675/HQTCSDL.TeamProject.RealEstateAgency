using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChuNhaScreens
{
    /// <summary>
    /// Interaction logic for ChuNhaMain.xaml
    /// </summary>
    public partial class ChuNhaMain : MetroWindow
    {
        public ChuNhaMain()
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
