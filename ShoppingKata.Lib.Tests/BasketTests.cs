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
    public void ShouldCalculateTotalCostOfBasket()
    {
        
    }
}