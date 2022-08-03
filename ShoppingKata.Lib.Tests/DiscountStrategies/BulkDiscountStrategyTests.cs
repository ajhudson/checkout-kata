using ShoppingKata.Lib.DiscountStrategies;
using Shouldly;

namespace ShoppingKata.Lib.Tests.DiscountStrategies;

[TestFixture]
public class BulkDiscountStrategyTests
{
    /// <summary>
    /// The discount strategy for bulk.
    /// </summary>
    private IDiscountStrategy _discountStrategy = null!;

    [SetUp]
    public void SetUp()
    {
        this._discountStrategy = new BulkDiscountStrategy();
    }
    
    [Test]
    public void ShouldApplyDiscountForBulkStrategy()
    {
        // Arrange
        var skuBItems = ItemsFactory.CreateItems(SKU.B, 3);

        // Act
        var result = this._discountStrategy.CalculateDiscountToApply(skuBItems);

        // Assert
        result.ShouldBe(5);
    }
}