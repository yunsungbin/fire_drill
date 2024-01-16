using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    Key
}

[System.Serializable]
public class KeyData
{
    public KeyType keyType;
    public string keyName;
    public Sprite keyImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }
        return false;
    }
}
