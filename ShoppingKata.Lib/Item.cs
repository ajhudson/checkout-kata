namespace ShoppingKata.Lib;

/// <summary>
/// The item.
/// </summary>
public class Item
{
    /// <summary>
    /// The stock keeping unit.
    /// </summary>
    public string SKU { get; init; } = string.Empty;

    /// <summary>
    /// The unit price.
    /// </summary>
    public decimal UnitPrice { get; init; }
}