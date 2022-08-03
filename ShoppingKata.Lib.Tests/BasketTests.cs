using ShoppingKata.Lib.DiscountStrategies;
using Shouldly;

namespace ShoppingKata.Lib.Tests;

[TestFixture]
public class BasketTests
{
    private IBasket _basket = null!;
    
    [SetUp]
    public void Setup()
    {
        this._basket = new Basket();
    }

    [Test]
    public void ShouldAddAnItemToTheBasket()
    {
        // Arrange
        var item = new Item { SKU = nameof(SKU.A), UnitPrice = Constants.UnitPrices.PriceA };

        // Act
        this._basket.AddItem(item);

        // Assert
        this._basket.TotalItems.ShouldBe(1);
    }

    [Test]
    [TestCaseSource(nameof(TotalCostOfBasketAtFullPriceTestDataProvider))]
    public void ShouldCalculateTotalCostOfBasketAtFullPrice(IEnumerable<SKU> items, decimal expectedCost)
    {
        // Arrange
        var itemsToAdd = items.Select(ItemsFactory.CreateItem);
        
        foreach (var item in itemsToAdd)
        {
            this._basket.AddItem(item);    
        }

        // Act
        decimal total = this._basket.CalculateTotalCost();

        // Assert
        total.ShouldBe(expectedCost);
    }

    [Test]
    [TestCaseSource(nameof(TotalCoseOfDiscountedBasketTestDataProvider))]
    public void ShouldCalculateTotalCostOfBasketAtDiscountedPrice(IEnumerable<SKU> items, decimal expectedCost)
    {
        // Arrange
        var itemsToAdd = items.Select(ItemsFactory.CreateItem);
        
        foreach (var item in itemsToAdd)
        {
            this._basket.AddItem(item);    
        }
        
        this._basket.AddDiscountStrategy(new BulkDiscountStrategy());
        this._basket.AddDiscountStrategy(new PercentageDiscountStrategy());

        // Act
        decimal total = this._basket.CalculateTotalCost();

        // Assert
        total.ShouldBe(expectedCost);
    }

    /// <summary>
    /// The test data for calculating the cost of a basket at full price.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<TestCaseData> TotalCostOfBasketAtFullPriceTestDataProvider()
    {
        yield return new TestCaseData(new List<SKU> { SKU.A, SKU.C, SKU.A }, 60m).SetName("2 x A and 1 x C should cost 60");
        yield return new TestCaseData(new List<SKU> { SKU.A, SKU.B, SKU.C, SKU.D }, 120m).SetName("1 x every item should cost 120");
        yield return new TestCaseData(new List<SKU> { SKU.C, SKU.C, SKU.D, SKU.D }, 190m).SetName("2 x C and 2 x D should cost 190");
    }

    /// <summary>
    /// The test data for calculating the cost of a basket at discounted prices.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<TestCaseData> TotalCoseOfDiscountedBasketTestDataProvider()
    {
        yield return new TestCaseData(new List<SKU> { SKU.B, SKU.B, SKU.B }, 40m).SetName("3 x B should cost 40 after a discount on a multiple of 3 items");
        yield return new TestCaseData(new List<SKU> { SKU.D, SKU.D }, 82.50m).SetName("2 x D should cost 87.5 after a discount of 25% on a multiple of 2 items");
        yield return new TestCaseData(new List<SKU> { SKU.A, SKU.C, SKU.A }, 60m).SetName("2 x A and 1 x C should cost 60 with NO discounts applied");
    }
}