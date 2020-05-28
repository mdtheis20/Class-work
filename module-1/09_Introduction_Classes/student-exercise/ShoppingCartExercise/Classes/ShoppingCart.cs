using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// A shopping cart class stores items in it.
    /// </summary>
    public class ShoppingCart
    {

        public int TotalNumberOfItems { get; private set; } = 0;
        
        public decimal TotalAmountOwed { get; private set; } = 0.0M;
        


        public decimal GetAveragePricePerItem()
        {
            

            if (TotalNumberOfItems == 0 )
            {
                
                return 0;
            }
            if (TotalAmountOwed == 0.0m)
            {
                return  0;
            }
            
            if(TotalNumberOfItems > 0 && TotalAmountOwed > 0.0M)
            {
                decimal pricePerItem = TotalAmountOwed / TotalNumberOfItems;
                return pricePerItem;
            }


            return 0;
            
        }

        public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            this.TotalNumberOfItems = numberOfItems;
            this.TotalAmountOwed = pricePerItem * numberOfItems;
        }

        public void Empty()
        {
            this.TotalNumberOfItems = 0;
            this.TotalAmountOwed = 0.0m;
        }
       
    }
}
