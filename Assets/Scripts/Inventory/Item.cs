using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public  string Description { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }
    

    public Item()
    {
        this.ID = -1;
    }
    
    
    
    public Item(int id, string name, string description, ItemType type, ItemQuality quality, int capacity, int buyPrice, int sellPrice, string sprite)
    {
        ID = id;
        Name = name;
        Description = description;
        Type = type;
        Quality = quality;
        Capacity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        Sprite = sprite;
    }
    
    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Weapon,
        Equipment,
        Consumable
    }

    /// <summary>
    /// 物品品质
    /// </summary>
    public enum ItemQuality
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Artifact
    }

    public virtual string GetToolTipText()
    {
        string color = "";
        switch (Quality)
        {
            case ItemQuality.Common:
                color = "white";
                break;
            case ItemQuality.Rare:
                color = "green";
                break;
            case ItemQuality.Epic:
                color = "blue";
                break;
            case ItemQuality.Legendary:
                color = "orange";
                break;
            case ItemQuality.Artifact:
                color = "red";
                break;
        }

        string text =
            string.Format("<color={4}>{0}</color>\n<size=10>说明:{1}</size>\n<size=10>购买价格:{2}\n售出价格:{3}</size>", Name,
                Description, BuyPrice, SellPrice, color);

        return text;
    }
    
    
    
}
