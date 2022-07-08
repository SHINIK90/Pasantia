using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BoostersUpgrade : Items
{
    [SerializeField] ShopUpgrades upgradesShop;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI priceText;

    [SerializeField] GameObject ItemTienda;

    public Button BotonPrecio;

     
    public void lvlUp()
    {
        upgradesShop.buy(price);     
      
        soldItem();
    }
    private void updatePriceLabel()
    {
        priceText.text = price + "$";
    }
    public void updateDescription()
    {
        descriptionText.text = description;
    }

    protected override void Enlist()
    {
        if (!upgradesShop.isListed(itemName))
        {
            nameText.text = itemName;
            updatePriceLabel();
            upgradesShop.itemssList.Add(itemName, this);
            upgradesShop.BOUList.Add(itemName, this);
        }

    }
    private void soldItem()
    {
        BotonPrecio.GetComponent<Image>().color = new Color32(170,170,170,255);
        BotonPrecio.enabled = false;
        
       ItemTienda.GetComponentInChildren<Image>().color = Color.gray;
        ItemTienda.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
    }


}
