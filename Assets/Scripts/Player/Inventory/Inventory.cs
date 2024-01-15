using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();

    public int Check = 100;
    public bool isItemFall = false;

    private void Start()
    {
        Check = 100;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && items[0] != null)
        {
            Check = 0;
        }
        if(Input.GetKey(KeyCode.Alpha2) && items[1] != null)
        {
            Check = 1;
            
        }
        if (Input.GetKey(KeyCode.Q) && Check != 100)
        {
            isItemFall = true;
            ItemDataBase.Fallitem = items[Check];
            items.RemoveAt(Check);
            onChangeItem.Invoke();
            Check = 100;
        }
    }

    public bool AddItem(Item _item)
    {
        if (items.Count < 2)
        {
            items.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            FiledItem filedItem = collision.GetComponent<FiledItem>();
            if (AddItem(filedItem.GetItem()))
                filedItem.DestroyItem();
        }
    }
}
