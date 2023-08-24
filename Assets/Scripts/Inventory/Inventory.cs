using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Slot[] slotLists;
    
    // Start is called before the first frame update
    void Start()
    {
        slotLists = GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame


    public bool StoreItem(int id)
    {
        Item item = InventoryManager.Instance.GetItemByID(id);
        return StoreItem(item);
    }
    
    public bool StoreItem(Item item)
    {
        if (item == null)
        {
            Debug.Log("the item is null");
            return false;
        }

        if (item.Capacity == 1)
        {
            Slot emptySlot = FindEmptySlot();
            if (emptySlot == null)
            {
                Debug.Log("没有空的物品槽");
                return false;
            }
            else
            {   
                emptySlot.StoreItem(item);
                return true;
            }
        }
        else
        {
            Slot slot = FindSameTypeSlot(item);
            if (slot != null)
            {
                slot.StoreItem(item);
                return true;
            }
            else
            {
                Slot emptySlot = FindEmptySlot();
                if (emptySlot == null)
                {
                    Debug.Log("is full");
                    return false;
                }
                else
                {
                    emptySlot.StoreItem(item);
                    return true;
                }   
            }
        }
    }

    public Slot FindEmptySlot()
    {
        foreach (Slot slot in slotLists)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }

    public Slot FindSameTypeSlot(Item item)
    {
        foreach (Slot slot in slotLists)
        {
            if (slot.transform.childCount >= 1 && slot.GetItemType() == item.Type && !slot.isFilled())
            {
                return slot;
            }
        }
        return null;
    }
    
    
}
