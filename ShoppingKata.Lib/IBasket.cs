using ShoppingKata.Lib.DiscountStrategies;

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
    /// Add a discount strategy to the basket.
    /// </summary>
    /// <param name="discountStrategy"></param>
    void AddDiscountStrategy(IDiscountStrategy discountStrategy);

    /// <summary>
    /// Calculate total cost of basket.
    /// </summary>
    /// <returns></returns>
    decimal CalculateTotalCost();
    
    /// <summary>
    /// Get the total number of items in the basket
    /// </summary>
    int TotalItems { get; }
}