namespace ShoppingKata.Lib.DiscountStrategies;

public class BulkDiscountStrategy : DiscountStrategyBase
{
    /// <summary>
    /// The discount applies to SKU "C"
    /// </summary>
    public override string AppliesToSKU => nameof(SKU.B);

    /// <summary>
    /// The quantity of items required for the promotion to apply.
    /// </summary>
    public override int QuantityMultiplier => 3;

    /// <summary>
    /// How much to discount by.
    /// </summary>
    public override int DiscountFactor => 5;

    /// <summary>
    /// Calculate the discount to take off the cost.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override decimal CalculateDiscountToApply(IEnumerable<Item> items)
    {
        var discountedItems = this.GetDiscountedItems(items);

        if (!discountedItems.Any())
        {
            return 0;
        }
        
        var multiples = discountedItems.Count / this.QuantityMultiplier;
        var discountToApply = multiples * this.DiscountFactor;

        return discountToApply;
    }
}