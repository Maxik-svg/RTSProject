using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialModuleScript : MonoBehaviour, IBaseGO
{
    public float creditsNum = 500;
    public int peopleNum = 200;
    public int peopleLimit = 1000;
    public int peoplePerGS = 100;
    public float creditsCoeff = 1; // bonus coefficient given by portal
    public float GSDuration { get; set; }
    public int Level { get; set; }
    public bool CoroutineStarted { get; set; }
    public float creditsPerGS{ get => peopleNum * 0.1f * creditsCoeff; }

    public IEnumerator GS()
    {
        while (true)
        {
            if (peopleNum + peoplePerGS < peopleLimit)
                peopleNum += peoplePerGS;
            else
                peopleNum = peopleLimit;

            creditsNum += creditsPerGS;

            print("credits: " + creditsNum + $"       {creditsPerGS}");
            print(peopleNum);
            yield return new WaitForSeconds(4f);
        }
    }

    public void LevelUp()
    {
        Level++;
        peopleLimit += 200;
        peoplePerGS = Mathf.RoundToInt(peoplePerGS * 1.05f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup >= 4f && CoroutineStarted == false)
        {
            StartCoroutine(GS());// making game step
            CoroutineStarted = true;
        }
            
    }
}
