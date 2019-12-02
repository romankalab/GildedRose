using System.Collections.Generic;
using System;

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
            int qdecrease = 1;
            foreach (Item item in items)
            {
                item.SellIn = item.SellIn - 1;
                if (item.SellIn < 0)
                    qdecrease = qdecrease * 2;

                if (item.Name.Contains("Conjured"))
                    qdecrease = qdecrease * 2;
            }
        }
    }
}
