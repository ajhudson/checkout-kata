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
    [TestCaseSource(nameof(TotalCostOfBasketTestDataProvider))]
    public void ShouldCalculateTotalCostOfBasket(IEnumerable<SKU> items, int expectedCost)
    {
        // Arrange
        var itemsToAdd = items.Select(ItemsFactory.CreateItem);
        
        foreach (var item in itemsToAdd)
        {
            this._basket.AddItem(item);    
        }

        // Act
        int total = this._basket.CalculateTotalCost();

        // Assert
        total.ShouldBe(expectedCost);
    }

    /// <summary>
    /// The test data for calculating the cost of a basket.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<TestCaseData> TotalCostOfBasketTestDataProvider()
    {
        yield return new TestCaseData(new List<SKU> { SKU.A, SKU.C, SKU.A }, 60);
    }
}