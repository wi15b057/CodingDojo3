using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodingDojo3.ViewModel;
using CodingDojo3.Command;
using System.ComponentModel;

namespace CodingDojo3.ViewModel
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();
        private StockEntryViewModel selectedItem;
        private Array currencies;
        private Currencies selectedCurrency;
        public RelayCommand OnButtonClickedCommand { get; set; }


        public ObservableCollection<StockEntryViewModel> Items
        {
            get { return items; }
            set { items = value; }
        }

        public StockEntryViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnChange("SelectedItem");
            }
        }

        public Array Currencies
        {
            get { return Enum.GetValues(typeof(CodingDojo4DataLib.Converter.Currencies)); }
            set { currencies = value; }
        }

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnChange("SelectedCurrency");
                this.DoCalculation();
            }
        }

        private void DoCalculation()
        {
            foreach (var item in Items)
            {
                item.CalculateSalesPriceFromEuro(SelectedCurrency);
                item.CalculatePurchasePriceFromEuro(SelectedCurrency);
            }
        }

        public MainViewModel()
        {
            SampleManager manager = new SampleManager();

            foreach (var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryViewModel(item));

            }

            OnButtonClickedCommand = new RelayCommand(
                new Action(DoItOnButtonClick),
                new Func<bool>(CanExecuteButton));
        }

        private bool CanExecuteButton()
        {
            if (selectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DoItOnButtonClick()
        {
            items.Remove(SelectedItem);
        }


        public RelayCommand OnButtonClickCommand
        {
            get { return OnButtonClickCommand; }
            set
            {
                onButtonClickCommand = value;
            }
        }

        public RelayCommand EditButtonCommand
         {
             get { return EditButtonCommand; }
             set
             {
                editButtonCommand = value;
             }
         }

        public RelayCommand DeleteButtonCommand
         {
             get { return DeleteButtonCommand; }
             set
             {
                deleteButtonCommand = value;
             }
         }

        public RelayCommand AddButtonCommand
         {
             get { return AddButtonCommand; }
             set
             {
                 addButtonCommand = value;
             }
         }

        public String Message
         {
             get { return message; }
             set { message = value; OnChange("next implementation"); }
         }

        private String output;
        private RelayCommand addButtonCommand;
        private RelayCommand deleteButtonCommand;
        private RelayCommand editButtonCommand;
        private RelayCommand onButtonClickCommand;
        private string message;

        public bool IsClickable { get; set; }


        public String Output
         {
             get { return output; }
             set
             {
                 output = value;
                 OnChange("Output");
             }
         }
    }
}