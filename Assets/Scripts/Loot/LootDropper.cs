using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Collections;

public class LootDropper : MonoBehaviour
{
    public LootTable lootTable;

    public void DropLoot()
    {
        if (lootTable == null) return;

        var lootToDrop = lootTable.GetLoot();
        foreach (var item in lootToDrop)
        {
            Vector3 this_position = new Vector3(Random.Range(-10f,10f) + transform.position.x, Random.Range(1f,2f), Random.Range(-10f,10f) + transform.position.z);
            Instantiate(item, this_position, Quaternion.identity);
        }
    }

}