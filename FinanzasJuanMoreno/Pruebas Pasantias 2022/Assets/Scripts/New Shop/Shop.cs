using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchase = false;
    }

    [SerializeField] List<ShopItem> ShopItemList;
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] TMPro.TextMeshProUGUI CoinsText;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);

            //ShopItem
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image; //Icon
            g.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = ShopItemList[i].Price.ToString(); // Price
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !ShopItemList[i].IsPurchase; //Button Buy
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(ItemTemplate);

        //Change UI text :Coins
        SetCoinsUI();
    }

    private void OnShopItemBtnClicked( int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(ShopItemList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopItemList[itemIndex].Price);
            //Purchased Item
            ShopItemList[itemIndex].IsPurchase = true;
            //disable the button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = false;
            //Change Text
            buyBtn.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "COMPRADO";

            //Change UI text :Coins
            SetCoinsUI();
        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("No tienes suficiente dinero");
        }

    
    }
    void SetCoinsUI()
    {
        CoinsText.text = Game.Instance.Coins.ToString();
    }
}
