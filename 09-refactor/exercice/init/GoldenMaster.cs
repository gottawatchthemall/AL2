using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xunit;

namespace csharpcore
{
    public class GoldenMaster
    {
        [Fact]
        public void CheckNoRegression()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            
            var app = new GildedRose(Items);

            var lines = File.ReadLines("./gb.txt").ToArray();
            
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < Items.Count; j++)
                {
                    var line = (Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                    Assert.Equal(lines[(Items.Count * i) + j], line);
                }
                 app.UpdateQuality();
            }
        }

        // public void GenerateGoldenMaster()
        // {
        //     IList<Item> Items = new List<Item>
        //     {
        //         new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
        //         new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
        //         new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
        //         new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
        //         new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
        //         new Item
        //         {
        //             Name = "Backstage passes to a TAFKAL80ETC concert",
        //             SellIn = 15,
        //             Quality = 20
        //         },
        //         new Item
        //         {
        //             Name = "Backstage passes to a TAFKAL80ETC concert",
        //             SellIn = 10,
        //             Quality = 49
        //         },
        //         new Item
        //         {
        //             Name = "Backstage passes to a TAFKAL80ETC concert",
        //             SellIn = 5,
        //             Quality = 49
        //         },
        //         // this conjured item does not work properly yet
        //         new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        //     };
        //
        //     var app = new GildedRose(Items);
        //
        //     for (var i = 0; i < 10; i++)
        //     {
        //         for (var j = 0; j < Items.Count; j++)
        //         {
        //             var line = (Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
        //             File.AppendAllLines("/tmp/gb.txt", new[] {line});
        //         }
        //
        //         app.UpdateQuality();
        //     }
        // }
    }
}