using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PanPizza.Models
{
    public class Ingredients
    {
        public int IngredientsId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsChecked { get; set; }
    }
}
