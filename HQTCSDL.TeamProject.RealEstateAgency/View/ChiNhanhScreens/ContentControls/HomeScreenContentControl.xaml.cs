using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView.ContentControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens.ContentControls
{
    /// <summary>
    /// Interaction logic for HomeScreenContentControl.xaml
    /// </summary>
    public partial class HomeScreenContentControl : UserControl
    {
        /*
         0 : update loainha
         1 : update giá thuê
         */
        public int ProcedureUpdateToCall;

        public HomeScreenContentControl()
        {
            InitializeComponent();
            DataContext = HomeScreenViewModel.Instance;
        }

        #region HouseTranhChap
        private void OKUpdatePriceAllHouseOfTypeButton_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_ÍPriceIncresases
             trả kết quả vào window kết quả chạy Agency_IsHosueTypeInscreases
             */
            int SoLuong = int.Parse(HouseTypeNumberTextBox.Text);
            float PhanTram = int.Parse(HouseTypePriceUpTextBox.Text)/100;
            int MaCN = HomeScreenViewModel.Instance.MACN;
            HomeScreenViewModel.Instance.UpdateHousePriceIfYes(SoLuong, PhanTram);
        }

        private void OKSearchHouseByTypeButton_Click(object sender, RoutedEventArgs e)
        {
            //t1: 4, 6
            int MaLoai = (HouseType2Combox.SelectedItem as LOAINHA).MALOAI;
            HomeScreenViewModel.Instance.GetHouseSuitable(MaLoai);
        }

        private void HouseUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*cập nhập nhà
             0 => gọi cập nhập loại nhà
             1 => gọi cập nhập giá thuê
            TODO*/
            if (ProcedureUpdateToCall == 0)
            {
                HomeScreenViewModel.Instance.updateHouseTypeInHouse();
            }
            else if (ProcedureUpdateToCall == 1)
            {
                HomeScreenViewModel.Instance.updateHousePriceInHouseRent();
            }
        }
        #endregion

        #region StaffTranhChap
        private void StaffUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*
             * update lương nhân viên thôi
             * gọi procedure_UpdateSalaryStaff
             * TODO
             */
            /*double NewLuong = double.Parse(StaffSalaryTextBox.Text);
            int MaNV = Convert.ToInt32(StaffCodeLable.Content);*/
            HomeScreenViewModel.Instance.UpdateStaffSalary();
        }
        #endregion

        #region CustomerTranhChap
        private void UpdateHouseTypeRequestCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * chạy thằng Old_newHouseTypeDemandCustomer[0]
             * gọi procedure_UpdateCustomerDemand
             */
            //truyền thẳng vào cửa số mới Agency_customerNewHouseTypeRequest
            HomeScreenViewModel.Instance.UpdateOldNewHousetypeRequest();
        }
        #endregion

        #region supportMethod
        private void HouseSearchButton_Click(object sender, RoutedEventArgs e)
        {
            GetHouseByStateComboBox.SelectedIndex = 0;
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                HouseListDataGrid.ItemsSource = db.USP_TEST_AGENCY_GetHouse(HomeScreenViewModel.Instance.MACN);
            }
        }

        private void HouseListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*get selectedHouse trong thêm /xóa/ sửa nhà */
            NHA selectedNha = HouseListComboBox.SelectedItem as NHA;
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
        }

        private void ClearSelectedHouseButton_Click(object sender, RoutedEventArgs e)
        {
            /* set selectedHouse null */
            NHA selectedNha = new NHA();
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
            HouseListComboBox.SelectedItem = null;
        }

        private void StaffSearchButton_Click(object sender, RoutedEventArgs e)
        {
            /*gọi refresh get all lại danh sách nhân viên*/
            HomeScreenViewModel.Instance.GetAllStaffs();
        }

        private void StaffListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*lấy selectedStaff trong thêm xóa/sửa/thêm */
            NHANVIEN seletedStaff = StaffListComboBox.SelectedItem as NHANVIEN;
            HomeScreenViewModel.Instance.SetSelectedStaff(seletedStaff);
        }

        private void ClearSelectedStaffButton_Click(object sender, RoutedEventArgs e)
        {
            /*set selectedStaff = null*/
            NHANVIEN selectedStaff = new NHANVIEN();
            HomeScreenViewModel.Instance.SetSelectedStaff(selectedStaff);
            StaffListComboBox.SelectedItem = null;
        }

        private void HouseTypeCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProcedureUpdateToCall = 0;
        }

        private void HouseTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcedureUpdateToCall = 1;
        }

        private void UpdateHouseTypeRequestcustomerButton_Click_1(object sender, RoutedEventArgs e)
        {
            int oldType = (CustomerRequestHouseTypesListComboBox.SelectedItem as YEUCAU).LOAINHAYEUCAU;
            int newType = (SelectNewHouseTypeRequestCustomer.SelectedItem as LOAINHA).MALOAI;
            HomeScreenViewModel.Instance.AddOldNewHouseRequest(oldType, newType);
        }

        private void ClearSelectedCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerListComboBox.SelectedItem = null;
            HomeScreenViewModel.Instance.SetSelectedCustomer(new KHACHHANG());
        }

        private void CustomerListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KHACHHANG SelectedCustomer = CustomerListComboBox.SelectedItem as KHACHHANG;
            HomeScreenViewModel.Instance.SetSelectedCustomer(SelectedCustomer);
        }

        private void HouseTypeTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (HouseTypeTextBox.Text == "1" || HouseTypeTextBox.Text == "0")
            {
                HomeScreenViewModel.Instance.SetHouseRentOrSale(HouseTypeTextBox.Text);
            }
        }
        #endregion
    }
}
