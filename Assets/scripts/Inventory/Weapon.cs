using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "inventory/Weapon")]
public class Weapon : Item
{
    public int damage;

    public override bool use(PlayerMove player, ItemInstance itemData)
    {
        player.activeItem = itemData;
        if (player.holder.transform.childCount > 0)
            Destroy(player.holder.transform.GetChild(0).gameObject);
        
        Instantiate(player.activeItem.itemData.prefab, player.holder.transform);
        return false;
    }
}
