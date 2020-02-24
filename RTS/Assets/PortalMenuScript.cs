using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalMenuScript : MonoBehaviour
{
    public Text CreditsPerGS;
    public Text Level;
    public Text LevelUpCost;
    public Text GoodsToGet;
    public Text CreditsToGet;
    public Button BuySellButton;
    public InputField BuyCredits;
    public InputField BuyGoods;
    public InputField SellCredits;
    public InputField SellGoods;
    public Text CostOfItem;
    public Text ProfitForItem;
    public Button LevelUp;
    bool trigger;

    
    float CreditsGet;
    float GoodsGet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger)
        {
            LevelUp.onClick.AddListener(PlayerBaseScript.portal.LevelUp);
            BuySellButton.onClick.AddListener(BuySellResources);
            ClearInputs();
            trigger = true;
        }
        CreditsPerGS.text = "People per GS: " +
            PlayerBaseScript.portal.creditsPerGS;
        Level.text = "Level: " + PlayerBaseScript.portal.Level;
        LevelUpCost.text = "Cost : Credits and Goods " +
            GameController.LevelUpPrice(PlayerBaseScript.residentialModule.Level);
        CostOfItem.text = "Cost of item = " + PlayerBaseScript.portal.BuyCreditsForGoods;
        ProfitForItem.text = "Profit of item " + PlayerBaseScript.portal.SellGoodsForCredits;
        
        //BuyCredits.onValueChanged.AddListener(DataUpdate);


    }

    public void BuySellResources()
    {
        PlayerBaseScript playerBase = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
        if (playerBase.CreditsNum + CreditsGet >= 0 && playerBase.GoodsNum + GoodsGet >= 0)
        {
            playerBase.CreditsNum += CreditsGet;
            playerBase.GoodsNum += GoodsGet;
        }
        else
            GameController.NoResourcesEvent.Invoke();
        ClearInputs();
    }

    public void UpdateData()
    {
        float buyCoeff = PlayerBaseScript.portal.BuyGoodsForCredits;
        float sellCoeff = PlayerBaseScript.portal.SellGoodsForCredits;

        CreditsGet = Convert.ToInt32((string)BuyCredits.text) - 
            Convert.ToInt32((string)BuyGoods.text) * buyCoeff + 
            Convert.ToInt32((string)SellGoods.text) * sellCoeff - 
            Convert.ToInt32((string)SellCredits.text);

        GoodsGet = Convert.ToInt32(BuyGoods.text) - 
            Convert.ToInt32(SellGoods.text) - 
            Convert.ToInt32(BuyCredits.text) * buyCoeff + 
            Convert.ToInt32(SellCredits.text) * sellCoeff;

        CreditsToGet.text = "Credits to Get: " + CreditsGet;
        GoodsToGet.text = "Goods to Get: " + GoodsGet;
    }

    public void ClearInputs()
    {
        BuyCredits.text = "0";
        SellCredits.text = "0";
        BuyGoods.text = "0";
        SellGoods.text = "0";
    }
}

/*public static class Extension
{
    public static void Clear(this InputField inputfield)
    {
        inputfield.Select();
        inputfield.text = "0";
    }
}*/
