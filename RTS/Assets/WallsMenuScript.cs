using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallsMenuScript : MonoBehaviour
{
    //public GameObject WallsMenu;
    public Text DefenceBonus;
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
            LevelUp.onClick.AddListener(PlayerBaseScript.walls.LevelUp);
            trigger = true;
        }
        DefenceBonus.text = "Defence Bonus: " + 
            PlayerBaseScript.barracks.WallsDefenseBonus;
        Level.text = "Level: " + PlayerBaseScript.walls.Level;
        LevelUpCost.text = "Cost : Credits and Goods " +
            GameController.LevelUpPrice(PlayerBaseScript.walls.Level);
        
    }
}
