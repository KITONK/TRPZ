using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Abstract;
using PresentationLayer.View;

namespace PresentationLayer.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        //private readonly IOwnerService ownerService;
        private readonly IHousingDepartamentService housingDepartamentService;
        private readonly IFlatService flatService;
        private readonly IHouseTypeService houseTypeService;
        private Tariff tariff;
        private ObservableCollection<HouseType> houseTypes;
        private ObservableCollection<Flat> flats;
        private ObservableCollection<HousingDepartament> housingDepartaments;
        private HouseType selectedHouseType;
        private Flat selectedFlat;
        private string name;
        private float pay;

        public ObservableCollection<HouseType> HouseTypes
        {
            get => houseTypes;
            set
            {
                houseTypes = value;
                OnPropertyChanged("HouseTypes");
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

        public HouseType SelectedHouseType
        {
            get => selectedHouseType;
            set
            {
                selectedHouseType = value;
                OnPropertyChanged("SelectedHouseType");

                Flats = new ObservableCollection<Flat>(flatService.GetFlatsByHouseTypeId(selectedHouseType.Id));
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

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public float Pay
        {
            get => pay;
            set
            {
                pay = value;
                OnPropertyChanged("Pay");
            }
        }

        private RelayCommand tariffCalculationCommand;
        public RelayCommand TariffCalculation
        {
            get
            {
                return tariffCalculationCommand ?? (tariffCalculationCommand = new RelayCommand(obj =>
                {
                    Pay = Pay * selectedFlat.Area;
                    var newTariff = new HousingDepartament(Pay, Name, SelectedFlat);
                    HousingDepartaments.Add(newTariff);
                    housingDepartamentService.SaveTariff(newTariff);
                    App.ShowMessage("Тариф успешно создан!");
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

        public ApplicationViewModel(IHousingDepartamentService housingDepartamentService, IFlatService flatService, IHouseTypeService houseTypeService)
        {
            this.houseTypeService = houseTypeService;
            this.housingDepartamentService = housingDepartamentService;
            this.flatService = flatService;
            HouseTypes = new ObservableCollection<HouseType>(houseTypeService.GetAllHouseTypes());
            HousingDepartaments = new ObservableCollection<HousingDepartament>(housingDepartamentService.GetHousingDepartaments());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
