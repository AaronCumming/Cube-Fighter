using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Loot Table", menuName = "Loot/Loot Table")]
public class LootTable : ScriptableObject
{
    public LootItem[] lootItems;
    public int minDrops = 1;
    public int maxDrops = 3;

    public List<GameObject> GetLoot()
    {
        var droppedItems = new List<GameObject>();
        if (lootItems.Length == 0) return droppedItems;

        // Build weighted list
        List<LootItem> weightedList = new List<LootItem>();
        foreach (var item in lootItems)
        {
            for (int i = 0; i < item.weight; i++)
            {
                weightedList.Add(item);
            }
        }

        int dropsToMake = Random.Range(minDrops, maxDrops + 1);

        for (int i = 0; i < dropsToMake; i++)
        {
            LootItem selected = weightedList[Random.Range(0, weightedList.Count)];
            int quantity = Random.Range(selected.minQuantity, selected.maxQuantity + 1);

            for (int q = 0; q < quantity; q++)
            {
                droppedItems.Add(selected.itemPrefab);
            }
        }

        return droppedItems;
    }
}