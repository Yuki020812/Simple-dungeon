using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int Hp;
    public int Mp;

    public Consumable(int id, string name, string description, ItemType type, ItemQuality quality, int capacity, int buyPrice, int sellPrice, string sprite, int hp, int mp) : base(id, name, description, type, quality, capacity, buyPrice, sellPrice, sprite)
    {
        Hp = hp;
        Mp = mp;
    }

    public string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string newtext = "";
        newtext = string.Format("{0}\n<color=blue><size=10>消耗品</color>\n<color=orange>加血:{1}\n加蓝:{2}</color></size>",text,Hp,Mp);
        return newtext;
    }
    
}
