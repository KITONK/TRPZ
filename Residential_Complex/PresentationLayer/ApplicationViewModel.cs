using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.BusinessLayer.Services;
using ResidentialComplex;

namespace ResidentialComplex.PresentationLayer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        //private readonly IOwnerService ownerService;
        private readonly IHousingDepartamentService housingDepartamentService;
        private readonly IFlatService flatService;
        private readonly IHouseService houseService;
        private Tariff tariff;
        private ObservableCollection<int> houseName;
        private ObservableCollection<Flat> flats;
        private ObservableCollection<HousingDepartament> housingDepartaments;
        private int selectedHouseNumber;
        private Flat selectedFlat;
        private bool isClosed = false;

        public ObservableCollection<int> HouseName
        {
            get => houseName;
            set
            {
                houseName = value;
                OnPropertyChanged("HouseName");
            }
        }

        public ObservableCollection<Flat> Flats
        {
            get => flats;
            set
            {
                flats = value;
                OnPropertyChanged("Flats");
            }
        }

        public ObservableCollection<HousingDepartament> HousingDepartaments
        {
            get => housingDepartaments;
            set
            {
                housingDepartaments = value;
                OnPropertyChanged("HousingDepartaments");
            }
        }

        public int SelectedHouseNumber
        {
            get => selectedHouseNumber;
            set
            {
                selectedHouseNumber = value;
                OnPropertyChanged("SelectedHouseNumber");

                Flats = new ObservableCollection<Flat>(flatService.GetFlats(selectedHouseNumber));
            }
        }

        public Flat SelectedFlat
        {
            get => selectedFlat;
            set
            {
                selectedFlat = value;
                OnPropertyChanged("SelectedFlat");
            }
        }

        public bool IsClosed
        {
            get => isClosed;
            set
            {
                isClosed = value;
                if (isClosed == true)
                    housingDepartamentService.SaveTariffs(HousingDepartaments);
                OnPropertyChanged("IsClosed");
            }
        }

        private RelayCommand tariffCalculationCommand;
        public RelayCommand TariffCalculation
        {
            get
            {
                return tariffCalculationCommand ?? (tariffCalculationCommand = new RelayCommand(obj =>
                {
                    HousingDepartaments.Add(new HousingDepartament(20, "Pol", selectedFlat));
                }));
            }
        }

        private RelayCommand viewTariffsCommand;
        public RelayCommand ViewTariffsCommand
        {
            get
            {
                return viewTariffsCommand ?? (viewTariffsCommand = new RelayCommand(obj =>
                {
                    tariff = tariff ?? new Tariff();
                    tariff.DataGridHouses.ItemsSource = HousingDepartaments;
                    tariff.Show();
                }));
            }
        }

        public ApplicationViewModel(IHousingDepartamentService housingDepartamentService, IFlatService flatService, IHouseService houseService)
        {
            //this.ownerService = ownerService;
            this.houseService = houseService;
            this.housingDepartamentService = housingDepartamentService;
            this.flatService = flatService;
            var _ = houseService.GetNumberOfHouse();
            HouseName = new ObservableCollection<int>(houseService.GetNumberOfHouse());
            HousingDepartaments = new ObservableCollection<HousingDepartament>(housingDepartamentService.GetHousingDepartaments());
        }

        //~ApplicationViewModel()
        //{
        //    housingDepartamentService.SaveTariffs(HousingDepartaments.ToList());
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
