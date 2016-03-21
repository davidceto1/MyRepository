using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class ProductData
    {
        string productName;

        double retailPrice;

        public ProductData(string productName, double retailPrice)
        {
            this.productName = productName;

            this.retailPrice = retailPrice;
        }

        public string printProduct()
        {
            return productName + ": $" +retailPrice;
        }

        public string returnName()
        {
            return productName;
        }

        public double returnPrice()
        {
            return retailPrice;
        }

        public void setPrice(double newPrice)
        {
            retailPrice = newPrice;
        }
    }
}
