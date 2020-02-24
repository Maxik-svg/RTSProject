using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour, IBaseGO// перетащить сюда все связанное с кредитами
{
    public float BuyCreditsForGoods =  1.5f;
    public float SellCreditsForGoods = 0.5f;
    public float BuyGoodsForCredits = 1.5f;
    public float SellGoodsForCredits = 0.5f;
    public float creditsNum = 500;
    public float creditsCoeff = 1; // bonus coefficient given by portal

    public PlayerBaseScript playerBase { get; set; }

    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    public float creditsPerGS { get => playerBase.PeopleNum * 0.1f * creditsCoeff; }//change

    public IEnumerator GS()
    {
        while (true)
        {
            creditsNum += creditsPerGS;
            //print("credits: " + creditsNum + $"     {creditsPerGS}");
            yield return new WaitForSeconds(GSDuration);
        }
    }

    void GiveWorkshopsGSBonus() //makes workshops more productive
    {
        foreach (var item in playerBase.Workshops)
        {
            item.goodsPerGS *= 1.0025f;
        }
    }

    public void LevelUp()
    {
        StartCoroutine(LevelUpCoroutine());
    }

    public IEnumerator LevelUpCoroutine()
    {
        yield return new WaitForSeconds(4f);
        Level++;
        creditsCoeff *= 1.0025f; // influences credit making productivity
        GiveWorkshopsGSBonus();
        float diff = (BuyCreditsForGoods - SellCreditsForGoods) * 0.99f / 2; //new difference between selling and buying
        BuyCreditsForGoods = BuyGoodsForCredits = 1 + diff;
        SellCreditsForGoods = SellGoodsForCredits = 1 - diff;
    }

    // Start is called before the first frame update
    void Start()
    {
        GSDuration = 4f;
        Level = 1;
        playerBase = this.GetComponent<PlayerBaseScript>();
        //LevelUp();
    }
    // Update is called once per frame
    void Update()
    {
        if (CoroutineStarted == false && Time.realtimeSinceStartup >= 4f)
        {
            StartCoroutine(GS());// making game step
            //StartCoroutine(LevelUp());
            CoroutineStarted = true;
        }
    }
}
