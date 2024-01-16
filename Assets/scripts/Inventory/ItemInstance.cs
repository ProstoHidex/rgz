using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance 
{
    [SerializeReference] public Item itemData;
    [SerializeField] public int damage;

    public bool use(PlayerMove player)
    {
        return itemData.use(player, this);
    }
}
