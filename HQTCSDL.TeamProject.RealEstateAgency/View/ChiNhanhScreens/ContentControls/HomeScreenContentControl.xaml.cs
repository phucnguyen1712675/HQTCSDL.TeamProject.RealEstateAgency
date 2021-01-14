using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView.ContentControls;
using System.Windows;
using System.Windows.Controls;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens.ContentControls
{
    /// <summary>
    /// Interaction logic for HomeScreenContentControl.xaml
    /// </summary>
    public partial class HomeScreenContentControl : UserControl
    {
        /*//mảng tạm lưu thông tin đổi yêu cầu nhà của khách hàng
         * Dictionary<int,int> Old_newHouseTypeDemandCustomer
         */


        public HomeScreenContentControl()
        {
            InitializeComponent();
            DataContext = HomeScreenViewModel.Instance;
        }

        private void HouseSearchButton_Click(object sender, RoutedEventArgs e)
        {
            /*gọi refresh lại danh sách nhà*/
            GetHouseByStateComboBox.SelectedIndex = 0;
            HomeScreenViewModel.Instance.GetHousesByIndex(0);
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

        private void HouseListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*get selected house*/
            NHA selectedNha = HouseListComboBox.SelectedItem as NHA;
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GetHouseByStateComboBox.SelectedIndex;
            HomeScreenViewModel.Instance.GetHousesByIndex(index);
        }

        private void ClearSelectedHouseButton_Click(object sender, RoutedEventArgs e)
        {
            NHA selectedNha = new NHA();
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
            HouseListComboBox.SelectedItem = null;
        }

        private void StaffSearchButton_Click(object sender, RoutedEventArgs e)
        {
            HomeScreenViewModel.Instance.GetAllStaffs();
        }

        private void StaffListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NHANVIEN seletedStaff = StaffListComboBox.SelectedItem as NHANVIEN;
            HomeScreenViewModel.Instance.SetSelectedStaff(seletedStaff);
        }

        private void ClearSelectedStaffButton_Click(object sender, RoutedEventArgs e)
        {
            NHANVIEN selectedStaff = new NHANVIEN();
            HomeScreenViewModel.Instance.SetSelectedStaff(selectedStaff);
            StaffListComboBox.SelectedItem = null;
        }
    }
}
