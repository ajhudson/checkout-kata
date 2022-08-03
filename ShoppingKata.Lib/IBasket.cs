namespace ShoppingKata.Lib;

/// <summary>
/// Defines an abstraction for a <see cref="IBasket"/>
/// </summary>
public interface IBasket
{
    void AddItem(Item item);
    
    /// <summary>
    /// Get the total number of items in the basket
    /// </summary>
    int TotalItems { get; }
}