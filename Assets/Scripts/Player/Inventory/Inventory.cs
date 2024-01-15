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

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;
    private int slotCnt;

    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();
    public Slot slot;

    private void Start()
    {
        slotCnt = 2;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            bool isUse = slot.item.Use();
            if (isUse)
                RemoveItem(slot.slotnum);
        }
    }

    public bool AddItem(Item _item)
    {
        if (items.Count < slotCnt)
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
