using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadScript : MonoBehaviour
{
    public int SUnitsNum, AUnitsNum, DUnitsNum;
    public static float GSDuration;
    public int i; 
    public Vector2 StartPos;
    public Vector2 TargetPos
    {
        get => targetPos;
        set
        {
            targetPos = value;
            path = PathFinder.GetPath(StartPos, targetPos);
        }
    }

    Vector2 targetPos;

    List<Vector2> path = new List<Vector2>();

    public PathFinder PathFinder = new PathFinder();

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
        get // it will be min speed of units in the squad
        {
            if (AUnitsNum == 0 && DUnitsNum == 0)
                return UnitS.speed;
            else
                return UnitA.speed;
        }
    }

    

    

    public void Move() //move depending on GS
    {
        if (i < path.Count && (Vector2)this.transform.position != targetPos)
        {
            float step = Speed / 4f * Time.deltaTime; // taking in account GSDuration
            this.transform.position = Vector3.MoveTowards(this.transform.position, path[i], step);
        }
        

        if (i < path.Count && (Vector2)this.transform.position == path[i])
            i++;
        else if (i >= path.Count)
        {
            StartPos = this.transform.position;
            i = 0;
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
        PathFinder = new PathFinder();
    }

    // Update is called once per frame
    void Update()
    {
        if (path != null && targetPos != null /*&& (Vector2)this.transform.position != targetPos*/)
        {
            Move();
        }
    }
}
