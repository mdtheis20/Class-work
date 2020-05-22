using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an string representing an item number (a.k.a. SKU), return the discount percentage if the item is on sale.
         * If the item is not on sale, return 0.00.
         *
         * If the item number is empty or null, return 0.00.
         *
		 * Dictionary to start with
		 *
         * "KITCHEN4001" -> 0.20
         * "GARAGE1070" -> 0.15
         * "LIVINGROOM"	-> 0.10
         * "KITCHEN6073" -> 0.40
         * "BEDROOM3434" -> 0.60
         * "BATH0073" -> 0.15
         *
         * The item number should be case insensitive so "kitchen4001", "Kitchen4001", and "KITCHEN4001"
         * should all return 0.20.
         *
         * IsItOnSale("kitchen4001") → 0.20
         * IsItOnSale("") → 0.00
         * IsItOnSale("GARAGE1070") → 0.15
         * IsItOnSale("dungeon9999") → 0.00
         *
         */
        public double IsItOnSale(string itemNumber)
        {
            // First create a Dictionary that holds this data
            //"KITCHEN4001"-> 0.20
            //"GARAGE1070"-> 0.15
            //"LIVINGROOM"-> 0.10
            //"KITCHEN6073"-> 0.40
            //"BEDROOM3434"-> 0.60
            //"BATH0073"-> 0.15

            Dictionary<string, double> itemsForSale = new Dictionary<string, double>()
            {
                {"kitchen4001", 0.20 },
                {"garage1070", 0.15 },
                {"livingroom", 0.10 },
                {"kitchen6073", 0.40},
                {"bedroom3434", 0.60},
                {"bath0073", 0.15},

            };

            if (itemsForSale.ContainsKey(""))
            {
                return 0.00;
            }

            else if (itemsForSale.ContainsKey(itemNumber.ToLower()))
            {
                return itemsForSale[itemNumber.ToLower()];
            }

                // Now check the Dictionary you just created for the itemNumber

                return 0.00;
        }
    }
}


//Dictionary<string, string> animalGroupName = new Dictionary<string, string>()
//            {
//                {"rhino", "Crash"},
//                {"giraffe", "Tower"},
//                {"elephant", "Herd"},
//                {"lion", "Pride"},
//                {"crow", "Murder"},
//                {"pigeon","Kit"},
//                {"flamingo", "pat" },
//                {"deer", "Herd" },
//                {"dog", "Pack" },
//                {"crocodile", "Float" },

//            };

//            if (animalGroupName.ContainsKey(animalName.ToLower()))
//            {
//                return animalGroupName[animalName.ToLower()];
//            }
//            else
//            {
//                return "unknown";