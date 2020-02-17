using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{
    public List<IBaseGO> PlayerBaseBuildings; //List of all player buildings
    public int peopleNum { get => residentialModule.peopleNum ; } 
    public int goodsNum { get => (int)workshop.goodsNum; }
    public int creditsNum { get => (int)portal.creditsNum; }

    ResidentialModuleScript residentialModule;
    BarracksScript barracks;
    WallsScript walls;
    WorkshopScript workshop;
    PortalScript portal;

    //resources
    float gSDuration = 4f;
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
        //Getting links for all base components
        residentialModule = this.GetComponent<ResidentialModuleScript>();
        barracks = this.GetComponent<BarracksScript>();
        walls = this.GetComponent<WallsScript>();
        workshop = this.GetComponent<WorkshopScript>();
        portal = this.GetComponent<PortalScript>();

        PlayerBaseBuildings = new List<IBaseGO>
        {
            residentialModule,
            barracks,
            walls,
            workshop,
            portal
        };

        //peopleNum = residentialModule.peopleNum;
        print(peopleNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
