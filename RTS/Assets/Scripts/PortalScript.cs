using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour, IBaseGO
{
    public float BuyCreditsForGoods =  1.5f;
    public float SellCreditsForGoods = 0.5f;
    public float BuyGoodsForCredits = 1.5f;
    public float SellGoodsForCredits = 0.5f;
    GameObject mainBase;
    ResidentialModuleScript residentialModule;
    WorkshopScript workshop;
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        throw new System.NotImplementedException();
    }

    public void LevelUp()
    {
        Level++;
        residentialModule.creditsCoeff *= 1.0025f;
        workshop.goodsPerGS *= 1.0025f;
        float diff = (BuyCreditsForGoods - SellCreditsForGoods) * 0.99f / 2; //difference between selling and buying
        BuyCreditsForGoods = BuyGoodsForCredits = 1 + diff;
        SellCreditsForGoods = SellGoodsForCredits = 1 - diff;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainBase = GameObject.FindGameObjectWithTag("PlayerBase");
        residentialModule = mainBase.GetComponent<ResidentialModuleScript>();
        workshop = mainBase.GetComponent<WorkshopScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
