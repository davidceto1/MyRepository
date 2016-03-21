using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        const int MAX_NUM_PRODUCTS = 100;

        static ProductCatalogue[] catalogues = new ProductCatalogue[10];

        static int numberOfCatalogues = 0;

        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                displayMenu();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        createCatalogue();
                        break;

                    case "2":
                        printCatalogues();
                        break;

                    case "3":
                        addProduct();
                        break;

                    case "4":
                        updateProduct();
                        break;

                    case "5":
                        deleteProduct();
                        break;

                    case "6":
                        calculateTotals();
                        break;

                    case "7":
                        continueProgram = false;
                        break;

                }
            }

        }

        static void displayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Add new catalogue");
            Console.WriteLine("2. Print catalogue");
            Console.WriteLine("3. Add new product and price");
            Console.WriteLine("4. Update existing product price");
            Console.WriteLine("5. Delete product");
            Console.WriteLine("6. Calculate totals");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\nPlease enter the number of the action you want to perform: ");
        }

        static void createCatalogue()
        {
            Console.WriteLine("Enter the name of a new product catalogue: ");

            string catalogueName = Console.ReadLine();

            ProductCatalogue catalogue = new ProductCatalogue(catalogueName);

            catalogues[numberOfCatalogues] = catalogue;

            numberOfCatalogues++;
        }

        static void printCatalogues()
        {
            for (int i = 0; i < numberOfCatalogues; i++)
            {
                Console.WriteLine( (i+1) + ". " +catalogues[i].returnName());
                catalogues[i].printCatalogue();
            }
        }

        static void addProduct()
        {            
            double pruductPrice = 0;

            bool validNumber = false;

            string userInput;

            int catalogueNumber = selectCatalogue();

            Console.WriteLine("Enter the name of a new product in your catalogue: ");

            string productName = Console.ReadLine();

            validNumber = false;

            while(!validNumber)
            {
                Console.WriteLine("Enter the retail price of: " + productName);

                userInput = Console.ReadLine();

                if (double.TryParse(userInput, out pruductPrice))
                {
                    validNumber = true;
                }
            }

            catalogues[catalogueNumber].insertProduct(productName, pruductPrice);
        }

        static void updateProduct()
        {     
            int catalogueNumber = selectCatalogue();

            int productNumber = selectProduct("whose price you would like to update", catalogueNumber);

            catalogues[catalogueNumber].updateProductPrice(productNumber);
        }

        static void deleteProduct()
        {
            
            int catalogueNumber = selectCatalogue();

            int productNumber = selectProduct("that you want to delete", catalogueNumber);

            catalogues[catalogueNumber].deleteProduct(productNumber);

        }

        static int selectCatalogue()
        {
            int catalogueNumber = 0;
            
            bool validNumber = false;

            string userInput;

            Console.WriteLine("You have " + numberOfCatalogues + "product catalogues");

            for (int i = 0; i < numberOfCatalogues; i++)
            {
                Console.WriteLine((i + 1) + ". " + catalogues[i].returnName());
            }

            while (!validNumber)
            {
                Console.WriteLine("Please choose the catalogue:");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out catalogueNumber))
                {
                    --catalogueNumber;
                    validNumber = true;
                }
            }

            Console.WriteLine("you have chosen " + catalogues[catalogueNumber].returnName());

            return catalogueNumber;
        }

        static int selectProduct(string message, int catalogueNumber)
        {
            int productNumber = 0;

            bool validNumber = false;

            int numberOfProducts = catalogues[catalogueNumber].returnNumberOfProducts();

            Console.WriteLine("You have " + numberOfProducts + " products in your catalogue:");

            catalogues[catalogueNumber].printCatalogue();

            while (!validNumber)
            {
                Console.WriteLine("Please enter the number of the product, "+ message +": ");

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out productNumber) && productNumber <= numberOfProducts && productNumber > 0)
                {
                    --productNumber;
                    validNumber = true;
                }
            }

            return productNumber;
        }

        static void calculateTotals()
        {   
            double subtotal = 0;
            int subtotalNumberOfProducts;
            double average = 0;
            double total = 0;
            int totalNumberOfProducts = 0;

            for (int i = 0; i < numberOfCatalogues; i++)
            {
                subtotal = catalogues[i].calculateSubtotal();
                subtotalNumberOfProducts = catalogues[i].returnNumberOfProducts();
                average = subtotal / subtotalNumberOfProducts;

                Console.WriteLine("The average retail price of "+catalogues[i].returnName() +" catalogue is: $" + average);

                total += subtotal;
                totalNumberOfProducts += subtotalNumberOfProducts;
            }

            average = total / totalNumberOfProducts;

            Console.WriteLine("You have " + totalNumberOfProducts + " products in total. The average retail price of those is: $" + average);
        }


    }
}
