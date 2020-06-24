using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ResidentialComplex.BusinessLayer.DomainModel;

namespace ResidentialComplex.PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BusyFlat : Window
    {
        public bool IsClosed { get; set; } = false;
        //private BusyFlat busyFlat;
        // private HeadOfOSBBPresenter presenter;
        private Tariff tariff; 

        public BusyFlat()
        {
            InitializeComponent();
           // presenter = new HeadOfOSBBPresenter(this, model);
           //tariff = new Tariff(presenter.GetHousingDepartaments());
        }

        //public void AddPresenter(HeadOfOSBBPresenter presenter)
        //{
        //    this.presenter = presenter;
        //    this.presenter.AddView(this);
        //}

        //public void AddModel(HeadOfOSBB model)
        //{
        //    presenter.AddModel(model);
        //}

    //    #region IBusyFlat interface implementation
    //    public void SetHousesNames(HashSet<int> housesNumber)
    //    {
    //        ComboBoxFlatChoise.ItemsSource = housesNumber;
    //    }

    //    public void SetFlatRows(List<Flat> flats)
    //    {
    //        DataGridAvailableFlatsList.ItemsSource = flats;
    //    }

    //    public void SetHousingDepartamentRows(List<HousingDepartament> housingDepartaments)
    //    {
    //        //if (tariff == null)
    //           // tariff = new Tariff(presenter.GetHousingDepartaments());
    //        tariff.DataGridHouses.ItemsSource = housingDepartaments;
    //    }
    //     #endregion

    private void ButtonTariffCalculation_Click(object sender, RoutedEventArgs e)
        {
    //        Flat flat = (Flat)DataGridAvailableFlatsList.SelectedItem;
    //        //if(presenter != null)
    //            presenter.BusyFlat_TariffCalculation(120, "Passed", flat);
        }

        private void ComboBoxOwnChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    //        //if(presenter != null )
    //            presenter.BusyFlat_OwnNameChanged((int)((ComboBox)sender).SelectedValue);
        }

        private void ButtonViewTariffs_Click(object sender, RoutedEventArgs e)
        {
    //        tariff.Show();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
              Tag = true;
        }

        private void DataGridAvailableFlatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
