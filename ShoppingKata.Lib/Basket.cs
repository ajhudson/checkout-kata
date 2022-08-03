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
        /// Add an item to the basket.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            this._items.Add(item);
        }

        /// <summary>
        /// Get the total number of items in the basket.
        /// </summary>
        public int TotalItems => this._items.Count;
    }
}