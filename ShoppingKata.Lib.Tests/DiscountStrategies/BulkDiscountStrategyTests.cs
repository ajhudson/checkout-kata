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
    [TestCase(2, 0, TestName = "2 items of SKU B should result in no discount")]
    [TestCase(3, 5, TestName = "3 items of SKU B should result in a discount of 5")]
    [TestCase(6, 10, TestName = "6 items of SKU B should result in a discount of 10")]
    public void ShouldApplyDiscountForBulkStrategy(int itemsInBasket, int expectedDiscountAmount)
    {
        // Arrange
        var skuBItems = ItemsFactory.CreateItems(SKU.B, itemsInBasket);

        // Act
        var result = this._discountStrategy.CalculateDiscountToApply(skuBItems);

        // Assert
        result.ShouldBe(expectedDiscountAmount);
    }
}