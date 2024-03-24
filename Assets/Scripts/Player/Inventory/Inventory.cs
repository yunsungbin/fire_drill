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
    public List<GameObject> CheckObj = new List<GameObject>();

    public int Check = 100;
    public bool isItemFall = false;
    public bool isItemUse = false;

    public Player player;

    private void Start()
    {
        Check = 100;
        isItemFall = false;
        isItemUse = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && items[0] != null)
        {
            Check = 0;
            unCheckObj();
            CheckObj[0].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && items[1] != null)
        {
            Check = 1;
            unCheckObj();
            CheckObj[1].SetActive(true);
        }

        if (Check == 100)
            return;

        if (Input.GetKey(KeyCode.Q))
        {
            isItemFall = true;
            ItemDataBase.Fallitem = items[Check];
            items.RemoveAt(Check);
            onChangeItem.Invoke();
            unCheckObj();
            Check = 100;
        }
        if (Input.GetKey(KeyCode.E) && player.inputVec.x == 0 && player.inputVec.y == 0)
        {
            isItemUse = true;
            UseItem.useitem = items[Check];
            items.RemoveAt(Check);
            onChangeItem.Invoke();
            unCheckObj();
            Check = 100;
        }
    }

    private void unCheckObj()
    {
        CheckObj[0].SetActive(false);
        CheckObj[1].SetActive(false);
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
        if (collision.CompareTag("Inventory"))
        {
            FiledItem filedItem = collision.GetComponent<FiledItem>();
            if (AddItem(filedItem.GetItem()))
                filedItem.DestroyItem();
        }
    }
}
