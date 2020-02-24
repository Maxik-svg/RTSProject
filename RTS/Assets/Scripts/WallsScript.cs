using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour, IBaseGO //add atack & defense of units
{
    BarracksScript barracks;
    public PlayerBaseScript playerBase { get; set; }
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        throw new System.NotImplementedException();
    }

    public void LevelUp()
    {
        StartCoroutine(LevelUpCoroutine());
    }

    public IEnumerator LevelUpCoroutine()
    {
        yield return new WaitForSeconds(4f);
        float price = GameController.LevelUpPrice(Level);

        if (playerBase.GoodsNum >= price && playerBase.CreditsNum >= price)
        {
            Level++;
            barracks.WallsDefenseBonus += 0.05f;
            playerBase.GoodsNum -= price;
            playerBase.CreditsNum -= price;
        }
        else
            playerBase.CreditsNum -= playerBase.CreditsNum + 2;
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        barracks = this.GetComponent<BarracksScript>();
        barracks.WallsDefenseBonus += 0.05f; //basic wall defense bonus
        playerBase = this.GetComponent<PlayerBaseScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
