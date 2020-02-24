using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour, IBaseGO
{
    //units
    public int SUnitsNum, AUnitsNum, DUnitsNum;
    public int SUnitsInSquadNum, AUnitsInSquadNum, DUnitsInSquadNum;
    public int UnitsLimit = 200;
    public float WallsDefenseBonus = 0; // defense bonus provided by walls
    public PlayerBaseScript playerBase { get; set; }

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
    public float Defense //checking number of units on the base and returning their summary defense + wall bonus per unit
    {
        get
        {
            return (SUnitsNum - SUnitsInSquadNum) * (UnitS.defense + WallsDefenseBonus) +
                (AUnitsNum - AUnitsInSquadNum) * (UnitA.defense + WallsDefenseBonus) +
                (DUnitsNum - DUnitsInSquadNum) * (UnitD.defense + WallsDefenseBonus);
        }
    }


    public IEnumerator GS()
    {
        yield return new WaitForSeconds(GSDuration);
    }

    public void LevelUp()
    {
        StartCoroutine(LevelUpCoroutine());
    }

    public IEnumerator LevelUpCoroutine()
    {
        yield return new WaitForSeconds(4f);
        Level++;
        UnitsLimit += 100;

        UnitA.attack += 0.1f;
        UnitA.defense += 0.1f;
        UnitD.attack += 0.1f;
        UnitD.defense += 0.1f;
        UnitS.attack += 0.1f;
        UnitS.defense += 0.1f;
    }
    public void TrainUnits(int A, int S, int D)
    {
        StartCoroutine(TrainUnitsCoroutine(A, S, D));
    }

    IEnumerator TrainUnitsCoroutine(int AUnits, int SUnits, int DUnits) 
    {
        yield return new WaitForSeconds(4f);
        int newUnitsNum = AUnits + SUnits + DUnits;
        if (UnitsNum + AUnits + SUnits + DUnits <= UnitsLimit)
        {
            if (playerBase.CreditsNum >= 10 * newUnitsNum && playerBase.GoodsNum >= 10 * newUnitsNum)
            {
                playerBase.CreditsNum -= 10 * newUnitsNum;
                playerBase.GoodsNum -= 10 * newUnitsNum;

                AUnitsNum += AUnits;
                SUnitsNum += SUnits;
                DUnitsNum += DUnits;
            }
            else
                GameController.NoResourcesEvent.Invoke();
        }
        else
            GameController.ToManyUnitsEvent.Invoke();
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
