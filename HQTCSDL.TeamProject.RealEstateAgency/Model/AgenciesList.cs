using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class AgenciesList
    {
        private ObservableCollection<Agency> agenciesCollection { get; set; }

        public AgenciesList()
        {
            CreateAgenciesCollection();
        }

        public ObservableCollection<Agency> GetAgenciesCollection()
            => this.agenciesCollection;

        private void CreateAgenciesCollection()
        {
            this.agenciesCollection = new ObservableCollection<Agency>();

            //Fake data
            for (int i = 0; i < 15; i++)
            {
                this.agenciesCollection.Add(new Agency
                {
                    AgencyId = i + 1,
                    Fax = "123456789",
                    PhoneNumber = "0985897654",
                    Address = "HCMUS"
                });
            }
        }
    }
}
