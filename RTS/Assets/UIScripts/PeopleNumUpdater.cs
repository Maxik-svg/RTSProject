using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleNumUpdater : MonoBehaviour
{
    public Text PeopleNum;
    PlayerBaseScript playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        PeopleNum.text = " People: " + playerBase.PeopleNum;
    }
}
