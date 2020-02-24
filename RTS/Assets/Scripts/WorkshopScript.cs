using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopScript : MonoBehaviour, IBaseGO
{
    public float goodsNum;
    public float goodsPerGS = 100;
    public PlayerBaseScript playerBase { get; set; }
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        while (true)
        {
            goodsNum += goodsPerGS;
            
            //print("goods: " + goodsNum);
            yield return new WaitForSeconds(GSDuration);
        }
    }

    public void LevelUp()
    {
        StartCoroutine(LevelUpCoroutine());
    }

    public IEnumerator LevelUpCoroutine()
    {
        yield return new WaitForSeconds(GSDuration);
        float price = GameController.LevelUpPrice(Level);

        if (playerBase.GoodsNum >= price && playerBase.CreditsNum >= price)
        {
            Level++;
            goodsPerGS *= 1.0175f;
            playerBase.GoodsNum -= price;
            playerBase.CreditsNum -= price;
        }
        else
            playerBase.CreditsNum -= playerBase.CreditsNum + 2;

    }

    // Start is called before the first frame update
    void Start()
    {
        GSDuration = 4f;
        Level = 1;
        playerBase = this.GetComponent<PlayerBaseScript>();
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
