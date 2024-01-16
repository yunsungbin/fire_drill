using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static Key instance;

    Inventory inven;

    private void Awake()
    {
        instance = this;
    }

    public List<KeyData> itemDB = new List<KeyData>();
    [Space(20)]
    public GameObject key;
    public Vector3[] pos;

    GameObject reItem;
    public static KeyData Fallitem;

    Vector3 spawnPos;

    private void Start()
    {
        inven = Inventory.instance;
        Vector3 keyPos = pos[Random.Range(0, pos.Length)];
        GameObject obj = Instantiate(key, keyPos, Quaternion.identity);
        
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

            reItem = Instantiate(key, spawnPos, Quaternion.identity);
            reItem.GetComponent<KeyFilled>().SetItem(Fallitem);
        }
    }
}
