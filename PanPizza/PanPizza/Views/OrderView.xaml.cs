using PanPizza.Models;
using PanPizza.ViewsModel;
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

namespace PanPizza.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        private bool isValidSize;
        private bool isValidChecked;
        OrderViewModel orderViewModel;

        public OrderView()
        {
            InitializeComponent();
            orderViewModel = new OrderViewModel(this);
            this.DataContext = orderViewModel;

        }

        private void IsCalculatingEnabled()
        {
            if (isValidSize && isValidChecked)
            {
                btnCalculate.IsEnabled = true;
            }
            else
            {
                btnCalculate.IsEnabled = false;
            }
        }


        private void cmbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSize.SelectedItem == null)
            {
                cmbSize.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbSize.Foreground = new SolidColorBrush(Colors.Red);
                isValidSize = false;
            }
            else
            {
                cmbSize.BorderBrush = new SolidColorBrush(Colors.Black);
                cmbSize.Foreground = new SolidColorBrush(Colors.Black);
                isValidSize = true;
            }
            IsCalculatingEnabled();
        }

        private void cxbChoosenIngridienc_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Ingredients ingredients in orderViewModel.IngredientsList)
            {
                if (ingredients.IsChecked)
                {
                    isValidChecked = true;
                    break;
                }
            }
            IsCalculatingEnabled();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            orderViewModel.CalculateAmountSaveExecute();

            if (orderViewModel.TotalAmount > 0)
            {
                DataGridResults.IsEnabled = false;
                cmbSize.IsEditable = false;
                isValidSize = false;
                isValidChecked = false;
            }
            else
            {
                DataGridResults.IsEnabled = true;
                cmbSize.IsEditable = true;
            }
            IsCalculatingEnabled();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainView = new MainWindow();
            mainView.Show();
            Close();
        }
    }
}
