using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResidentialModuleMenuScript : MonoBehaviour
{
    public Text PeoplePerGS;
    public Text PeopleLimit;
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
            LevelUp.onClick.AddListener(PlayerBaseScript.residentialModule.LevelUp);
            trigger = true;
        }
        PeoplePerGS.text = "People per GS: " +
            PlayerBaseScript.residentialModule.peoplePerGS;
        Level.text = "Level: " + PlayerBaseScript.residentialModule.Level;
        LevelUpCost.text = "Cost : Credits and Goods " +
            GameController.LevelUpPrice(PlayerBaseScript.residentialModule.Level);

    }
}
