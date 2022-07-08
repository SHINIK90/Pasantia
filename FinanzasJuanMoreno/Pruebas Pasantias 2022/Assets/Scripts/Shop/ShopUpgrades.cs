using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopUpgrades : MonoBehaviour
{

    private float dinero = 1000f;
    public TextMeshProUGUI moneyLabel;

    public Dictionary<string, Items> itemssList = new Dictionary<string, Items>();  
    public Dictionary<string, BoostersUpgrade> BOUList = new Dictionary<string, BoostersUpgrade>();

    public bool isListed(string ItemName)
    {
        return itemssList.ContainsKey(ItemName);
    }
    public void buy(float prices)
    {
       
        dinero -= prices;
        updateMoneyLabel();
    }
    private void updateMoneyLabel()
    {
        moneyLabel.text = dinero + "$";
    }
}
