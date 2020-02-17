using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{
    GameObject mainBase;
    ResidentialModuleScript residentialModule;
    BarracksScript barracks;
    WallsScript walls;
    WorkshopScript workshop;
    PortalScript portal;
    int peopleNum, goodsNum, creditsNum; //resources
    //GameObject Barracks, Portal, ResidentialModule, Walls, Workshop;
   // int peopleLimit;
    // Start is called before the first frame update
    void Start()
    {
        //Getting links for all base components
        mainBase = GameObject.FindGameObjectWithTag("PlayerBase");
        residentialModule = mainBase.GetComponent<ResidentialModuleScript>();
        barracks = mainBase.GetComponent<BarracksScript>();
        walls = mainBase.GetComponent<WallsScript>();
        workshop = mainBase.GetComponent<WorkshopScript>();
        portal = mainBase.GetComponent<PortalScript>();

        peopleNum = residentialModule.peopleNum;
        print(peopleNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
