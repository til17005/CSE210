public class Customer
{
    private string _name;
    private Address _address;

    public string DisplayCustomer()
    {
        return $"Customer Name: {_name}\nAddress:\n{_address.GetAdress()}\n";
    }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool ValidateCountry()
    {      
        string country = _address.GetCountry();
        return _address.ValidateCountry(country);
    }
}