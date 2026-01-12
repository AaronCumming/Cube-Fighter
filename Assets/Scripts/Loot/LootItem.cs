using UnityEngine;

[CreateAssetMenu(fileName = "New Loot Item", menuName = "Loot/Loot Item")]
public class LootItem : ScriptableObject
{
    public GameObject itemPrefab;
    [Range(1, 100)]
    public int weight = 50; // Higher weight = higher chance
    public int minQuantity = 1;
    public int maxQuantity = 2;
}