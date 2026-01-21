using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nHello World! This is the OnlineOrdering Project.\n");

        // Add Address details
        string customerStreet = "1387 Tilton Ave.";
        string customerCity = "San Fernando";
        string customerState = "UT";
        string customerCountry = "United States of America";

        // Create Address object
        Address address = new Address(customerStreet, customerCity, customerState, customerCountry);

        // Create Customer Object       
        Customer customer = new Customer("Matthew Hansen", address);

        // Create Order Object
        Order order = new Order(customer);

        // Create products
        Product product1 = new Product("Book on C#", "Book24", 34.54, 2);
        Product product2 = new Product("Laptop Case", "Case09", 67.89, 1);
        Product product3 = new Product("Mouth Wase", "YouStink23", 5.79, 4);
        Product product4 = new Product("Chap Stick", "DryLip004", .89, 10);
        Product product5 = new Product("Head Phones", "Listen243", 99.99, 1);
        Product product6 = new Product("Monster Door", "Door2319", 253.74, 1);
        Product product7 = new Product("Printer Ink", "PrintMe3", 18.63, 1);

        // Add products to order
        order.AddProduct(product1);
        order.AddProduct(product2);
        order.AddProduct(product3);
        order.AddProduct(product4);
        order.AddProduct(product5);
        order.AddProduct(product6);
        order.AddProduct(product7);

        // Display Packing Label
        Console.WriteLine(order.DisplayPackingLabel());

        // Display Shipping Label
        Console.WriteLine(order.DisplayShippingLabel());
    }
}