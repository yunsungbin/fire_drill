using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public Slot[] slots;
    public Transform slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onChangeItem += RedrawSlotUI;
    }

    void RedrawSlotUI()
    {
        for(int index = 0; index < slots.Length; index++)
        {
            slots[index].RemoveSlot();
        }
        for(int index = 0; index < inven.items.Count; index++)
        {
            slots[index].item = inven.items[index];
            slots[index].UpdateSlotUI();
        }
    }
}
