using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject[] particle;
    public static int useItem = 0;

    Inventory inven;
    ItemType type;

    private void Update()
    {
        if (inven.Check != 100 && Input.GetKey(KeyCode.E))
        {
            if (inven.Check == 0) useItem = 1;
            if (inven.Check == 1) useItem = 2;

            switch (type)
            {
                case ItemType.extinguisher:
                    Extinguisher();
                    break;
                case ItemType.bandage:
                    break;
                case ItemType.blanket:
                    break;
            }
        }
    }

    private void Extinguisher()
    {
        particle[0].SetActive(true);
    }
}
