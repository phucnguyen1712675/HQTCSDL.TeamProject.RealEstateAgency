using HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView.ContentControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChuNhaScreens.ContentControls
{
    /// <summary>
    /// Interaction logic for HomeScreenContentControl.xaml
    /// </summary>
    public partial class HomeScreenContentControl : UserControl
    {
        /*
         0 : update loainha
         1 : update Đăng lại
         */
        public int ProcedureUpdateToCall;

        public HomeScreenContentControl()
        {
            InitializeComponent();
            DataContext = HomeScreenViewModel.Instance;
        }

        private void HouseUpdateButon_Click(object sender, RoutedEventArgs e)
        {
            /*cập nhập nhà
             nếu tình trạng bị đổi => gọi procedure_updatehosuestate
             nếu loại nhà đổi => gọi procedure_changeHouseType*/
            if (ProcedureUpdateToCall == 0)
            {
                int NewLoaiNha = (HouseTypeCombox.SelectedItem as LOAINHA).MALOAI;
                int MaNha = Convert.ToInt32(HouseCodeLable.Content);
                HomeScreenViewModel.Instance.updateHouseHouseType(MaNha, NewLoaiNha);
            }
            else if (ProcedureUpdateToCall == 1)
            {
                HomeScreenViewModel.Instance.UpdateStateHouse();
            }
        }

        private void HouseAddButon_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_addNEwHouseForRent*/
            HomeScreenViewModel.Instance.AddNewHouseForRent();
        }

        private void HouseDeteleButon_Click(object sender, RoutedEventArgs e)
        {
            /*gọi procedure_deleteHouse*/
            int MaNha = Convert.ToInt32(HouseCodeLable.Content);
            HomeScreenViewModel.Instance.DeleteHouse(MaNha);
        }

        #region supportMethod
        private void HouseSearchButton_Click(object sender, RoutedEventArgs e)
        {
            HomeScreenViewModel.Instance.GetAllHouseAgain();
        }

        private void HouseListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*get selectedHouse trong thêm /xóa/ sửa nhà */
            NHA selectedNha = HouseListComboBox.SelectedItem as NHA;
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
        }

        private void ClearSelectedHouseButton_Click(object sender, RoutedEventArgs e)
        {
            NHA selectedNha = new NHA();
            HomeScreenViewModel.Instance.SetSelectedHouse(selectedNha);
            HouseListComboBox.SelectedItem = null;
        }

        private void HouseTypeCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProcedureUpdateToCall = 0;
        }

        private void HouseStateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcedureUpdateToCall = 1;
        }
        #endregion

        private void HouseTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HouseTypeTextBox.Text == "1" || HouseTypeTextBox.Text == "0")
            {
                HomeScreenViewModel.Instance.SetHouseRentOrSale(HouseTypeTextBox.Text);
            }
        }
    }
}
