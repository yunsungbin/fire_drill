using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private bool isItem = false;
    private void Awake()
    {
        isItem = false;
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

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {

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
