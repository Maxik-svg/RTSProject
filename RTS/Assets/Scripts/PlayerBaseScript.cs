﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{
    public List<IBaseGO> PlayerBaseBuildings; //List of all player buildings
    public List<ResidentialModuleScript> ResidentialModules; //List of all ResModules on the base
    public List<WorkshopScript> Workshops; //List of all Workshops on the base

    GameController gameController;
    ResidentialModuleScript residentialModule;
    BarracksScript barracks;
    WallsScript walls;
    WorkshopScript workshop;
    PortalScript portal;
    float gSDuration = 4f; //GS duration
    int lastPeopleNumCheck;
    float lastGoodsNumCheck;
    public int PeopleNum 
    { 
        get
        {
            int sum = 0;
            ResidentialModules.ForEach((x) => sum += x.peopleNum);
            lastPeopleNumCheck = sum;
            return sum;
        }
        set
        {
            if (value >= 0)
            {
                int diff = lastPeopleNumCheck - value;

                foreach (var item in ResidentialModules)
                {
                    if (item.peopleNum - diff > 0)
                    {
                        item.peopleNum -= diff;
                        break;
                    }
                    else
                    {
                        diff -= item.peopleNum;
                        item.peopleNum = 0;
                    }
                }
            }
            else
                gameController.NoResourcesEvent.Invoke();
        }
    }// change 
    public float GoodsNum
    {
        get
        {
            float sum = 0;
            Workshops.ForEach((x) => sum += x.goodsNum);
            lastGoodsNumCheck = sum;
            return sum;
        }
        set
        {
            if (value >= 0)
            {
                float diff = lastGoodsNumCheck - value;

                foreach (var item in Workshops)
                {
                    if (item.goodsNum - diff > 0)
                    {
                        item.goodsNum -= diff;
                        break;
                    }
                    else
                    {
                        diff -= item.goodsNum;
                        item.goodsNum = 0;
                    }
                }
            }
            else
                gameController.NoResourcesEvent.Invoke();
        }
    }
    public float CreditsNum 
    {
        get => portal.creditsNum;
        set
        {
            if (value >= 0)
                portal.creditsNum = value;
            else
                gameController.NoResourcesEvent.Invoke();
        }
    }//------------------------
    public float Attack { get => barracks.Attack; }
    public float Defence { get => barracks.Defence; }
    public float GSDuration 
    { 
        get => gSDuration; 
        set
        {
            if (gSDuration != value)
            {
                gSDuration = value;
                OnGSDurationChange();
            }
        }
    }

    void OnGSDurationChange()
    {
        foreach (var item in PlayerBaseBuildings)
        {
            item.GSDuration = gSDuration; 
        }
    }

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //Getting links for all base components
        residentialModule = this.GetComponent<ResidentialModuleScript>();
        barracks = this.GetComponent<BarracksScript>();
        walls = this.GetComponent<WallsScript>();
        workshop = this.GetComponent<WorkshopScript>();
        portal = this.GetComponent<PortalScript>();

        residentialModule.peopleNum = 200;
        workshop.goodsNum = 300;
        //ResidentialModules.A

        PlayerBaseBuildings = new List<IBaseGO>
        {
            residentialModule,
            barracks,
            walls,
            workshop,
            portal
        };
        ResidentialModules = new List<ResidentialModuleScript> { residentialModule };
        Workshops = new List<WorkshopScript> { workshop };

        //peopleNum = residentialModule.peopleNum;
        PeopleNum -= 300;
        print(PeopleNum);
    }

    // Update is called once per frame
    void Update()
    {
        print(GoodsNum);
    }
}
