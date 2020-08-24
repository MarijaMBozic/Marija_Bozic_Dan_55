using PanPizza.Models;
using PanPizza.Service;
using PanPizza.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
