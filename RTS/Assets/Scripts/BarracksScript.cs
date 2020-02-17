using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour, IBaseGO
{
    //units
    public int SUnitsNum, AUnitsNum, DUnitsNum;
    public int UnitsLimit = 200;
    PlayerBaseScript playerBase;

    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    public int UnitsNum { get => SUnitsNum + AUnitsNum + DUnitsNum; }
    //basic resources


    public IEnumerator GS()
    {
        yield return new WaitForSeconds(GSDuration);
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(GSDuration);
        Level++;
        throw new System.NotImplementedException();
    }

    IEnumerator Train(int AUnits, int SUnits, int DUnits) //FINISH this
    {
        yield return new WaitForSeconds(GSDuration);
        if (UnitsNum + AUnits + SUnits + DUnits <= UnitsLimit && 
            playerBase.creditsNum >= 10 && 
            playerBase.goodsNum >= 10 &&
            playerBase.peopleNum >= 1) //Finish IT!
        {
            AUnitsNum += AUnits;
            SUnitsNum += SUnits;
            DUnitsNum += DUnits;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
