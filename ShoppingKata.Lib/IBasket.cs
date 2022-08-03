namespace ShoppingKata.Lib;

/// <summary>
/// Defines an abstraction for a <see cref="IBasket"/>
/// </summary>
public interface IBasket
{
    /// <summary>
    /// Add an item to the basket.
    /// </summary>
    /// <param name="item"></param>
    void AddItem(Item item);

    /// <summary>
    /// Calculate total cost of basket.
    /// </summary>
    /// <returns></returns>
    int CalculateTotalCost();
    
    /// <summary>
    /// Get the total number of items in the basket
    /// </summary>
    int TotalItems { get; }
}