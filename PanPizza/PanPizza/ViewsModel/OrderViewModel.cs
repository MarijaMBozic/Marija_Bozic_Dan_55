using PanPizza.Command;
using PanPizza.Models;
using PanPizza.Service;
using PanPizza.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PanPizza.ViewsModel
{
    public class OrderViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        OrderView orderView;

        #region Constructore
        public OrderViewModel(OrderView orderViewOpen)
        {
            orderView = orderViewOpen;
            SizeList = new ObservableCollection<PizzaSize>(service.GettAllSize());
            IngredientsList = new ObservableCollection<Ingredients>(service.GettAllIngredients());
        }
        #endregion

        #region Property
        private PizzaSize selectedSize;
        public PizzaSize SelectedSize
        {
            get
            {
                return selectedSize;
            }
            set
            {
                selectedSize = value;
                OnPropertyChanged("SelectedSize");
            }
        }

        private ObservableCollection<PizzaSize> sizeList;
        public ObservableCollection<PizzaSize> SizeList
        {
            get
            {
                return sizeList;
            }
            set
            {
                sizeList = value;
                OnPropertyChanged("SizeList");
            }
        }

        private Ingredients ingredients;
        public Ingredients Ingredients
        {
            get
            {
                return ingredients;
            }
            set
            {
                ingredients = value;
                OnPropertyChanged("Ingredients");
            }
        }

        private double totalAmount;
        public double TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private ObservableCollection<Ingredients> ingredientsList;
        public ObservableCollection<Ingredients> IngredientsList
        {
            get
            {
                return ingredientsList;
            }
            set
            {
                ingredientsList = value;
                OnPropertyChanged("IngredientsList");
            }
        }
        #endregion        

        #region Commands
        private ICommand calculateAmount;

        public ICommand CalculateAmount
        {
            get
            {
                if (calculateAmount == null)
                {
                    calculateAmount = new RelayCommand(param => CalculateAmountSaveExecute());
                }
                return calculateAmount;
            }
        }
        public void CalculateAmountSaveExecute()
        {
            try
            {
                TotalAmount = 0;
                foreach (Ingredients ingredients in IngredientsList)
                {
                    if(ingredients.IsChecked)
                    {
                        TotalAmount += ingredients.Price;
                    }
                }
                TotalAmount = TotalAmount * selectedSize.SizeID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());              
            }
        }



        #endregion
    }
}
