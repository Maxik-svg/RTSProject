using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour, IBaseGO// перетащить сюда все связанное с кредитами
{
    public float BuyCreditsForGoods =  1.5f;
    public float SellCreditsForGoods = 0.5f;
    public float BuyGoodsForCredits = 1.5f;
    public float SellGoodsForCredits = 0.5f;
    ResidentialModuleScript residentialModule;
    WorkshopScript workshop;
    public float creditsNum = 500;
    public float creditsCoeff = 1; // bonus coefficient given by portal

    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    public float creditsPerGS { get => residentialModule.peopleNum * 0.1f * creditsCoeff; }

    public IEnumerator GS()
    {
        while (true)
        {
            creditsNum += creditsPerGS;

            print("credits: " + creditsNum + $"     {creditsPerGS}");
           
            yield return new WaitForSeconds(GSDuration);
        }
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(GSDuration);
        Level++;
        creditsCoeff *= 1.0025f; //will be changed
        workshop.goodsPerGS *= 1.0025f;
        float diff = (BuyCreditsForGoods - SellCreditsForGoods) * 0.99f / 2; //difference between selling and buying
        BuyCreditsForGoods = BuyGoodsForCredits = 1 + diff;
        SellCreditsForGoods = SellGoodsForCredits = 1 - diff;
    }

    // Start is called before the first frame update
    void Start()
    {
        GSDuration = 4f;
        Level = 1;
        residentialModule = this.GetComponent<ResidentialModuleScript>();
        workshop = this.GetComponent<WorkshopScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineStarted == false && Time.realtimeSinceStartup >= 4f)
        {
            StartCoroutine(GS());// making game step
            CoroutineStarted = true;
        }
    }
}
