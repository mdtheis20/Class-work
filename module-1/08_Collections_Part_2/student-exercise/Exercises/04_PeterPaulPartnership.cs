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
         * Modify and return the given Dictionary as follows: if "Peter" has $50 or more, AND "Paul" has $100 or more,
         * then create a new "PeterPaulPartnership" worth a combined contribution of a quarter of each partner's
         * current worth.
         *
         * Note, monetary amounts are specified in cents: penny=1, nickel=5, ... $1=100, ... $10=1000, ...
         * 
         * PeterPaulPartnership({"Peter": 50000, "Paul": 100000}) → {"Peter": 37500, "Paul": 75000, "PeterPaulPartnership": 37500}
         * PeterPaulPartnership({"Peter": 3333, "Paul": 1234567890}) → {"Peter": 3333, "Paul": 1234567890}
         *
         */
        public Dictionary<string, int> PeterPaulPartnership(Dictionary<string, int> peterPaul)
        {
            int peterMoney = peterPaul["Peter"];
            int paulMoney = peterPaul["Paul"];

            if ( peterMoney >= 5000 && paulMoney >= 10000)
            {
                int peterShare = peterMoney / 4;
                int paulShare = paulMoney / 4;
                int peterPartner = peterShare + paulShare;
                peterPaul["Peter"] = peterMoney - peterShare;
                peterPaul["Paul"] = paulMoney - paulShare;
                peterPaul.Add("PeterPaulPartnership", peterPartner);
            }
            return peterPaul;
        }
    }
}


//  {
//            int peterMoney = peterPaul["Peter"];
//int paulMoney = peterPaul["Paul"];
//            if (peterMoney > 0 && paulMoney< 1000)
//            {
//                int peterShare = peterMoney / 2;
//peterPaul["Peter"] =  peterMoney - peterShare;
//                peterPaul["Paul"] = paulMoney + peterShare;

//            }
//            return peterPaul;