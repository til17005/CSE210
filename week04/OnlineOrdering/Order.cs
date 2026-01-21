public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double SubTotal()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.TotalCost(product.GetPrice(), product.GetQuantity());
        }
        return total;
    }

    public double ShippingCost()
    {
        double shippingCost = 0;
        if (_customer.ValidateCountry())
        {
            // USA Shipping Cost
            shippingCost = 5.00;
        }
        else
        {
            // International Shipping Cost
            shippingCost = 35.00;
        }
        return shippingCost;
    }
    
    public double TotalCost()
    {
        double total = ShippingCost() + SubTotal();
        return total;
    }

    public string DisplayShippingLabel()
    {
        string shippingLabel = "#########################################################################\n*** Shipping Label ***\n";
        shippingLabel += $"{_customer.DisplayCustomer()}#########################################################################\n";
        return shippingLabel;
    }

    public string DisplayPackingLabel()
    {
        string packingLabel = "#########################################################################\n*** Packing Label ***\n Product\t | Product ID\t | Quantity\t | Unit Price\t | Total\n__________________________________________________________________________\n\n";
        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()}\t | {product.GetProductID()}\t | {product.GetQuantity()}\t\t | {product.GetPrice().ToString("C2")}\t | {product.TotalCost(product.GetPrice(), product.GetQuantity()).ToString("C2")}\n";

        }
        packingLabel += $"__________________________________________________________________________\n\nSubtotal: {SubTotal().ToString("C2")}\nShipping Cost: {ShippingCost().ToString("C2")}\nTotal Cost: {TotalCost().ToString("C2")}\n#########################################################################\n";
        return packingLabel;
    }
}
