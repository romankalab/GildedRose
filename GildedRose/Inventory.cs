using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            foreach(Item item in items)
            {
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
                item.SellIn -= 1;
                item.Quality -= 1;
                if (item.SellIn <= 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
