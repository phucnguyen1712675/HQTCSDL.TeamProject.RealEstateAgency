using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class HouseCategoriesList
    {
        private ObservableCollection<HouseCategory> houseCategoriesCollection { get; set; }

        public HouseCategoriesList()
        {
            CreateHouseCategoriesList();
        }

        private void CreateHouseCategoriesList()
        {
            this.houseCategoriesCollection = new ObservableCollection<HouseCategory>()
            {
                new HouseCategory
                {
                    KindsOfHouseID = 1,
                    Name ="Nhà 1 lầu"
                },
                new HouseCategory
                {
                    KindsOfHouseID = 2,
                    Name ="Nhà 2 lầu"
                },
                new HouseCategory
                {
                    KindsOfHouseID = 3,
                    Name ="Nhà 3 lầu"
                },
                new HouseCategory
                {
                    KindsOfHouseID = 4,
                    Name ="Nhà chung cư"
                },
                new HouseCategory
                {
                    KindsOfHouseID = 5,
                    Name ="Nhà trọ"
                },
                new HouseCategory
                {
                    KindsOfHouseID = 6,
                    Name ="Nhà thổ cư"
                },
            };
        }

        public ObservableCollection<HouseCategory> GetHouseCategoriesList()
            => this.houseCategoriesCollection;
    }
}
