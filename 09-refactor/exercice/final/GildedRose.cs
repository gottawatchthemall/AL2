using System.Collections.Generic;
using static csharpcore.ItemType;

namespace csharpcore
{
    static class QualityItemUpdateStrategyFactory
    {
        public static IQualityItemUpdateStrategy Create(string name)
        {
            return name switch
            {
                AgedBrie => new AgedBrieQualityUpdate(),
                BackstagePasses => new BackstagePasseQualityUpdate(),
                _ => new RegularItemQualityUpdate()
            };
        }
    }

    public interface IQualityItemUpdateStrategy
    {
        void Update(Item item);
    }

    class AgedBrieQualityUpdate : IQualityItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.IncreaseQuality();

            if (item.SellIn < 0)
                item.IncreaseQuality();
        }
    }

    class BackstagePasseQualityUpdate : IQualityItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.IncreaseQuality();

            if (item.SellIn < 10)
                item.IncreaseQuality();

            if (item.SellIn < 5)
                item.IncreaseQuality();

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }

    class RegularItemQualityUpdate : IQualityItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.DecreaseQuality();

            if (item.SellIn < 0)
                item.DecreaseQuality();
        }
    }

    public class GildedRose
    {
        readonly IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                UpdateQualityItem(item);
        }

        private static void UpdateQualityItem(Item item)
        {
            item.DecreaseSellIn();

            var qualityItemUpdateStrategy = QualityItemUpdateStrategyFactory.Create(item.Name);

            item.UpdateQuality(qualityItemUpdateStrategy);
        }
    }
}