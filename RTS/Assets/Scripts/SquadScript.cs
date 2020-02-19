using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadScript : MonoBehaviour
{
    public int SUnitsNum, AUnitsNum, DUnitsNum;
    public float Attack
    {
        get //checking number of units on the base and returning their summary attack
        {
            return SUnitsNum * UnitS.attack +
                AUnitsNum * UnitA.attack +
                DUnitsNum * UnitD.attack;
        }
    }
    public float Defense
    {
        get //checking number of units on the base and returning their summary attack
        {
            return SUnitsNum * UnitS.defense +
                AUnitsNum * UnitA.defense +
                DUnitsNum * UnitD.defense;
        }
    }
    public float Speed
    {
        get
        {
            if (AUnitsNum == 0 && DUnitsNum == 0)
                return UnitS.speed;
            else
                return UnitA.speed;
        }
    }

    //Add PathFinder!

    public SquadScript(int sUnitsNum, int aUnitsNum, int dUnitsNum) //constructor for a squad
    {
        SUnitsNum = sUnitsNum;
        AUnitsNum = aUnitsNum;
        DUnitsNum = dUnitsNum;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 a = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
