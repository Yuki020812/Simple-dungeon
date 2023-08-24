using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int Damage { get; set; }
    public WeaponType wpType { get; set; }

    public Weapon(int id, string name, string description, ItemType type, ItemQuality quality, int capacity, int buyPrice, int sellPrice, string sprite, int damage, WeaponType wpType) : base(id, name, description, type, quality, capacity, buyPrice, sellPrice, sprite)
    {
        Damage = damage;
        this.wpType = wpType;
    }
    
    public enum WeaponType
    {
        MainHand,
        OffHand,
        DoubleHand
    }

    public string GetToolTipText()
    {
        string text = base.GetToolTipText();
        string newtext = "";
        string weapon = "";
        switch (wpType)
        {
            case WeaponType.MainHand:
                weapon = "主武器";
                break;
            case WeaponType.OffHand:
                weapon = "副武器";
                break;
        }
        newtext = string.Format("{0}\n<color=blue>{1}</color>\n<color=orange><size=10>攻击力:{2}</size></color>\n", text,weapon,Damage);
        return newtext;
    }
}
