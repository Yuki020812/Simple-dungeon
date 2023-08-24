using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{
    public Material(int id, string name, string description, ItemType type, ItemQuality quality, int capacity, int buyPrice, int sellPrice, string sprite) : base(id, name, description, type, quality, capacity, buyPrice, sellPrice, sprite)
    {
    }
}
