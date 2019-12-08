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
            int originalq = 0;
            int originals = 0;
            foreach (Item item in items)
            {
                originalq = item.Quality;
                originals = item.SellIn;
                item.SellIn = item.SellIn - 1;
                if (item.SellIn < 0)
                    qdecrease = qdecrease * 2;

                if (item.Name.Contains("Conjured"))
                    qdecrease = qdecrease * 2;


                item.Quality = item.Quality - qdecrease;

                if (item.Name.Contains("Aged Brie"))
                {
                    item.Quality = originalq;
                    item.Quality = item.Quality + 1;
                    if (item.SellIn < 1)
                        item.Quality = item.Quality + 1;
                }
                if (item.Name.Contains("Backstage passes"))
                {
                    item.Quality = originalq;
                    item.Quality = item.Quality + 1;
                    if (item.SellIn < 11)
                        item.Quality = item.Quality + 1;
                    if (item.SellIn < 6)
                        item.Quality = item.Quality + 1;
                    if (item.SellIn < 1)
                        item.Quality = 0;
                }

                if (item.Quality < 0)
                    item.Quality = 0;
                if (item.Quality > 50)
                    item.Quality = 50;

                if (item.Name.Contains("Sulfuras"))
                {
                    item.Quality = originalq;
                    item.SellIn = originals;
                }
                qdecrease = 1;
            }
        }
    }
}
