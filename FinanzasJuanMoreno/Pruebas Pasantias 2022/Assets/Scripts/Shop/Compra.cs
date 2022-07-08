using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra : MonoBehaviour
{
   

    [SerializeField] ShopUpgrades shopUpgrade;

    float[] shopItems = { 25, 50, 75, 100 };
    private float prices;

    public void item1()
    {
        prices = shopItems[0];
        Debug.Log(prices + "Precio del item 1");
    }

    public void item2()
    {
        prices = shopItems[1];
        Debug.Log(prices + "Precio del item 2");
    }

    public void buyItem()
    {
        shopUpgrade.buy(prices);
        Debug.Log(prices);
    }

}
