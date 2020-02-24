using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopMenuScript : MonoBehaviour
{
    public Text GoodsPerGS;
    public Text Level;
    public Text LevelUpCost;
    public Button LevelUp;
    bool trigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger)
        {
            LevelUp.onClick.AddListener(PlayerBaseScript.workshop.LevelUp);
            trigger = true;
        }
        GoodsPerGS.text = "Goods per GS: " +
            PlayerBaseScript.workshop.goodsPerGS;
        Level.text = "Level: " + PlayerBaseScript.workshop.Level;
        LevelUpCost.text = "Cost : Credits and Goods " +
            GameController.LevelUpPrice(PlayerBaseScript.workshop.Level);

    }
}
