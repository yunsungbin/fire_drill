using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject[] particle;
    public static Item useitem;
    public static bool Left = false;
    public static bool isStop = false;

    public void Update()
    {
        Use();
    }

    public void Use()
    {
        if (!Inventory.instance.isItemUse)
            return;

        if (useitem.itemType == ItemType.extinguisher)
        {
            isStop = true;
            Extinguisher();
        }
        if (useitem.itemType == ItemType.bandage)
        {
            Bandage();
        }
        if (useitem.itemType == ItemType.blanket)
        {
            Blanket();
        }
    }

    private void Extinguisher()
    {
        Inventory.instance.isItemUse = false;
        
        if (Left == true)
        {
            isStop = true;
            Instantiate(particle[0], transform.position, Quaternion.Euler(0, 180, 0));
        }
        if(Left == false)
        {
            isStop = true;
            Instantiate(particle[0], transform.position, Quaternion.Euler(0, 0, 0));
        }

    }

    private void Bandage()
    {
        Inventory.instance.isItemUse = false;
        Instantiate(particle[1], transform.position, Quaternion.identity);
    }

    private void Blanket()
    {
        Inventory.instance.isItemUse = false;
        Instantiate(particle[0], transform.position, Quaternion.identity);
    }
}
