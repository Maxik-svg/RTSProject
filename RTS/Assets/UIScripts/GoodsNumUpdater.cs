using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsNumUpdater : MonoBehaviour
{
    public Text GoodsNum;
    PlayerBaseScript playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<PlayerBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GoodsNum.text = " Goods: " + playerBase.GoodsNum;
    }
}
