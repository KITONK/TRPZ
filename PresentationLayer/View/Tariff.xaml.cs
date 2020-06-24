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
using Models;

namespace PresentationLayer.View
{
    /// <summary>
    /// Логика взаимодействия для Tariff.xaml
    /// </summary>
    public partial class Tariff : Window
    {
        public Tariff()
        {
            InitializeComponent();
        }

        private void DataGridHouses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flat selectedFlat = ((HousingDepartament)DataGridHouses.SelectedItem).Flat;
            //TextBlockNumberOfHouse.Text = selectedFlat.NumberOfHouse.ToString();
            TextBlockAddress.Text = selectedFlat.House.Address;
            TextBlockPhoneNumber.Text = selectedFlat.Owner.PhoneNumber;
            TextBlockDateOfPurchase.Text = selectedFlat.Owner.DateOfPurchase.ToString();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
