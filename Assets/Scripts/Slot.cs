using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject itemPrefab;
    
    /// <summary>
    /// 把item放在自身下面,
    /// 如果下面已经有item则amount++
    /// 如果没有,就根据itemPrefab去实例化一个放在下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();//如果存在相同的物品,则Amount++
        }
        else
        {
            GameObject itemGameObject = Instantiate(itemPrefab);
            itemGameObject.transform.SetParent(transform);
            itemGameObject.transform.localPosition = Vector3.zero;
            itemGameObject.GetComponent<ItemUI>().SetItem(item);
            itemGameObject.transform.localScale = Vector3.one;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// 获得当前物品槽的物品类型
    /// </summary>
    /// <returns></returns>
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }
    /// <summary>
    /// 检查物品数量是否达到上线
    /// </summary>
    /// <returns></returns>
    public bool isFilled()
    {
        ItemUI item = GetComponentInChildren<ItemUI>();
        if (item.Amount >= item.Item.Capacity)
        {
            return true;
        }

        return false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            InventoryManager.Instance.ShowToolTip(toolTipText);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.HideToolTip();
    }
}
