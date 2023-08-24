using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item Item { get; private set; }
    public int Amount { get; private set; }

    private TMP_Text amountText;
    private Image itemImage;

    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }
            return itemImage;
        }
    }

    private TMP_Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = GetComponentInChildren<TMP_Text>();
            }
            return amountText;
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


    public void AddAmount(int amount=1)
    {
        Amount += amount;
        AmountText.text = Amount.ToString();
    }

    public void SetItem(Item item, int amount = 1)
    {
        Item = item;
        Amount = amount;
        Debug.Log(item.Sprite);
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        if (item.Capacity > 1)
        {
            AmountText.text = amount.ToString();
            Debug.Log(amountText.text);
        }
        else
        {
            AmountText.text = "";
        }
    }
}
