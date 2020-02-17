using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksScript : MonoBehaviour, IBaseGO
{
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    //units
    int SUnitsNum, AUnitsNum, DUnitsNum;
    //basic resources


    public IEnumerator GS()
    {
        yield return new WaitForSeconds(GSDuration);
    }

    public void LevelUp()
    {
        Level++;
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
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
