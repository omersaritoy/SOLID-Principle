
var cart = new ShoppingCart();
cart.AddItem(new CartItem(100));  

 
cart.AddDiscount(new PercentageDiscount(10));

 
cart.AddDiscount(new FixedAmountDiscount(20));

 
decimal totalPrice = cart.CalculateTotalPrice();
Console.WriteLine("Total Price: $" + totalPrice);

public interface ICartItem
{
    decimal Price { get; }
}

public interface IDiscount
{
    decimal ApplyDiscount(decimal price);
}

 
public class CartItem : ICartItem
{
    public decimal Price { get; }

    public CartItem(decimal price)
    {
        Price = price;
    }
}

 public class PercentageDiscount : IDiscount
{
    private readonly decimal _percentage;

    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price * (1 - _percentage / 100);
    }
}

 public class FixedAmountDiscount : IDiscount
{
    private readonly decimal _amount;

    public FixedAmountDiscount(decimal amount)
    {
        _amount = amount;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - _amount;
    }
}

public class ShoppingCart
{
    private readonly List<ICartItem> _items;
    private readonly List<IDiscount> _discounts;

    public ShoppingCart()
    {
        _items = new List<ICartItem>();
        _discounts = new List<IDiscount>();
    }

    public void AddItem(ICartItem item)
    {
        _items.Add(item);
    }

    public void AddDiscount(IDiscount discount)
    {
        _discounts.Add(discount);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = _items.Sum(item => item.Price);
        foreach (var discount in _discounts)
        {
            totalPrice = discount.ApplyDiscount(totalPrice);
        }
        return totalPrice;
    }
}