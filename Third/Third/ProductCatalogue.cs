using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class ProductCatalogue
    {
        const int MAX_NUM_PRODUCTS = 100;

        string catalogueName;

        ProductData[] products;

        int numberOfProducts;

        public ProductCatalogue(string catalogueName)
        {
            this.catalogueName = catalogueName;

            numberOfProducts = 0;

            products = new ProductData[MAX_NUM_PRODUCTS];
        }

        public void printCatalogue()
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                Console.WriteLine("\t"+(i+1)+". "+ products[i].printProduct());
            }
        }

        public void insertProduct(string productName, double retailPrice)
        {
            ProductData product = new ProductData(productName, retailPrice);

            products[numberOfProducts] = product;

            numberOfProducts++;
        }

        public string returnName()
        {
            return catalogueName;
        }

        public int returnNumberOfProducts()
        {
            return numberOfProducts;
        }

        public double calculateSubtotal()
        {
            double total = 0;

            for (int i = 0; i < numberOfProducts; i++)
            {
                total += products[i].returnPrice();
            }

            return total;
        }

        public void updateProductPrice(int productNumber)
        {
            bool validNumber = false;

            double price = 0;
            
            Console.WriteLine("You have selected " + products[productNumber].returnName() + ". The current retail price is $" + products[productNumber].returnPrice() + ".");         

            while (!validNumber)
            {
                Console.WriteLine("Please enter the new price: ");

                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out price))
                {
                    validNumber = true;
                }
            }

            products[productNumber].setPrice(price);
        }

        public void deleteProduct(int productNumber)
        {
            string productName;

            productName = products[productNumber].returnName();

            for (int i = productNumber; i < numberOfProducts; i++)
            {
                products[i] = products[i + 1];
            }

            --numberOfProducts;

            Console.WriteLine("You have deleted " + productName);
        }
    }
}
