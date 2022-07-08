using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    [System.Serializable] class shopItem_Booster
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchase = false;
        public string description;

    }
  

    [SerializeField] List<shopItem_Booster> ShopItemList; //Lista Items
    [SerializeField] Animator NoCoinsAnim; //Animador no hay dinero
    [SerializeField] TMPro.TextMeshProUGUI CoinsText;
    [SerializeField] TMPro.TextMeshProUGUI itemDescription;


    GameObject ItemTemplate;
   // GameObject DescriptionTemplate;
    GameObject g ;
   //GameObject d;
    [SerializeField] Transform ShopScrollView; //Serialize Field Contenido =>Item
  //  [SerializeField] Transform DescriptionView;
    Button buyButton; //Boton Comprar

    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
       // DescriptionTemplate = DescriptionView.GetChild(0).gameObject;

        int len = ShopItemList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
           // d = Instantiate(DescriptionTemplate);

            //ShopItem
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image; //Icon
            g.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = ShopItemList[i].Price.ToString(); // Price
            //BuyButton
            buyButton = g.transform.GetChild(2).GetComponent<Button>();
            buyButton.interactable = !ShopItemList[i].IsPurchase; //Button Buy
            buyButton.AddEventListener(i, OnShopItemBtnClicked);

         
           // d.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = ShopItemList[i].description.ToString();
        }
        Destroy(ItemTemplate);

        //Change UI text :Coins
        SetCoinsUI();
    }

    private void OnShopItemBtnClicked(int itemIndex)
    {
        if (GameShop.Instance.HasEnoughCoins(ShopItemList[itemIndex].Price))
        {
            GameShop.Instance.UseCoins(ShopItemList[itemIndex].Price);
            //Purchased Item
            ShopItemList[itemIndex].IsPurchase = true;
            //disable the button
            buyButton = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyButton.interactable = false;
            //Change Text
            buyButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "COMPRADO";

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
        CoinsText.text = GameShop.Instance.Coins.ToString();
    }

    void SetDescriptionUI()
    {
      //  d = DescriptionView.GetChild(0).gameObject;
       // d.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = ShopItemList[i].description.ToString();
    }
   
}
