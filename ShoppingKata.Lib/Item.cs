namespace ShoppingKata.Lib;

/// <summary>
/// The item.
/// </summary>
public class Item
{
    /// <summary>
    /// The stock keeping unit.
    /// </summary>
    public string SKU { get; init; }

    /// <summary>
    /// The unit price.
    /// </summary>
    public int UnitPrice { get; set; }
}