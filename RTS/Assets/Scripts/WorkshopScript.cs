using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopScript : MonoBehaviour, IBaseGO
{
    public float goodsNum = 300;
    public float goodsPerGS = 100;
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }

    public IEnumerator GS()
    {
        while (true)
        {
            goodsNum += goodsPerGS;
            
            print("goods: " + goodsNum);
            yield return new WaitForSeconds(GSDuration);
        }
    }

    public void LevelUp()
    {
        Level++;
        goodsPerGS *= 1.0175f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GSDuration = 4f;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineStarted == false && Time.realtimeSinceStartup >= 4f)
        {
            StartCoroutine(GS());// making game step
            CoroutineStarted = true;
        }
    }
}
