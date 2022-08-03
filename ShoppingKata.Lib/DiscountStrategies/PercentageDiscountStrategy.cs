namespace ShoppingKata.Lib.DiscountStrategies;

public class PercentageDiscountStrategy : DiscountStrategyBase
{
    /// <summary>
    /// Name of SKU the discount applies to.
    /// </summary>
    public override string AppliesToSKU => nameof(SKU.D);

    /// <summary>
    /// The quantity of items required for the promotion to apply.
    /// </summary>
    public override int QuantityMultiplier => 2;

    /// <summary>
    /// How much to discount by.
    /// </summary>
    public override int DiscountFactor => 25;
    
    /// <summary>
    /// Calculate the discount to apply.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public override decimal CalculateDiscountToApply(IEnumerable<Item> items)
    {
        var discountedItems = this.GetDiscountedItems(items);

        if (!discountedItems.Any() || discountedItems.Count < this.QuantityMultiplier)
        {
            return 0;
        }

        var total = discountedItems.Sum(item => item.UnitPrice);
        var multiples = discountedItems.Count / this.QuantityMultiplier;
        decimal percentageToDiscount = (100 - this.DiscountFactor) / 100m;
        var discountedAmt = Enumerable.Range(1, multiples).Select(_ => total * percentageToDiscount).Last();
        var amountToDiscount = total - discountedAmt;

        return amountToDiscount;
    }
}