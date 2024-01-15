using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    extinguisher, //소화기
    blanket, //담요
    bandage //붕대
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {
        bool isUsed = false;
        isUsed = true;
        return false;
    }
}
