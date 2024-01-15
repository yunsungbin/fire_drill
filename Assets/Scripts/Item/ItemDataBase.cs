using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    Inventory inven;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject filedItemPrefab;
    public Vector3[] pos;

    GameObject reItem;
    public static Item Fallitem;

    Vector3 spawnPos;

    private void Start()
    {
        inven = Inventory.instance;
        for(int index = 0; index < 6; index++)
        {
            GameObject go = Instantiate(filedItemPrefab, pos[index], Quaternion.identity);
            go.GetComponent<FiledItem>().SetItem(itemDB[Random.Range(0, 3)]);
        }
        
    }

    private void Update()
    {
        FallItems();
    }

    private void FallItems()
    {
        if (Inventory.instance.isItemFall)
        {
            Inventory.instance.isItemFall = false;

            Vector3 pos = inven.transform.position;

            spawnPos = pos + inven.transform.up * -1.0f;

            reItem = Instantiate(filedItemPrefab, spawnPos, Quaternion.identity);
            reItem.GetComponent<FiledItem>().SetItem(Fallitem);
        }
    }
}
