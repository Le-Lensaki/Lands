using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Item.IDItem
{
    public enum IDItem
    {
        NoItem = 0,

        Axe = 1,
        Hoe = 2,
        Watering = 3,
        Stone = 4,
        Wood = 5,
        Grass = 6,
        Apple = 7,
        Bed = 8,
        SeedCorn = 9,
        Coin = 10,
        Corn = 11,
    }

    public class IDItemParser
    {
        private static Dictionary<IDItem, TagName> idToTagMap = new Dictionary<IDItem, TagName>
        {
            { IDItem.NoItem, TagName.NoTag },
            { IDItem.Axe, TagName.Tool },
            { IDItem.Hoe, TagName.Tool },
            { IDItem.Watering, TagName.Tool },
            { IDItem.Stone, TagName.Material },
            { IDItem.Wood, TagName.Material },
            { IDItem.Grass, TagName.Material },
            { IDItem.Apple, TagName.Fruit },
            { IDItem.Bed, TagName.Product },
            { IDItem.SeedCorn, TagName.Seed },
            { IDItem.Coin, TagName.Currency },
            { IDItem.Corn, TagName.Fruit }
        };

        public static IDItem FromString(string itemName)
        {
            try
            {
                return (IDItem)System.Enum.Parse(typeof(IDItem), itemName);
            }
            catch (ArgumentException e)
            {
                Debug.LogError(e.ToString());
                return IDItem.NoItem;
            }
        }

        public static TagName GetTagNameByID(IDItem id)
        {
            if (idToTagMap.TryGetValue(id, out TagName tag))
            {
                return tag;
            }
            Debug.LogWarning("IDItem not found in the dictionary: " + id);
            return TagName.NoTag;
        }
    }
}
