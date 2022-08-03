using ShoppingKata.Lib.DiscountStrategies;

namespace ShoppingKata.Lib
{
    /// <summary>
    /// The implementation of a <see cref="Basket"/>
    /// </summary>
    public class Basket : IBasket
    {
        /// <summary>
        /// The items in the basket.
        /// </summary>
        private readonly IList<Item> _items = new List<Item>();

        /// <summary>
        /// The discount strategies to be applied.
        /// </summary>
        private readonly IList<IDiscountStrategy> _discountStrategies = new List<IDiscountStrategy>();

        /// <summary>
        /// Add an item to the basket.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            this._items.Add(item);
        }

        /// <summary>
        /// Add a discount strategy to the basket.
        /// </summary>
        /// <param name="discountStrategy"></param>
        public void AddDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            this._discountStrategies.Add(discountStrategy);
        }

        /// <summary>
        /// Calculate the total cost of the basket.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotalCost()
        {
            decimal total = this._items.Sum(item => item.UnitPrice);

            foreach (var currentDiscountStrategy in this._discountStrategies)
            {
                total -= currentDiscountStrategy.CalculateDiscountToApply(this._items);
            }

            return total;
        }

        /// <summary>
        /// Get the total number of items in the basket.
        /// </summary>
        public int TotalItems => this._items.Count;
    }
}