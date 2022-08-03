using ShoppingKata.Lib.Constants;
using Shouldly;

namespace ShoppingKata.Lib.Tests;

[TestFixture]
public class ItemsFactoryTests
{
    
    [Test]
    [TestCaseSource(nameof(TestDataProvider))]
    public void ShouldCreateCorrectItem(SKU sku, Item expectedItem)
    {
        // Arrange
        // Act
        var item = ItemsFactory.CreateItem(sku);

        // Assert
        item.ShouldNotBeNull();
        item.SKU.ShouldBe(expectedItem.SKU);
        item.UnitPrice.ShouldBe(expectedItem.UnitPrice);
    }

    [Test]
    public void ShouldCreateMultipleItems()
    {
        // Arrange
        // Act
        var items = ItemsFactory.CreateItems(SKU.A, 3).ToList();
        
        // Assert
        items.ShouldNotBeNull();
        items.Count.ShouldBe(3);
    }

    /// <summary>
    /// Set up test data for parameterised test.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<TestCaseData> TestDataProvider()
    {
        yield return new TestCaseData(SKU.A, new Item { SKU = nameof(SKU.A), UnitPrice = UnitPrices.PriceA }).SetName("Should create item A");
        yield return new TestCaseData(SKU.B, new Item { SKU = nameof(SKU.B), UnitPrice = UnitPrices.PriceB }).SetName("Should create item B");
        yield return new TestCaseData(SKU.C, new Item { SKU = nameof(SKU.C), UnitPrice = UnitPrices.PriceC }).SetName("Should create item C");
        yield return new TestCaseData(SKU.D, new Item { SKU = nameof(SKU.D), UnitPrice = UnitPrices.PriceD }).SetName("Should create item D");
    }
}