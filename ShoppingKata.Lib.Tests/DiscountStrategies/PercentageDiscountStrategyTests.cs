using ShoppingKata.Lib.DiscountStrategies;
using Shouldly;

namespace ShoppingKata.Lib.Tests.DiscountStrategies;

[TestFixture]
public class PercentageDiscountStrategyTests
{
    /// <summary>
    /// The discount strategy for bulk.
    /// </summary>
    private IDiscountStrategy _discountStrategy = null!;

    [SetUp]
    public void SetUp()
    {
        this._discountStrategy = new PercentageDiscountStrategy();
    }
    
    [Test]
    [TestCase(1, 0, TestName = "1 items of SKU D should result in no discount")]
    [TestCase(2, 27.5, TestName = "2 items of SKU D should result in a discount of 25%")]
    public void ShouldApplyDiscountForBulkStrategy(int itemsInBasket, decimal expectedDiscountAmount)
    {
        // Arrange
        var skuBItems = ItemsFactory.CreateItems(SKU.D, itemsInBasket);

        // Act
        var result = this._discountStrategy.CalculateDiscountToApply(skuBItems);

        // Assert
        result.ShouldBe(expectedDiscountAmount);
    }
}