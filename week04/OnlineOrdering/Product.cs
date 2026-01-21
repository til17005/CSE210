public class Product
{
    private string _name;
    private string _productID;
    // I looked this up to make sure I could do a double in C# because an int won't work. Found out it is default but I set it anyway.
    private double _price;
    private int _quantity;

    public Product(string name, string productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductID()
    {
        return _productID;
    }

    public double GetPrice()
    {
        return _price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public double TotalCost(double price, int quantity)
    {
        _price = price;
        _quantity = quantity;

        return _price * _quantity;
    }
}