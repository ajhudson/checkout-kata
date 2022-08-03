namespace ShoppingKata.Lib.DiscountStrategies;

public class BulkDiscountStrategy : DiscountStrategyBase
{
    /// <summary>
    /// The discount applies to SKU "C"
    /// </summary>
    public override string AppliesToSKU => nameof(SKU.C);

    /// <summary>
    /// Calculate the discount to take off the cost.
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int CalculateDiscountToApply(IEnumerable<Item> items)
    {
        throw new NotImplementedException();
    }
}