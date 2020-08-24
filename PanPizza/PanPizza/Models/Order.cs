using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanPizza.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int SizeId { get; set; }
        public int IngredientsId { get; set; }
        public long PhoneNumber { get; set; }
    }
}
