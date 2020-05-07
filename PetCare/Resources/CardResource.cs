using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class CardResource
    {

        public long Number { get; set; }
        public string Name { get; set; }
        public short  CVV_Number { get; set; }
        public string Expiry_Date { get; set; }


    }
}
