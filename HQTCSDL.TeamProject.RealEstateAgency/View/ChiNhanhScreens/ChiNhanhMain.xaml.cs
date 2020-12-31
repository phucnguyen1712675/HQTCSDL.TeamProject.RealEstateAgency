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

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChiNhanhMain : MetroWindow
    {
        /*//mảng tạm lưu thông tin đổi yêu cầu nhà của khách hàng
         * Dictionary<int,int> Old_newHouseTypeDemandCustomer 
         */
        public ChiNhanhMain()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void HouseSearchButton_Click(object sender, RoutedEventArgs e)
        {
            /*gọi refresh lại danh sách nhà*/
        }

        private void OKUpdatePriceAllHouseOfTypeButton_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_ÍPriceIncresases
             trả kết quả vào window kết quả chạy Agency_IsHosueTypeInscreases*/
        }

        private void OKSearchHouseByTypeButton_Click(object sender, RoutedEventArgs e)
        {
            /* 
             * var temp = (HouseType2Combox.SelectedValue as LOAINHA).MALOAI
             * lấy mã loại nhà cần search ra
             * gọi procedure_GetcustomerSuitableHouse
             * trả kết quả vào window SearchHouseByHouseType request
             */
        }

        private void HouseUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*cập nhập nhà 
             nếu tình trạng bị đổi => gọi procedure_updatehosuestate
             nếu loại nhà đổi => gọi procedure_changeHouseType*/
        }

        private void UpdateHouseTypeRequestCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * chạy thằng Old_newHouseTypeDemandCustomer[0]
             * gọi procedure_UpdateCustomerDemand
             */
        }

        private void StaffUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*
             * update lương nhân viên thôi
             * gọi procedure_UpdateSalaryStaff
             */
        }
    }
}
