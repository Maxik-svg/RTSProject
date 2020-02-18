using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour, IBaseGO
{
    //units
    public int SUnitsNum, AUnitsNum, DUnitsNum;
    public int SUnitsInSquadNum, AUnitsInSquadNum, DUnitsInSquadNum;
    public int UnitsLimit = 200;
    public float WallsDefenceBonus = 0; // defence bonus provided by walls
    PlayerBaseScript playerBase;

    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    public int UnitsNum { get => SUnitsNum + AUnitsNum + DUnitsNum; }
    public float Attack
    {
        get //checking number of units on the base and returning their summary attack
        {
            return (SUnitsNum - SUnitsInSquadNum) * UnitS.attack +
                (AUnitsNum - AUnitsInSquadNum) * UnitA.attack +
                (DUnitsNum - DUnitsInSquadNum) * UnitD.attack;
        }
    }
    public float Defence //checking number of units on the base and returning their summary defence + wall bonus per unit
    {
        get
        {
            return (SUnitsNum - SUnitsInSquadNum) * (UnitS.defence + WallsDefenceBonus) +
                (AUnitsNum - AUnitsInSquadNum) * (UnitA.defence + WallsDefenceBonus) +
                (DUnitsNum - DUnitsInSquadNum) * (UnitD.defence + WallsDefenceBonus);
        }
    }


    public IEnumerator GS()
    {
        yield return new WaitForSeconds(GSDuration);
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(GSDuration);
        Level++;
        UnitsLimit += 100;

        UnitA.attack += 0.1f;
        UnitA.defence += 0.1f;
        UnitD.attack += 0.1f;
        UnitD.defence += 0.1f;
        UnitS.attack += 0.1f;
        UnitS.defence += 0.1f;
    }

    IEnumerator Train(int AUnits, int SUnits, int DUnits) //FINISH this
    {
        yield return new WaitForSeconds(GSDuration);
        int newUnitsNum = AUnits + SUnits + DUnits;
        if (UnitsNum + AUnits + SUnits + DUnits <= UnitsLimit 
            /* && playerBase.CreditsNum >= 10 * newUnitsNum && 
            playerBase.GoodsNum >= 10 * newUnitsNum &&
            playerBase.PeopleNum >= 1 * newUnitsNum*/) //Finish IT!
        {
            AUnitsNum += AUnits;
            SUnitsNum += SUnits;
            DUnitsNum += DUnits;

            playerBase.CreditsNum -= 10 * newUnitsNum;
            //playerBase.GoodsNum -= 10 * newUnitsNum;

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
