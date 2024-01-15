using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Use")]
public class ItemUseEffect : ItemEffect
{
    public int healingPoint = 0;
    public int Damage = 0;
    public override bool ExecuteRole()
    {
        return true;
    }
}
