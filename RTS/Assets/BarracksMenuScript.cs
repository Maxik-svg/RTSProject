using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksMenuScript : MonoBehaviour
{
    //public Text CreditsPerGS;
    public Text Level;
    public Text LevelUpCost;
    public Text UnitsNum;
    public Text SUnitsNum;
    public Text AUnitsNum;
    public Text DUnitsNum;
    public Text Attack;
    public Text Defense;

    public InputField AddSUnits;
    public InputField AddAUnits;
    public InputField AddDUnits;

    public Button LevelUp;
    public Button TrainUnits;
    public Button AddSquad; // add this

    PlayerBaseScript playerBase;

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
            playerBase = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
            LevelUp.onClick.AddListener(PlayerBaseScript.barracks.LevelUp);
            TrainUnits.onClick.AddListener(UpdateData);
            ClearInputs();
            trigger = true;
        }
        
        UnitsNum.text = " UnitsNum: " + PlayerBaseScript.barracks.UnitsNum + 
            " / " + PlayerBaseScript.barracks.UnitsLimit;
        SUnitsNum.text = "S Units: " + PlayerBaseScript.barracks.SUnitsNum;
        AUnitsNum.text = "A Units: " + PlayerBaseScript.barracks.AUnitsNum;
        DUnitsNum.text = "D Units: " + PlayerBaseScript.barracks.DUnitsNum;
        Attack.text = "Attack: " + playerBase.Attack;
        Defense.text = "Defense " + playerBase.Defense;

        Level.text = "Level: " + PlayerBaseScript.barracks.Level;
        LevelUpCost.text = "Cost : (C) and (G) " +
            GameController.LevelUpPrice(PlayerBaseScript.barracks.Level);
        MakeCorrect();

    }

    //Update;
    public void UpdateData()
    {
        PlayerBaseScript.barracks.TrainUnits(Convert.ToInt32(AddAUnits.text),
            Convert.ToInt32(AddSUnits.text), Convert.ToInt32(AddDUnits.text));

        ClearInputs();
    }

    public void ClearInputs()
    {
        AddSUnits.text = "0";
        AddAUnits.text = "0";
        AddDUnits.text = "0";
    }

    void MakeCorrect()
    {
        if (AddAUnits.text == "")
            AddAUnits.text = "0";
        if (AddSUnits.text == "")
            AddSUnits.text = "0";
        if (AddDUnits.text == "")
            AddDUnits.text = "0";
    }

}
