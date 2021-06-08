using static csharpcore.ItemType;

namespace csharpcore
{
    static class ItemType
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    }

    public class Item
    {
        private const int maxQualityItem = 50;
        private const int minQualityItem = 0;
        
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void IncreaseQuality()
        {
            if (Quality < maxQualityItem)
                Quality += 1;
        }

        public void DecreaseQuality()
        {
            if (Name == Sulfuras) return;

            if (Quality > minQualityItem)
                Quality -= 1;
        }

        public void DecreaseSellIn()
        {
            if (Name == Sulfuras) return;

            SellIn -= 1;
        }

        public void UpdateQuality(IQualityItemUpdateStrategy qualityItemUpdateStrategy)
        {
            qualityItemUpdateStrategy.Update(this);
        }
    }
}